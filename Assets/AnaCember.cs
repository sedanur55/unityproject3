using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaCember : MonoBehaviour
{
    public GameObject kucukCember;
    GameObject oyunYoneticisi;
    AudioSource ses;
    void Start()
    {
        oyunYoneticisi = GameObject.FindGameObjectWithTag("oyunyoneticisitag");
        ses = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            kucukCemberOlustur();
        }
    }
    void kucukCemberOlustur()
    {
        ses.Play();
        Instantiate(kucukCember, transform.position, transform.rotation);
        
        oyunYoneticisi.GetComponent<OyunYoneticisi>().kalanText();
    }
}
