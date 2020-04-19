using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowManager : MonoBehaviour
{
    // Getting the Arrow Prefabs
    public Transform arrowLeft, arrowRight, arrowUp, arrowDown;
    public float setTimer = 2f;         // Resetting the Timer
    public int arrowAmount = 10;        // Number of Arrows to Instantiate

    private float timer;                // Timer used to space out Instantiation
    private bool dance = true;          // Arrow Instantiation bool

    // Called every frame
    void Update()
    {
        if (dance)
        {
            timer -= Time.deltaTime;    // Reduces timer by real-time
            if (timer <= 0)             // Controls Arrow creation
            {
                CreateArrow();
                timer = setTimer;       // Resets timer
            }

            if (arrowAmount <= 0)       // Stops arrow creation loop
            {
                dance = false;
            }
        }
    }

    // Instantiates Arrows by arrowAmount
    void CreateArrow()
    {
        // Random Number 1 - 4
        switch (Random.Range(1, 4))
        {
            case 1:
                // Instantiate based on result
                Instantiate(arrowLeft);
                arrowAmount--;
                break;
            case 2:
                Instantiate(arrowRight);
                arrowAmount--;
                break;
            case 3:
                Instantiate(arrowUp);
                arrowAmount--;
                break;
            case 4:
                Instantiate(arrowDown);
                arrowAmount--;
                break;
            default:
                Debug.Log("Random number generation unsucessful.");
                break;
        }

        //Debug.Log(arrowAmount);
    }
}

