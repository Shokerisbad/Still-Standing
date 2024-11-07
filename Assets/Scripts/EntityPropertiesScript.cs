using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class EntityPropertiesScript : MonoBehaviour
{
    public int contactDamage = 2;
    public int maxHealth = 100;
    [HideInInspector]
    public int health = 0;
    public AnimationCurve shakeIntensityCurve;
    public float shakeTime = 1f;
    public AnimationCurve flashIntensityCurve;
    public Color flashColor = Color.white;
    private Camera _camera;
    
    public class EntityData : EntityPropertiesScript {
        public new int health;
        public Vector3 position;
        public string entityType;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        health = maxHealth;
    }

    public int GetHp()
    {
        return health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (gameObject.tag.Equals("Player"))
            {
                Time.timeScale = 0f;
                transform.GetComponent<Animator>().Play("Player Death");
                transform.GetComponent<MovementScript>().enabled = false;
                transform.GetComponent<GunScript>().enabled = false;
                gameObject.tag = "Untagged";
                Destroy(gameObject, 2.5f);
            }
            else
            {
                Destroy(gameObject, 0.1f);
            }
            return;
        }

        StartCoroutine(DamageFlash());
        Knockback();
        if (gameObject.tag.Equals("Player"))
            StartCoroutine(ScreenShake());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EntityPropertiesScript>().TakeDamage(contactDamage);
        }
    }

    private void OnDestroy()
    {
        if (transform.tag.Equals("Enemy") && transform.parent != null)
            transform.parent.transform.GetComponent<WaveManagerScript>().EnemyKilled();
    }

    private IEnumerator ScreenShake()
    {
        Vector3 startPosition = _camera.transform.position;
        float time = 0f, strength = 0f;

        while (time < shakeTime) {
            time += Time.deltaTime;
            strength = shakeIntensityCurve.Evaluate(time / shakeTime);
            _camera.transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        _camera.transform.position = startPosition;
    }

    private IEnumerator DamageFlash()
    {
        yield return null;
        float time = 0f, strength = 0f;

        while (time < shakeTime)
        {
            time += Time.deltaTime;
            strength = shakeIntensityCurve.Evaluate(time / shakeTime);

            if (gameObject.tag.Equals("Player"))
                gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(flashColor, Color.white, strength);
            else if (gameObject.tag.Equals("Enemy"))
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(flashColor, Color.white, strength);

            yield return null;
        }


        if (gameObject.tag.Equals("Player"))
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        else if (gameObject.tag.Equals("Enemy"))
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Knockback(){
        if(gameObject.tag.Equals("Enemy"))
            transform.position = Vector2.MoveTowards(transform.position, transform.position - transform.up * 0.3f, 2f * Time.deltaTime);
        else if (gameObject.tag.Equals("Player"))
            transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.up * 0.3f, 2f * Time.deltaTime);
    }

    public void SaveEntityData()
    {
        EntityData data = gameObject.AddComponent<EntityData>();
        data.health = health;
        data.position = transform.position;
        data.entityType =
            gameObject.tag; // Assume tag represents type (e.g., "Player", "Enemy") to remember what we're saving      
        
        string json = JsonUtility.ToJson(data);                                                           
        File.WriteAllText(Application.persistentDataPath + $"/{gameObject.name}_data.json", json);        
    }
  
    public void LoadEntityData() {
        string path = Application.persistentDataPath + $"/{gameObject.name}_data.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            EntityData data = JsonUtility.FromJson<EntityData>(json);

            this.health = data.health;
            transform.position = data.position;
        } else {
            Debug.LogWarning("Save file not found.");
        }
    }
  
   
    
    
}
