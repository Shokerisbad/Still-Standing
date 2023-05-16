using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    //config parameters
    int hp;//hp=10
    int health;
    bool alive;
    

    //cached references
    [SerializeField] public GameObject player;
    public Image imager;

    // Start is called before the first frame update
    void Start()
    {
        
        imager = GetComponent<Image>();
        imager.rectTransform.sizeDelta = new Vector2(0, imager.rectTransform.sizeDelta.y);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            hp = player.GetComponent<EntityPropertiesScript>().GetHp();
            if (hp > 0)
            {
                BarUpdate();
            }
            else
            {
                imager.rectTransform.sizeDelta = new Vector2(400, imager.rectTransform.sizeDelta.y);

            }
        }
        /*alive = player.GetComponent<EntityPropertiesScript>().Alive();
        if (alive)
        {
            hp = player.GetComponent<EntityPropertiesScript>().GetHp();
            BarUpdate();
       
        }
        else imager.rectTransform.sizeDelta = new Vector2(400, imager.rectTransform.sizeDelta.y);*/


    }

   /* private void VariablesImport()
    {
        hp = player.GetComponent<EntityPropertiesScript>().GetHp();
        alive = player.GetComponent<EntityPropertiesScript>().Alive();
    }*/

    private void BarUpdate()
     {   
         
         health = 10 - hp;
         imager.rectTransform.sizeDelta = new Vector2(40 * health, imager.rectTransform.sizeDelta.y);


     }

   
}
