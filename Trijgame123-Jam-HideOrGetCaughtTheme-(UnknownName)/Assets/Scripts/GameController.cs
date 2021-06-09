using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Transform playerStartSpawn; // player starting position

    public GameObject player; // player itself
    public GameObject nextLvlButton; // button for next level
    public GameObject[] levels; // array of the levels

    public TMP_Text levelText; // level text UI

    float levelCounter; // counts the levels

    // unitys start function
    private void Start()
    {
        levelCounter = 1f;
    }

    // unitys update function
    void Update()
    {
        levelText.text = "Level : " + levelCounter;

        if (Time.timeScale <= 0.1f)
        {
            // TODO : restart level
            Debug.Log("caught");
        }
    
        if(levelCounter == 2) // lvl 2
        {
            levels[0].SetActive(false); // despawn level 1
            levels[1].SetActive(true); // spawn level 2
        }
        if(levelCounter == 3) // lvl 3
        {
            levels[1].SetActive(false); // despawn level 2
            levels[2].SetActive(true); // spawn level 3
        }
        if (levelCounter == 4) // lvl 4
        {
            levels[2].SetActive(false); // despawn level 3
            levels[3].SetActive(true); // spawn level 4
        }
    }

    // attached to the next level button , brings player back to the starting position
    public void NextLevelButton()
    {
        levelCounter++;
        Time.timeScale = 1f;
        nextLvlButton.SetActive(false);
        player.transform.position = playerStartSpawn.transform.position;
    }
}
