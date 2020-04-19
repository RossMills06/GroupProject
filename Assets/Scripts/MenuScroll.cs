using UnityEngine;

public class MenuScroll : MonoBehaviour
{
    public float horizontalSpeed;

    Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-Vector2.left.x * Time.deltaTime * horizontalSpeed, 0, 0);
    }
}
