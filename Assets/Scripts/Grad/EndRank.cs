using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRank : MonoBehaviour {

    public ScoreManager sm;

	// Use this for initialization
	void Start () {
        sm.EndScore();
	}
}
