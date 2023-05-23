using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Soundtrack : MonoBehaviour
{
    [SerializeField] Slider sliderVolum;

    private AudioSource sursa;
    public AudioClip[] melodii;
    public float volum;
    [SerializeField]private float timerPiesa;
    [SerializeField]private float melodiiCantate;
    [SerializeField]private bool[] aFostCantata;

    void Awake()
    {
        PornesteSingletonul();
    }
    // Start is called before the first frame update
    void Start()
    {
        aFostCantata = new bool[melodii.Length];
        sursa = GetComponent<AudioSource>();
        if (!sursa.isPlaying)
        {
            SchimbaMuzica(1);
        }
        SchimbaVolumul();
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderVolum == null)
        {
            sliderVolum = GameObject.Find("Slider Music").GetComponent<Slider>();
        }
        if (sursa.isPlaying)
        {
            timerPiesa += 1 * Time.deltaTime;
        }

        sursa.volume = volum;
        if (!sursa.isPlaying || timerPiesa >= sursa.clip.length || Input.GetKeyDown(KeyCode.K))
        {
            SchimbaMuzica(Random.Range(0, melodii.Length));
        }
        
        ResetareaAmestecarii();
        SchimbaVolumul();


    }
    public void SchimbaMuzica(int canteculAles)
    {
        if (!aFostCantata[canteculAles])
        {
            timerPiesa = 0;
            melodiiCantate++;
            aFostCantata[canteculAles] = true;
            sursa.clip = melodii[canteculAles];
            sursa.Play();
        }
        else
            sursa.Stop();
    }
    
   private void ResetareaAmestecarii()
    {
        if (melodiiCantate == melodii.Length)
        {
            melodiiCantate = 0;
            for (int i = 0; i < melodii.Length; i++)
            {
                if (i == melodii.Length)
                    break;
                else
                    aFostCantata[i] = false;
            }
        }
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
    private void SchimbaVolumul()
    {
        volum = sliderVolum.value;
    }
}
