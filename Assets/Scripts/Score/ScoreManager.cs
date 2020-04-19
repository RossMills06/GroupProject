using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for determining Score

// To Use:
//  -   Include the ScoreManager Prefab in your level.
//  -   Reference this Script in another when you want to increase score or show rank at end of the level 
//      from that other script.
//  -   Choose the score you need to achieve for each rank.
//  -   Increment 'int totalScore' by one (totalScore++) in your scripts.
//  -   When level is complete, change 'finished' to true in the other script using the reference (sm.finished = true;).
//  -   Select which levelIndex you'd like to load next and the wait time.

public class ScoreManager : MonoBehaviour {

    // NOTE: Don't change these default references in editor.
    public GameObject first, twoOne, twoTwo, third;
    private AudioSource source;
    private static float endScore;

    public int totalScore, firstScore, twoOneScore, twoTwoScore, thirdScore;
    public float levelChangeTimer;
    public bool finished = false;

    // NOTE: Don't change this variable.
    private int levelIndex = 0;

    void Start () {
        source = GetComponent<AudioSource>();

        totalScore = 0;
	}
	
    // Show Rank then change level after seconds
	void Update () {
        if (finished)
        {
            ShowRank();
            Invoke("PlaySound", 0.1f);
            Invoke("ChangeLevel", levelChangeTimer);
        }
	}

    // Instantiates Score based on end totalScore
    void ShowRank()
    {
        if (totalScore >= firstScore)
        {
            Instantiate(first);
        }
        if (totalScore >= twoOneScore && totalScore < firstScore)
        {
            Instantiate(twoOne);
        }
        if (totalScore >= twoTwoScore && totalScore < twoOneScore)
        {
            Instantiate(twoTwo);
        }
        if (totalScore <= thirdScore || totalScore < twoTwoScore)
        {
            Instantiate(third);
        }

        endScore += totalScore;

        finished = false;
    }

    // Score given at the end of the game
    public void EndScore()
    {
        // Total Score: 43 / 4 = 10.75
        endScore /= 4f;

        if (endScore >= 8f)
        {
            Instantiate(first);
        }
        if (endScore >= 6f && endScore < 8f)
        {
            Instantiate(twoOne);
        }
        if (endScore >= 4f && endScore < 6f)
        {
            Instantiate(twoTwo);
        }
        if (endScore <= 2f || endScore < 4f)
        {
            Instantiate(third);
        }
    }

    // Changes Level to Transition
    void ChangeLevel()
    {
        SceneManager.LoadScene(levelIndex);
    }

    void PlaySound()
    {
        source.Play();
    }
}
