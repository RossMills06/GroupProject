using UnityEngine;

public class PlayerControllerRunner : MonoBehaviour
{
    public float speed;

    private float inputDirection;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputDirection = Input.GetAxis("Horizontal");

        transform.Translate(inputDirection * Time.deltaTime * speed, 0, 0);
        Debug.Log(inputDirection);
    }
}