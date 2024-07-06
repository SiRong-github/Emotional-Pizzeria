using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Pause button implementation - should stop music, levels
/// author - @Shanaia / last modified - September 8th, 2023
/// </summary>
public class PauseMenuHandler : MonoBehaviour
{
    public static bool gamePaused = false;
    [SerializeField] GameObject level;

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Handle);
    }

    void Awake()
    {
        gamePaused = false; 
        ResumeGame();
    }

    // Changes the state of the game (pause / resume)
    void Handle()
    {
        if (gamePaused)
        {
            ResumeGame();
            gamePaused = false;
        }
        else
        {
            PauseGame();
            gamePaused = true;
        }
    } 

    private void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true; 
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void ReturnToMenu()
    {
        level.GetComponent<Spawner>().RemoveCurrCustomer();
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

}
