using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class splash2 : MonoBehaviour
{
    public string leveltoload;
    private float timer = 7f;
    private Text timerseconds;

    // Start is called before the first frame update
    void Start()
    {
        timerseconds = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(sceneName: "warningscene");
        }
    }
}

