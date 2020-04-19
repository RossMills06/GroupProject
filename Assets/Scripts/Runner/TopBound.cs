using UnityEngine;

public class TopBound : MonoBehaviour
{
    public GameObject player;

    private Player playerController;

    // Use this for initialization
    void Start()
    {
        playerController = player.GetComponent<Player>();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!playerController.grounded)
            {
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!playerController.grounded)
            {
                GetComponent<Collider2D>().enabled = true;
            }
        }
    }
}
