using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankToManager : MonoBehaviour {

    private Transform scoreManager;
	
	void Start() {

        scoreManager = GameObject.Find("ScoreManager").transform;

        this.transform.position = scoreManager.position;
		
	}

    void FixedUpdate()
    {
        this.transform.position = scoreManager.position;
    }
}
