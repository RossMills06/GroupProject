using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //public float endTimer;
    public float timer;
    public bool complete, rank;
    public Text time;
    public Text intro;
    public Text exit;

    private string hour;
    private AudioSource soundFx;

    public Transform target;
    public Vector3 targetPos;

<<<<<<< HEAD
    public GameObject obtsicles;
=======
    public GameObject start;
    public GameObject end;

    public ScoreManager sc;
>>>>>>> caf9ac5a055e07d36db9ea2ecf61c0070697fbbd

    // Use this for initialization
    void Start()
    {
        timer = 0;
        hour = "8:";
        complete = false;

        soundFx = GetComponent<AudioSource>();

        targetPos = target.transform.position;

        StartCoroutine(StartUp());
    }

    IEnumerator StartUp()
    {
        intro.enabled = true;
        yield return new WaitForSeconds(5);
        intro.enabled = false;
        obtsicles.SetActive(true);
    }

	
	// Update is called once per frame
	void Update()
    {
        if (!complete)
        {
            if (timer > 5.0f)
            {
                start.SetActive(false);
            }

            timer += Time.deltaTime;

            if (timer > 60)
            {
                timer = 0;
                hour = "9:";
            }

            if (timer < 10)
                time.text = hour + "0" + Convert.ToString((int)timer) + " am";

            if (timer > 10 && timer < 60)
                time.text = hour + Convert.ToString((int)timer) + " am";
        }

        if (complete)
        {
            soundFx.Stop();
            //endTimer += Time.deltaTime;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = Vector3.Lerp(player.transform.position, targetPos, Time.deltaTime);
<<<<<<< HEAD
            StartCoroutine(Finish());
=======

            if (timer <= 50 && timer > 40)
                sc.totalScore = 4;
            else if (timer <= 53 && timer > 50)
                sc.totalScore = 3;
            else if (timer <= 56 && timer > 53)
                sc.totalScore = 2;
            else
                sc.totalScore = 1;

            if (rank)
            {
                sc.finished = true;
                rank = false;
            }
            
>>>>>>> caf9ac5a055e07d36db9ea2ecf61c0070697fbbd
        }
    }

    IEnumerator Finish()
    {
        exit.enabled = true;
        yield return new WaitForSeconds(5);

        //load scene
    }
}
