using UnityEngine;

public class PlayerController : MonoBehaviour
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

    public AudioSource soundFx;
    public AudioClip jump;
    public AudioClip updown;

    Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        grounded = true;
        rb2d = GetComponent<Rigidbody2D>();
        soundFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-Vector2.left.x * Time.deltaTime * horizontalSpeed, 0, 0);

        if (Input.GetKeyDown(KeyCode.UpArrow) && !moveDown)
        {
            soundFx.PlayOneShot(updown);
            moveUp = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !moveUp)
        {
            soundFx.PlayOneShot(updown);
            moveDown = true;
        }

        if (moveUp && grounded)
        {
            float step = verticalSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, toptarget.position, step);

            if (transform.position.y == toptarget.position.y)
            {
                startPos = toptarget.position.y;
                moveUp = false;
            }

        }

        if (moveDown && grounded)
        {
            float step = verticalSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, bottomtarget.position, step);

            if (transform.position.y == bottomtarget.position.y)
            {
                startPos = bottomtarget.position.y;
                moveDown = false;
            }
        }

        if (!grounded)
        {
            if (transform.position.y <= startPos)
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
                soundFx.PlayOneShot(jump);
                grounded = false;
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                startPos = transform.position.y + 0.125f;
            }
        }
    }
}
