using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogoFloat : MonoBehaviour {

    public float height, speed;
    Vector2 startPos, tempPos;

    void Start()
    {
        // Starting position
        startPos = transform.position;
    }

    void FixedUpdate () {
        // Reset to Original
        tempPos = startPos;

        // Calculates Sin through (Time * PI * Speed) * Height
        // Oscillate between -1 and 1 for:
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * speed) * height;  

        //Debug.Log(tempPos.y);

        // Apply changes
        transform.position = tempPos;
    }
}
