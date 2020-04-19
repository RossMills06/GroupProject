using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public InsertCoinDisplay insertCoin;
    public float startTime;
    public Text[] menuItems;
    public AudioClip bleep;
    public AudioClip select;

    private AudioSource source;

    private float timer;
    private int i = 0;

	// Use this for initialization
	void Start () {

        timer = startTime;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        // Player Input
        PlayerInput();

        menuItems[i].color = Color.red;

        // Show 'Insert Coin'
        if(timer <= 0.0f)
        {
            insertCoin.sr.enabled = true;
            insertCoin.anim.enabled = true;
            insertCoin.canvas.SetActive(false);
            timer = startTime;
            this.gameObject.SetActive(false);
        }
	}

    // Input Processing
    void PlayerInput()
    {
        // Menu Item Movement
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            menuItems[i].color = Color.white;
            i = 0;
            timer = startTime;
            source.PlayOneShot(bleep);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            menuItems[i].color = Color.white;
            i = 1;
            timer = startTime;
            source.PlayOneShot(bleep);
        }

        // Menu Selecting
        switch (i)
        {
            // Singleplayer
            case 0:
                if (Input.GetKeyDown(KeyCode.Return))
                {
<<<<<<< HEAD
                    StartCoroutine(LoadScene());
=======
                    SceneManager.LoadScene(0);
>>>>>>> origin/master
                }
                break;
            // Multiplayer
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    StartCoroutine(LoadScene());
                }
                break;
        }
    }

    IEnumerator LoadScene()
    {
        source.PlayOneShot(select);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
