using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(gameObject, 0.1f);
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
        Vector3 startPosition = Camera.main.transform.position;
        float time = 0f, strength = 0f;

        while (time < shakeTime) {
            time += Time.deltaTime;
            strength = shakeIntensityCurve.Evaluate(time / shakeTime);
            Camera.main.transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        Camera.main.transform.position = startPosition;
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
}
