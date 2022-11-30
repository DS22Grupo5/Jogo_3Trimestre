using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMinigame : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int score = 0;

    public int missed = 0;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // instance = this; 
        gameOver = GameObject.Find("gameOver");
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        if(score >= 10)
        {
            SceneManager.LoadScene(4);
        }
        else if(missed >= 10)
        {
            gameOver.SetActive(true);
            Invoke("RecarregarMinigame", 2f);
        }
        
    }

    void RecarregarMinigame()
    {
        SceneManager.LoadScene(3);
    }

    public void NoteHit()
    {
        score++;
    }

    public void NoteMissed()
    {
        missed++;
    }
}
