using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public static MainMenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isDemonbirdUnlocked;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }

    // Update is called once per frame
   void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void CheckifBirdsareUnlocked()
    {
        if (gamecontroller.instance.isDemonBirdUnlocked() == 1)
        {
            isDemonbirdUnlocked = true;
        }
        
    }

    void Start()
    {
        birds[gamecontroller.instance.GetSelectedbird()].SetActive(true);
        CheckifBirdsareUnlocked();
    }


    public void ChangeBird()
    {
        if (gamecontroller.instance.GetSelectedbird() == 0)
        {
            if (isDemonbirdUnlocked)
            {
                birds[0].SetActive(false);
                gamecontroller.instance.SetSelectedbird(1);
                birds [gamecontroller.instance.GetSelectedbird()].SetActive (true);

            }

        }
        else if (gamecontroller.instance.GetSelectedbird() == 1)
        {
            birds[1].SetActive(false);
            gamecontroller.instance.SetSelectedbird(0);
            birds[gamecontroller.instance.GetSelectedbird()].SetActive(true);
        }


    }

    public void PlayGame()
    {
        Scenefader.instance.Fadein("Gameplay");
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
