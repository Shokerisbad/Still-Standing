using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    public GameObject player;
    private Image image;
    private float target = 1f, value = 1f;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null)
        {
            image.fillAmount = 0;
            return;
        }

        target = player.GetComponent<EntityPropertiesScript>().GetHp() / 100f;


        if (value > target)
            value -= (value - target) / 7;

        image.fillAmount = value;
    }
}
