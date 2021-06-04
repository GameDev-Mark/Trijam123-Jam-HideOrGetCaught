using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed;
    float sideMoveSpeed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3f;
        sideMoveSpeed = 3f;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float _FBmove = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 movement = new Vector3(0f, 0f, _FBmove);
        rb.AddForce(movement * moveSpeed);

        float _sideMove = Input.GetAxis("Horizontal");
        Vector3 sideMove = new Vector3(_sideMove, 0f, 0f);
        rb.AddForce(sideMove * sideMoveSpeed);
    }
}
