using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaierMuzical : MonoBehaviour
{
    [SerializeField] AudioClip[] melodii;
    AudioSource sursa;
    int i;


    // Start is called before the first frame update
    
    void Awake()
    {
        PornesteSingletonul();
        sursa = GetComponent<AudioSource>();
        PornesteMuzica();

        
    }

    private void PornesteSingletonul()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PornesteMuzica()
    {
        AudioClip clip = melodii[UnityEngine.Random.Range(0, melodii.Length)];
        sursa.PlayOneShot(clip);
        
        
    }
}
