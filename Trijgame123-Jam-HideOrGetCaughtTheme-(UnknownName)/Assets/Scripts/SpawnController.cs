using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // ontriggerenter
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // TODO : setactive UI text to next level
        }
    }
}
