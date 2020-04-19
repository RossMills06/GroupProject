using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorContoller : MonoBehaviour 
{
	private int index;

	// Use this for initialization
	void Start()
	{
		index = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			if (Input.GetKeyDown (KeyCode.UpArrow)) 
			{
				Debug.Log ("up pressed");

				if (index < 3) 
				{
					other.gameObject.transform.Translate (new Vector3 (0.0f, 2.5f, 0.0f));
                    index++;
					Debug.Log (index);
				}
			}
			else if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				Debug.Log ("down pressed");

				if (index > 0) 
				{
					other.gameObject.transform.Translate(new Vector3 (0.0f, -2.0f, 0.0f));
                    index--;
					Debug.Log (index);
				}

			}
        }
	}
}

