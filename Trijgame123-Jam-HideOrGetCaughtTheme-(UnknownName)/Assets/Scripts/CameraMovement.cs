using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 startPostion;
    public Transform playerPos;

    Quaternion startRotation;

    // unitys lateupdate function
    void Update()
    {
        startPostion = new Vector3(playerPos.position.x, playerPos.position.y + 10f, playerPos.position.z);
        transform.position = startPostion;

        startRotation = Quaternion.Euler(90f, 0f, 0f);
        transform.rotation = startRotation;
    }
}