using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontroller : MonoBehaviour
{
    public static gamecontroller instance;

    private const string High_score = "High Score ";
    private const string Selectedbird = "Selected Bird ";
    private const string Demonbird = "Selected Bird ";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        MakeSelection();
        isTheGameStartedFortheFirstTime();
    }

    void MakeSelection()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void isTheGameStartedFortheFirstTime()
    {
        if (!PlayerPrefs.HasKey("isTheGameStartedFortheFirstTime"))
        {
            PlayerPrefs.SetInt(High_score, 0);
            PlayerPrefs.SetInt(Selectedbird, 0);
            PlayerPrefs.SetInt(Demonbird, 1);
            PlayerPrefs.SetInt("isTheGameStartedFortheFirstTime", 0);
        }
    }

    public void SetHighscore(int score)
    {
        PlayerPrefs.SetInt(High_score, score);
    }


    public int GetHighscore()
    {
        return PlayerPrefs.GetInt(High_score);
    }


    public void SetSelectedbird(int selectedbird)
    {
        PlayerPrefs.SetInt(Selectedbird, selectedbird);
    }


    public int GetSelectedbird()
    {
        return PlayerPrefs.GetInt(Selectedbird);
    }

    public void UnlockDemonBird()
    {
        PlayerPrefs.SetInt(Demonbird, 1);
    }


    public int isDemonBirdUnlocked()
    {
        return PlayerPrefs.GetInt(Demonbird);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
