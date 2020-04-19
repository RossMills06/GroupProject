using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerRoom : MonoBehaviour
{
	public float timer;
	public Text timerText;

	public Text startText;
    public Text display;
	string[] startArray = new string[] { "Lab 1", "Lab 2", "Lab 3", "Lab 4", "Lecture Room 1", "Lecture Room 2", "Lecture Room 3"};
	private int startTextIndex;

    public int roomCount;
    public int maxRoomCount;
    public float displayCount;
    private float displayCountStart;
    private float endTimer;

    public AudioClip clip;
    public AudioClip fail;
    public AudioClip win;
    private AudioSource source;

	public float speed;

	private Rigidbody2D rb2d;

	private Vector2 vel = Vector2.zero;

    public bool complete;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
		timerText.text = "";
		setTimerText();

		startTextIndex = (int)Random.Range(0, 7);
		setStartText();
        displayCountStart = displayCount;

        roomCount = 0;
        complete = false;
        endTimer = 3.0f;
    }

	void FixedUpdate()
	{
        if (!complete)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                vel = new Vector2(-speed, 0);
                rb2d.MovePosition(rb2d.position + vel * Time.fixedDeltaTime);
                //apply the velcoity in the direction left
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                vel = new Vector2(speed, 0);
                rb2d.MovePosition(rb2d.position + vel * Time.fixedDeltaTime);
                //apply the velcoity in the direction right
            }

            if (timer >= 0.0f)
            {
                timer -= Time.deltaTime;
                displayCount -= Time.deltaTime;

                setTimerText();
            }

            if (displayCount <= 0.0f)
            {
                startText.text = "";
            }
        }


        if (complete)
        {
            endTimer -= Time.deltaTime;
            startText.text = "All rooms found";
            display.text = "\nRooms " + roomCount + "/" + maxRoomCount;
            if (endTimer <= 0.0f)
            {
                SceneManager.LoadScene(0);
            }
        }
	}

	void setTimerText()
	{
		timerText.text = ((int)timer).ToString() + " seconds";
	}

	void setStartText()
	{
		startText.text = "Find: " + startArray[startTextIndex] + "\nPress space on the correct room\nUse the lift by pressing up or down";
        display.text = "Find: " + startArray[startTextIndex] + "\nRooms " + roomCount + "/" + maxRoomCount;
    }

    void setText()
    {
        startText.text = "Find: " + startArray[startTextIndex] + "\nYou need to attend all your\nworkshops and lectures";
        display.text = "Find: " + startArray[startTextIndex] + "\nRooms " + roomCount + "/" + maxRoomCount;
    }

    void OnTriggerStay2D(Collider2D other)
	{
        if (!complete)
        {
            if (other.gameObject.tag == startArray[startTextIndex])
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (roomCount < maxRoomCount)
                    {
                        startTextIndex = (int)Random.Range(0, 7);
                        roomCount++;
                        setText();
                        displayCount = displayCountStart;
                        source.PlayOneShot(clip);
                    }

                    if (roomCount == maxRoomCount)
                    {
                        complete = true;
                        source.PlayOneShot(win);
                    }
                }
            }
            else if (other.gameObject.tag != startArray[startTextIndex])
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    source.PlayOneShot(fail);
                }
            }
        }
	}
}
