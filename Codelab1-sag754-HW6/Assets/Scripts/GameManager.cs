using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int resetLevel = 0;

    public Text infoText;
    public Text infoHits;
    public Text resetInfo;

    public float score = 0;
    public float hit = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        infoText.text = "Score: " + score;
        infoHits.text = "Hits: " + hit + "/3";
        resetInfo.text = "Reset at anytime by pressing R.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            score = 0;
            hit = 0;
            SceneManager.LoadScene(0);
        }
    }
}
