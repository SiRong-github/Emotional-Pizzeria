using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the level runthrough by calling customers.
/// author - @Shanaia / last modified - September 23rd, 2023
/// </summary>
public class Level : MonoBehaviour
{
    [SerializeField] int maxCustomers;
    [SerializeField] GameObject endLevel;
    int totalScore = 0;
    Transform quizManager;
    GameObject customer;

    void Start()
    {
        endLevel.SetActive(false);
        GetComponent<Spawner>().HasNextCustomer();
    }

    void Update()
    {

        // Time to go to next level 
        if (totalScore == maxCustomers)
        {
            GetComponent<Spawner>().HasNoCustomer();
            if (GetComponent<Spawner>().customerOutStopped())
            {
                endLevel.SetActive(true);
            }
        }

        // Time to go to next customer 
        customer = GetComponent<Spawner>().GetCurrentCustomer();
        quizManager = customer.transform.GetChild(4);
        if (quizManager.GetComponent<QuizManager>().GetScore() == 1)
        {
            totalScore++;
            GetComponent<Spawner>().HasNextCustomer();
        }
    }

    // Retry button 
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    // Calling level 2
    public void NextLevel2()
    {
        SceneManager.LoadScene("Level 2");
        ScoreScript.saveScore();
    }

    // Calling level 3
    public void NextLevel3()
    {
        SceneManager.LoadScene("Level 3");
        ScoreScript.saveScore();
    }

    // Finish level 3
    public void FinishGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
