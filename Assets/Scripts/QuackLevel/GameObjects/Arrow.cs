using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    Rigidbody2D rb;

    public float arrowSpeed = 10f;
    bool up, down, left, right;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        // Get which Arrow this is...
        switch(this.gameObject.tag)
        {
            case "UP":
                up = true;
                break;
            case "DOWN":
                down = true;
                break;
            case "LEFT":
                left = true;
                break;
            case "RIGHT":
                right = true;
                break;
            default:
                Debug.Log("No predefined arrow tag assigned to this gameObject!");
                break;
        }
    }

    // Called every Physics step
    void FixedUpdate()
    {
        // Moves Arrow right with real-time by the arrowSpeed
        rb.transform.Translate((Vector3.right * Time.fixedDeltaTime) * arrowSpeed);
    }
}