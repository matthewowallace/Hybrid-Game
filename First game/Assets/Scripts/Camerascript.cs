using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour {

    public static float offsetX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(birdscript.instance != null)
        {
            if (birdscript.instance.isAlive)
            {
                MoveTheCamera();
            }
        }
	}

    void MoveTheCamera()
    {
        Vector3 temp = transform.position;
        temp.x = birdscript.instance.GetPositionX() + offsetX;
        transform.position = temp;
    }
}
