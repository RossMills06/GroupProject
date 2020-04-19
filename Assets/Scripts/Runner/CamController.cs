using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
    }
}