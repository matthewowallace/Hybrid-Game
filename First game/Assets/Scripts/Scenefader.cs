using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenefader : MonoBehaviour
{
    public static Scenefader instance;

    [SerializeField]
    private Animator fadeAnim;

    [SerializeField]
    private GameObject fadeCanvas;
    private void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeinAnimation(string levelName)
    {
        fadeCanvas.SetActive(true);
        fadeAnim.Play("Fadein");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.7f));
        Application.LoadLevel(levelName);
        Fadeout();
    }

    IEnumerator FadeOutAnimation()
    {
        fadeAnim.Play("Fadeout");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));
        fadeCanvas.SetActive(false);
       
    }

    public void Fadeout()
    {
        StartCoroutine (FadeOutAnimation());
    }

    public void Fadein(string levelName)
    {
        StartCoroutine(FadeinAnimation(levelName));
    }
}
