using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls buttons in main menu. 
/// author - @Shanaia / last modified - September 7th, 2023
/// </summary>
public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        string currScene = SceneManager.GetActiveScene().name;
    }

    /* Main Menu Options */

    public void StartGame()
    {
        ScoreScript.resetScore();
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        GameObject[] bgmObjects = GameObject.FindGameObjectsWithTag("bgm");
        foreach (GameObject bgmObject in bgmObjects)
        {
            Destroy(bgmObject);
        }
        Debug.Log("The game has started.");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
        Debug.Log("Instructions.");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
        Debug.Log("Settings.");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    /* Loading Other Scenes */
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Main menu");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Level 2");
        Debug.Log("The game has started.");
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene("Level 3");
        Debug.Log("The game has started.");
    }

    public void LoadSummary()
    {
        SceneManager.LoadScene("Summary");
        Debug.Log("The game has ended.");
    }
}
