using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    public GameObject player;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            image.rectTransform.sizeDelta = new Vector2(400 - player.GetComponent<EntityPropertiesScript>().GetHp() * 4, image.rectTransform.sizeDelta.y);
    }
}
