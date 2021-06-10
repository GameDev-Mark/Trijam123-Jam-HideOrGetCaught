using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform[] playerStartSpawn; // player starting position

    public GameObject player; // player itself
    public GameObject nextLvlButton; // button for next level
    public GameObject[] levels; // array of the levels
    public GameObject restartUI; // restart buton/text UI
    public GameObject levelOneText; // texts for level 1
    public GameObject levelTwoText; // texts for level 2

    public TMP_Text levelCountText; // level text UI

    float levelCounter; // counts the levels
    float timerStopTimeScale; // timer countdown for stopping timeScale (slow mo)
    float timerTurnOffTexts; // timer for UI texts

    bool _playerCanSpawn; // if false, player can move from new start position

    // unitys start function
    void Start()
    {
        levelCounter = 1f;
        timerStopTimeScale = 0.3f;
        timerTurnOffTexts = 3f;

        levelOneText.SetActive(true); // activate level 1 text
        player.transform.position = playerStartSpawn[0].position; // spawn player at the start
    }

    // unitys update function
    void Update()
    {
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

        // -------
        if(levelCounter == 2 && _playerCanSpawn == true) // lvl 2
        {
            player.transform.position = playerStartSpawn[1].position; // new player position
            levelTwoText.SetActive(true);
            levels[0].SetActive(false); // despawn level 1
            levels[1].SetActive(true); // spawn level 2
            _playerCanSpawn = false; // if false, player can move from new start position
        }
        if(levelCounter == 3 && _playerCanSpawn == true) // lvl 3
        {
            player.transform.position = playerStartSpawn[2].position; // new player position
            levels[1].SetActive(false); // despawn level 2
            levels[2].SetActive(true); // spawn level 3
            _playerCanSpawn = false; // if false, player can move from new start position
        }
        if (levelCounter == 4 && _playerCanSpawn == true) // lvl 4
        {
            player.transform.position = playerStartSpawn[4].position; // new player position
            levels[2].SetActive(false); // despawn level 3
            levels[3].SetActive(true); // spawn level 4
            _playerCanSpawn = false; // if false, player can move from new start position
        }

        // ------
        if(levelOneText.activeInHierarchy || levelTwoText.activeInHierarchy)
        {
            timerTurnOffTexts -= Time.deltaTime;
        }
        if (timerTurnOffTexts <= 0f)
        {
            timerTurnOffTexts = 3f;
            levelOneText.SetActive(false);
            levelTwoText.SetActive(false);
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
        SceneManager.LoadScene(0);
    }

    // quits game
    void QuitGame()
    {
        Application.Quit();
    }
}