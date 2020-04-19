using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float startPos;
    public float jumpForce;

    public Transform toptarget;
    public Transform bottomtarget;

    public bool grounded;
    public bool moveUp;
    public bool moveDown;

    Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        grounded = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-Vector2.left.x * Time.deltaTime * horizontalSpeed, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow) && !moveDown) moveUp = true;
        if (Input.GetKey(KeyCode.DownArrow) && !moveUp) moveDown = true;

        if (moveUp && grounded)
        {
            float step = verticalSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, toptarget.position, step);

            if (transform.position.y > -0.1f)
            {
                startPos = -0.1f;
                moveUp = false;
            }

        }

        if (moveDown && grounded)
        {
            float step = verticalSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, bottomtarget.position, step);

            if (transform.position.y < -3.7f)
            {
                startPos = -3.7f;
                moveDown = false;
            }
        }

        if (!grounded)
        {
            if (transform.position.y < startPos)
            {
                rb2d.velocity = new Vector2(0, 0);
                rb2d.angularVelocity = 0;
                grounded = true;
                moveUp = false;
                moveDown = false;
            }
            rb2d.gravityScale = 3;
        }

        if (grounded && !moveUp && !moveDown)
        {
            rb2d.gravityScale = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                grounded = false;
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                startPos = transform.position.y;
            }
        }
    }
}
