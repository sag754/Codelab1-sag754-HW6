using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PointChecker : MonoBehaviour
{
    public float targetHit = 3;
    public float perfectHit = 4;
    public float missHit = 2;

    public AudioSource yay;
    public AudioSource complete;
    public AudioSource wrong;

    // Start is called before the first frame update
    void Start()
    {
        complete = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //if something enters this trigger
    {
        if (GameManager.instance.hit >= perfectHit)
        {
            yay.Play();
            complete.Play();
            Invoke("NextLevel", 4f); 
        }

        if (GameManager.instance.hit == targetHit)
        {
            complete.Play();
            Invoke("NextLevel", 4f); 
        }
        
        if(GameManager.instance.hit <= missHit)
        {
            wrong.Play();
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
