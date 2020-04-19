using UnityEngine;

public class Finish : MonoBehaviour
{
    public float speed;

    private PlayerController pc;
    private GameController gc;
    private AudioSource soundFx;

    public Transform target;

    // Use this for initialization
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        soundFx = GetComponent<AudioSource>();
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pc.GetComponent<Rigidbody2D>().gravityScale = 0;
            pc.horizontalSpeed = 0;
            gc.complete = true;
            gc.rank = true;
            soundFx.Play();
            pc.enabled = false;
        }
    }
}
