using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplaycontroller : MonoBehaviour
{
    public static Gameplaycontroller instance;

    [SerializeField]
    private Text scoreText, endscrore, highscore, gameOvertext;

    [SerializeField]
    private Button restartGamebutton, instructionsbutton;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject[] birds;

    [SerializeField]
    private Sprite[] medals;

    [SerializeField]
    private Image medalImage;

    
    private void Awake()
    {
        MakeInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void pausegame()
    {
        if (birdscript.instance != null)
        {
            if (birdscript.instance.isAlive)
            {
                pausePanel.SetActive(true);
                gameOvertext.gameObject.SetActive(false);
                endscrore.text = " " + birdscript.instance.score;
                highscore.text = " " + gamecontroller.instance.GetHighscore();
                Time.timeScale = 0f;
                restartGamebutton.onClick.RemoveAllListeners();
                restartGamebutton.onClick.AddListener(() => resumeGame());
            }
        }
    }

    public void GotoMenuButton()
    {
        Scenefader.instance.Fadein("intro");
    }

    public void resumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void restartGame()
    {
        Scenefader.instance.Fadein(Application.loadedLevelName);
    }

    public void PlayGame()
    {
        scoreText.gameObject.SetActive(true);
        birds[gamecontroller.instance.GetSelectedbird()].SetActive(true);
        instructionsbutton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetScore(int score)
    {
        scoreText.text = " " + score;
    }

    public void PlayerdiedshowScore(int score)
    {
        pausePanel.SetActive(true);
        gameOvertext.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);

        endscrore.text = "" + score;

        if(score > gamecontroller.instance.GetHighscore())
        {
            gamecontroller.instance.SetHighscore(score);
        }

        highscore.text = "" + gamecontroller.instance.GetHighscore();

        if(score <= 20)
        {
            medalImage.sprite = medals[0];
        }else if (score >20 && score < 40)
        {
            medalImage.sprite = medals[1];
          
        }
        else if (score > 40 && score < 200)
        {
            medalImage.sprite = medals[2];
          
           

            if (gamecontroller.instance.isDemonBirdUnlocked() == 0)
            {
                gamecontroller.instance.UnlockDemonBird();
            }

        }
        else if (score > 200 && score < 500)
        {
            medalImage.sprite = medals[3];
        }
        else
        {
            medalImage.sprite = medals[4];
        }

        restartGamebutton.onClick.RemoveAllListeners();
        restartGamebutton.onClick.AddListener(() => restartGame());
       
        
    }

}
