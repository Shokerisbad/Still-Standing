using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    public GunScript playerGunScript;
    public GameObject ammoCell = null;
    public GameObject ammoBullet = null;
    public GameObject ammoBarStart = null;
    private GameObject[] bullets = null;
    int maxAmmo = 0, ammo = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxAmmo = playerGunScript.maxAmmo;
        bullets = new GameObject[maxAmmo];
        if (maxAmmo > 8)
            ammoBarStart.GetComponent<RectTransform>().anchoredPosition = new Vector2(ammoBarStart.GetComponent<RectTransform>().anchoredPosition.x - (maxAmmo - 8) * 9, 0);

        for (int i = 0; i < maxAmmo - 8; i++)
        {
            GameObject cell = Instantiate(ammoCell, Vector3.zero, Quaternion.identity, transform);
            cell.GetComponent<RectTransform>().anchoredPosition = new Vector2(-39 - 9 * i, 0);
            cell.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
            cell.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
            cell.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
        }

        for (int i = 0; i < maxAmmo; i++)
        {
            bullets[i] = Instantiate(ammoBullet, Vector3.zero, Quaternion.identity, transform);
            bullets[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.3f - 9 * i, 0);
            bullets[i].GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
            bullets[i].GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
            bullets[i].GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxAmmo; i++)
            if(playerGunScript.ammo <= i) 
                bullets[i].SetActive(false);
            else
                bullets[i].SetActive(true);
    }
}
