using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Used to generate prompts for each customer. 
/// author - @Jiwon / last modified - October 18th, 2023
/// </summary>
public class QuizManager : MonoBehaviour
{
    
    public List<QuestionAndAnswers> QnA = new List<QuestionAndAnswers>();
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestionTxt;
    public AudioSource wrongAnswer;
    public AudioSource correctAnswer;

    [SerializeField] GameObject submitBtn; 
    [SerializeField] GameObject[] choices; 
    [SerializeField] private GameObject scoreManager; 
    [SerializeField] private GameObject scManager;
    [SerializeField] private GameObject[] qualityIcon;

    public GameObject QuizPanel;
    public TMP_Text ScoreTxt;
    int totalQuestions = 0;
    int score = 0;
    int wrongCount = 0;

    // load question 
    void Start() 
    {   
        totalQuestions = QnA.Count;
        GameObject[] sms = GameObject.FindGameObjectsWithTag("scoreManager");
        if (sms.Length > 0) scoreManager = sms[0];
        else Debug.Log("score manager not correctly assigned");
    }

    // score increment depends on number of guesses made before correct answer
    public void SubmitOrder()
    {
        score = 1;
        
        ScoreScript sc = scoreManager.GetComponent<ScoreScript>();
        sc.IncrementScoreBy(30 - 10*wrongCount);
        QuizPanel.SetActive(false);
    }

    // removes quetsion once answered and generates new question
    public void Correct()
    {
        // sound effect
        correctAnswer.Play();
        submitBtn.SetActive(true);

        for (int i = 0; i < choices.Length; i++) 
        {
            choices[i].GetComponent<Button>().interactable = false; 
        }
    }

    public void Wrong()
    {
        // sound effect
        wrongAnswer.Play();
        if (wrongCount < 3) {
            GameObject heartSprite = qualityIcon[wrongCount++];
            heartSprite.GetComponent<Image>().color = new Color(0,0,0,174);
        }
    }

    public int GetScore()
    {
        return score;
    }
}