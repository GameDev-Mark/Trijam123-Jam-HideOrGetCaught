using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject nextLvlButton;

    // ontriggerenter
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nextLvlButton.SetActive(true);
            Time.timeScale = 0.1f;
        }
    }
}
