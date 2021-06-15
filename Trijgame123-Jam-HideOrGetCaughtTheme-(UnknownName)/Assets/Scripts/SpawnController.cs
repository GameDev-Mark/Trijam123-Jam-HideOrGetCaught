using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject nextLvlButton;
    public AudioSource winGameSFX;
 
    // ontriggerenter
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nextLvlButton.SetActive(true);
            Time.timeScale = 0.2f;
        }
    }
}