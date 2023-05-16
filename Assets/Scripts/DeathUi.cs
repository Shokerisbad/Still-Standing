using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUi : MonoBehaviour
{
    int hp;
    [SerializeField] GameObject player;
    [SerializeField] GameObject objectToDeactivate;
    // Start is called before the first frame update
    void Start()
    {
        objectToDeactivate.SetActive(false);

    }



    // Update is called once per frame
    void Update()
    {

        if (!player)

            objectToDeactivate.SetActive(true);
       
        else 
            objectToDeactivate.SetActive(false);

    }
}
