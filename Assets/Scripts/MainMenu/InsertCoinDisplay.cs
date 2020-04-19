using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertCoinDisplay : MonoBehaviour {

    public SpriteRenderer sr;
    public Animator anim;
    public GameObject canvas;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        //Hide 'Insert Coin' and show 'Menu'
        if(Input.anyKeyDown)
        {
            sr.enabled = false;
            anim.enabled = false;
            canvas.SetActive(true);
        }
	}
}
