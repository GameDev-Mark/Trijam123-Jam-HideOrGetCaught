using UnityEngine;

public class LastLevelWin : MonoBehaviour
{
    public GameController gameConScript;

    public GameObject nextLvlButton;
    public GameObject endingUI;

    public AudioSource winGameSFX;
    public AudioSource enemyEntersSFX;
    public AudioSource enemyExitsSFX;

    // ontriggerenter, level level ending
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameConScript.levelCounter == 4)
            {
                nextLvlButton.SetActive(false);
                endingUI.SetActive(true);

                Time.timeScale = 0f;

                winGameSFX.Play();
                enemyEntersSFX.Stop();
                enemyExitsSFX.Stop();
            }
        }
    }
}