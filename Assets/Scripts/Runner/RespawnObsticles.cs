using UnityEngine;

public class RespawnObsticles : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obsticle")
        {
            Destroy(collision.gameObject);
        }
    }
}
