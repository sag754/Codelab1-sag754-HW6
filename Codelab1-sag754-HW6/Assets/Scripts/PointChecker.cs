using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PointChecker : MonoBehaviour
{
    public static int currentLevel= 0;

    public float targetHit = 3;
    public float perfectHit = 4;
    public float missHit = 2;

    public AudioSource yay;
    public AudioSource complete;
    public AudioSource wrong;

    [SerializeField] private Image completeText;
    [SerializeField] private Image failureText;
    [SerializeField] private Image successText;

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
            if(other.CompareTag("Player"))
            {
                successText.enabled = true;
            }
            yay.Play();
            complete.Play();
            currentLevel++;
            Invoke("NextLevel", 4f); 
        }

        if (GameManager.instance.hit == targetHit)
        {
            if (other.CompareTag("Player"))
            {
               completeText.enabled = true;
            }
            complete.Play();
            currentLevel++;
            Invoke("NextLevel", 4f); 
        }
        
        if(GameManager.instance.hit <= missHit)
        {
            if (other.CompareTag("Player"))
            {
                failureText.enabled = true;
            }
            wrong.Play();
            Invoke("Reset", 2f);
        }
    }

    void NextLevel()
    {
        failureText.enabled = false;
        completeText.enabled = false;
        successText.enabled = false;
        SceneManager.LoadScene(currentLevel);
    }

    void Reset()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
