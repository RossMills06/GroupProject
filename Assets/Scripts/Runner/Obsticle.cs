using UnityEngine;

public class Obsticle : MonoBehaviour
{
    public AudioSource soundFx;

    // Use this for initialization
    void Start()
    {
        soundFx = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundFx.Play();
        }
    }
}
