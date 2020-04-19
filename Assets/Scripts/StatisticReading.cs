using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO; 

public class StatisticReading : MonoBehaviour {

    public Text txtString;
    private static int levelIndex = 0;

	// Use this for initialization
	void Start () {

        string path = "Assets/TextFiles/Statistics.txt";

        string[] txt = File.ReadAllLines(path);

        int rndNum = Random.Range(0, txt.Length);

        txtString.text = txt[rndNum];

        Invoke("NextLevel", 5.0f);
    }

    void NextLevel()
    {
            levelIndex++;
            Debug.Log(levelIndex);
            SceneManager.LoadScene(levelIndex);
    }
}
