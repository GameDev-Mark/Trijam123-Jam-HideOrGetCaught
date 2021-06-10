using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed; // forward and backwards move speed
    float sideMoveSpeed; // sideways move speed
    Rigidbody rb; // rigidbody player
    Vector3 trackingSpeed; // tracking speed of players movement

    // unitys start function
    void Start()
    {
        moveSpeed = 3f;
        sideMoveSpeed = 3f;
        rb = GetComponent<Rigidbody>();
        trackingSpeed = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // unitys fixedUpdate function
    void FixedUpdate()
    {
        float _FBmove = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 movement = new Vector3(0f, 0f, _FBmove);
        rb.AddForce(movement * moveSpeed);

        float _sideMove = Input.GetAxis("Horizontal");
        Vector3 sideMove = new Vector3(_sideMove, 0f, 0f);
        rb.AddForce(sideMove * sideMoveSpeed);
    }

    // unitys update function
    void Update()
    {
        if (rb.velocity.x > trackingSpeed.x || rb.velocity.y > trackingSpeed.y || rb.velocity.z > trackingSpeed.z)
        {
            Debug.Log("Tracking");
            // TODO : when player moves play faster music
        }
        if (rb.velocity.x <= trackingSpeed.x || rb.velocity.y <= trackingSpeed.y || rb.velocity.z <= trackingSpeed.z)
        {
            // TODO : when player stops moving play slow music
        }
    }
}