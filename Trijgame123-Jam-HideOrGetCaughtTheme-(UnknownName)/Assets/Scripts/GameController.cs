using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Space(20)]
    public Transform[] playerStartSpawn; // player starting position

    [Space(20)]
    public GameObject[] levels; // array of the levels

    [Header("")]
    public GameObject player; // player itself
    [Space(10)]
    public GameObject nextLvlButton; // button for next level
    [Space(10)]
    public GameObject restartUI; // restart buton/text UI
    [Space(10)]
    public GameObject endGameUI; // pop up for when player finishes game

    [Header("")]
    public GameObject levelOneText; // texts for level 1
    public GameObject levelTwoText; // texts for level 2
    public GameObject levelThreeText; // texts for level 3
    public GameObject levelFourText; // texts for level 4

    [Space(10)]
    public TMP_Text levelCountText; // level text UI

    [Space(10)]
    public AudioClip playerCaughtClipSFX;
    public AudioSource playerCaughtSFX;
    public AudioSource enemyExitSFX;
    public AudioSource enemyNearSFX;

    [HideInInspector] public float levelCounter; // counts the levels
    float timerStopTimeScale; // timer countdown for stopping timeScale (slow mo)
    float timerTurnOffTexts; // timer for UI texts

    bool _playerCanSpawn = true; // if false, player can move from new start position

    // unitys start function
    void Start()
    {
        levelCounter = 1f;
        timerStopTimeScale = 0.3f;
        timerTurnOffTexts = 3f;
        Time.timeScale = 1f;
    }

    // unitys update function
    void Update()
    {
        //------
        QuitGame();

        //----
        levelCountText.text = "Level : " + levelCounter;

        // -----
        if (Time.timeScale == 0.1f)
        {
            // TODO : restart level
            restartUI.SetActive(true);
            timerStopTimeScale -= Time.deltaTime;
        }
        if(timerStopTimeScale <= 0f)
        {
            Time.timeScale = 0f;
            timerStopTimeScale = 0.3f;
            Debug.Log("time scale");
        }

        if(restartUI.activeInHierarchy) // plays music when caught
        {
            playerCaughtSFX.PlayOneShot(playerCaughtClipSFX, 0.4f);
            enemyExitSFX.Stop();
            enemyNearSFX.Stop();
        }

        // -------
        if (levelCounter == 1f && _playerCanSpawn == true)
        {
            levelOneText.SetActive(true); // activate level 1 text
            player.transform.position = playerStartSpawn[0].position; // spawn player at the start
            _playerCanSpawn = false;
        }
        if (levelCounter == 2f && _playerCanSpawn == true) // lvl 2
        {
            player.transform.position = playerStartSpawn[1].position; // new player position
            levelTwoText.SetActive(true);
            levels[0].SetActive(false); // despawn level 1
            levels[1].SetActive(true); // spawn level 2
            _playerCanSpawn = false; // if false, player can move from new start position
        }
        if(levelCounter == 3f && _playerCanSpawn == true) // lvl 3
        {
            player.transform.position = playerStartSpawn[2].position; // new player position
            levelThreeText.SetActive(true);
            levels[1].SetActive(false); // despawn level 2
            levels[2].SetActive(true); // spawn level 3
            _playerCanSpawn = false; // if false, player can move from new start position
        }
        if (levelCounter == 4f && _playerCanSpawn == true) // lvl 4
        {
            player.transform.position = playerStartSpawn[3].position; // new player position
            levelFourText.SetActive(true);
            levels[2].SetActive(false); // despawn level 3
            levels[3].SetActive(true); // spawn level 4
            _playerCanSpawn = false; // if false, player can move from new start position
        }

        // ------
        if (levelOneText.activeInHierarchy || levelTwoText.activeInHierarchy || levelThreeText.activeInHierarchy || levelFourText.activeInHierarchy)
        {
            timerTurnOffTexts -= Time.deltaTime;
        }
        if (timerTurnOffTexts <= 0f)
        {
            timerTurnOffTexts = 3f;
            levelOneText.SetActive(false);
            levelTwoText.SetActive(false);
            levelThreeText.SetActive(false);
            levelFourText.SetActive(false);
        }
    }

    // attached to the next level button , brings player back to the starting position
    public void NextLevelButton()
    {
        levelCounter++;
        Time.timeScale = 1f;
        _playerCanSpawn = true;
        nextLvlButton.SetActive(false);
    }

    // attached to the restart button , brings player back to the start
    public void RestartButton()
    {
        levelCounter = 1f;
        Time.timeScale = 1f;
        restartUI.SetActive(false);
        SceneManager.LoadScene(0);
        Debug.Log("load");
    }

    // quits game when player preseses escape key
    void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // attached to the quit button
    public void QuitGameButton()
    {
        Application.Quit();
    }

    // attached to the play again button, restarts game
    public void PlayAgainButton()
    {
        endGameUI.SetActive(false);
        SceneManager.LoadScene(0);
    }
}