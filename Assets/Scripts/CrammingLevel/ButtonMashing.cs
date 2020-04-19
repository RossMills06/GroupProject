using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMashing : MonoBehaviour
{
    public int counter;
    public bool keyDown;
    public bool gameWin;
    public bool gameLose;
    public Slider timeLeftSlider;
    public int amountKeyPresses;
    public int amountKeyPressesMax;
    public Slider keyPresses;
    public int numberOfKeys;
    int[] listOfKeys;
    public Text winText;
    public Image up;
    public Image down;
    public Image left;
    public Image right;
    public Image up2;
    public Image down2;
    public Image left2;
    public Image right2;
    public ScoreManager score;
    public float timeLeft = 30.0f;
    // Use this for initialization
    void Start()
    {
        amountKeyPressesMax = 20;
        amountKeyPresses = 0;
        numberOfKeys = 10;
        keyPresses.maxValue = amountKeyPressesMax;
        timeLeftSlider.maxValue = timeLeft;
        timeLeftSlider.value = timeLeft;
        listOfKeys = new int[numberOfKeys];
        winText.text = "";
        counter = 0;
        keyDown = false;
        gameWin = false;
        gameLose = false;
        for (int x = 0; x < numberOfKeys; x++)
        {
            listOfKeys[x] = Random.Range(0, 4);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < numberOfKeys && gameWin == false)
        {
            if (listOfKeys[counter] == 0)
            {
                right.enabled = true;
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    amountKeyPresses += 1;
                }
            }
            else if (listOfKeys[counter] == 1)
            {
                down.enabled = true;
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    amountKeyPresses += 1;
                }
            }
            else if (listOfKeys[counter] == 2)
            {
                left.enabled = true;
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    amountKeyPresses += 1;
                }
            }
            else if (listOfKeys[counter] == 3)
            {
                up.enabled = true;
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    amountKeyPresses += 1;
                }
            }
            if (amountKeyPresses == amountKeyPressesMax)
            {
                right.enabled = false;
                left.enabled = false;
                down.enabled = false;
                up.enabled = false;
                amountKeyPresses = 0;
                counter += 1;
                score.totalScore++;
            }
            if (!(counter >= numberOfKeys-1))
            {
                if (listOfKeys[counter + 1] == 0)
                {
                    right2.enabled = true;
                    left2.enabled = false;
                    down2.enabled = false;
                    up2.enabled = false;
                }
                else if (listOfKeys[counter + 1] == 1)
                {
                    right2.enabled = false;
                    left2.enabled = false;
                    down2.enabled = true;
                    up2.enabled = false;
                }
                else if (listOfKeys[counter + 1] == 2)
                {
                    right2.enabled = false;
                    left2.enabled = true;
                    down2.enabled = false;
                    up2.enabled = false;
                }
                else if (listOfKeys[counter + 1] == 3)
                {
                    right2.enabled = false;
                    left2.enabled = false;
                    down2.enabled = false;
                    up2.enabled = true;
                }
            }
            else
            {
                right2.enabled = false;
                left2.enabled = false;
                down2.enabled = false;
                up2.enabled = false;

            }

        }
        if (timeLeft < 0 && gameWin == false) 
        {
            right2.enabled = false;
            left2.enabled = false;
            down2.enabled = false;
            up2.enabled = false;
            right.enabled = false;
            left.enabled = false;
            down.enabled = false;
            up.enabled = false;
            gameWin = true;
            score.finished = true;
            if (score.totalScore >= 3)
            {
                winText.text = "You Win!";
            }
            else
            {
                winText.text = "You Lose :(";
            }

        }
        else if (gameWin == false)
        {
            timeLeft -= Time.deltaTime;
        }

        timeLeftSlider.value = timeLeft;
        keyPresses.value = amountKeyPresses;
    }
}
