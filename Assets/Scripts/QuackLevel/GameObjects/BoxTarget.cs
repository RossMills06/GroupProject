using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTarget : MonoBehaviour {

    public ScoreManager sm;
    public ArrowManager am;
    private int counter;

	// Use this for initialization
	void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        // If all arrows have passed...
        if(counter == 25)
        {
            // Show rank
            sm.finished = true;
            counter = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        counter++;
    }

    // When Arrows are in the target...
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "UP")
        {
            //...and the correct button is pressed...
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //...Destroy that arrow
                Debug.Log("Destroy Up Arrow");
                Destroy(other.gameObject);
                sm.totalScore++;
                counter++;
            }
        }
        if (other.gameObject.tag == "DOWN")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Destroy Down Arrow");
                Destroy(other.gameObject);
                sm.totalScore++;
                counter++;
            }
        }
        if (other.gameObject.tag == "LEFT")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Destroy Left Arrow");
                Destroy(other.gameObject);
                sm.totalScore++;
                counter++;
            }
        }
        if (other.gameObject.tag == "RIGHT")
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Destroy Right Arrow");
                Destroy(other.gameObject);
                sm.totalScore++;
                counter++;
            }
        }
    }
}