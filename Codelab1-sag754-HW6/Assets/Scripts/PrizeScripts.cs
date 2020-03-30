using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeScripts : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource ding;

    public ParticleSystem popParticles;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //if something enters this trigger
    {
        GameManager.instance.hit++;
        GameManager.instance.score += 1000;
        popParticles.Play();
        audio.Play();
        ding.Play();
        GetComponent<Renderer>().enabled = false; //stop rendering it
        Invoke("DelayDestroy", 2.7f); //in 2.7 seconds, call DelayDestroy
    }

   void DelayDestroy()
   {
       Destroy(gameObject); //Destroy the object
   }
}
