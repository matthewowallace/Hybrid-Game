using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGcollector : MonoBehaviour {


    private GameObject[] backgrounds;
    private GameObject[] grounds;
    private GameObject[] snowfall;

    private float lastBGX;
    private float lastGroundX;
    private float lastSnow;

    // Use this for initialization
    void Awake()
    {

        backgrounds = GameObject.FindGameObjectsWithTag("background");
        grounds = GameObject.FindGameObjectsWithTag("ground");
        snowfall = GameObject.FindGameObjectsWithTag("snowfal");

        lastBGX = backgrounds[0].transform.position.x;
        lastGroundX = grounds[0].transform.position.x;
        lastSnow = snowfall[0].transform.position.x;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if (lastBGX < backgrounds[i].transform.position.x)
            {
                lastBGX = backgrounds[i].transform.position.x;
            }
        }

        for (int i = 1; i < grounds.Length; i++)
        {
            if (lastGroundX < grounds[i].transform.position.x)
            {
                lastGroundX = grounds[i].transform.position.x;
            }
        }

        for (int i = 1; i < snowfall.Length; i++)
        {
            if (lastSnow < snowfall[i].transform.position.x)
            {
                lastSnow = snowfall[i].transform.position.x;
            }
        }


    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "background")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = lastBGX + width;

            target.transform.position = temp;

            lastBGX = temp.x;

        }
        else if (target.tag == "ground")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = lastGroundX + width;

            target.transform.position = temp;

            lastGroundX = temp.x;

        }
        else if (target.tag == "snowfal")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = lastSnow + width;

            target.transform.position = temp;

            lastSnow = temp.x;

        }

    }
}
