using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource enemyExitsSFX; // when player moves play this sfx
    public AudioSource enemyEntersSFX; // when player stops moving plays this sfx

    // OnTriggerEnter, play audio when enemy enters
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyEntersSFX.Play();
            enemyExitsSFX.Stop();
        }
    }

    // onTriggerExit, stop the music when enemy exits
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyExitsSFX.Play();
            enemyEntersSFX.Stop();
        }
    }
}