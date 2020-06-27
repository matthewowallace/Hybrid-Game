using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birdscript : MonoBehaviour {

    public static birdscript instance;

    [SerializeField]
    private Rigidbody2D myrigidbody;

    [SerializeField]
    private Animator anima;

    [SerializeField]
    private AudioSource audiosource;

    [SerializeField]
    private AudioClip flapclick, pointclip, diedclip;

    private float forwardspeed =3f;

  
    private float bounceSpeed =3f;

    private Button flapbutton;

    private bool didFlap;

    public bool isAlive;

    public int score;

     void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        isAlive = true;
        score = 0;
        flapbutton = GameObject.FindGameObjectWithTag("flapbutton").GetComponent<Button>();
        flapbutton.onClick.AddListener(() => flapthebird());

        SetCameraX();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isAlive)
        {
            if (score >= 20 && score <= 40)
            {
                forwardspeed = 5f;
            }
            else if (score >= 41 && score <= 100)
            {
                forwardspeed = 10f;
            }
            else if (score >= 101 && score <= 500)
            {
                forwardspeed = 20f;
            }
            else if (score >= 501)
            {
                forwardspeed = 40f;
            }
            else
            {
                forwardspeed = 3f;
            }

            Vector3 temp = transform.position;
            temp.x += forwardspeed * Time.deltaTime;
            transform.position = temp;

            if (didFlap)
            {
                didFlap = false;
                myrigidbody.velocity = new Vector2(0, bounceSpeed);
                audiosource.PlayOneShot(flapclick);
                anima.SetTrigger("flap");


            }


            if(myrigidbody.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }  else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -myrigidbody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
	}


    void SetCameraX()
    {
        Camerascript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }

    public void flapthebird()
    {
        didFlap = true;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "ground" || target.gameObject.tag == "pipe")
        {
            if (isAlive)
            {
                isAlive = false;
                anima.SetTrigger("dead");
            
                audiosource.PlayOneShot(diedclip);
                Gameplaycontroller.instance.PlayerdiedshowScore(score);
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "pipeholder")
        {
            score++;
            Gameplaycontroller.instance.SetScore(score);
            audiosource.PlayOneShot(pointclip);
        }
    }
}
