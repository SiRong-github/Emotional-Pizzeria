using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Implements scoring motion on the board (top left). 
/// author - @Jiwon / last modified - October 21st, 2023
/// </summary>
public class ScoreScript : MonoBehaviour
{ 

    [Header("Number incrementing effect")]
    public int CountFPS = 30; 
    public float Duration = 1f; 
    private Coroutine CountingCoroutine; 
    private static int prevScore = 0; 
    private static int currScore; 

    [SerializeField] private TMP_Text tmp;
    [SerializeField] private AudioSource cashierSound;


    void Start()
    {
        currScore = prevScore;
        tmp.text = currScore.ToString(); 
    }

    // Resets the current score, mainly called for back to main menu 
    public static void resetScore()
    {
        currScore = 0;
        prevScore = 0;
    }

    // for storing initial score when replay button is chosen
    public static void saveScore()
    {
        prevScore = currScore;
    }
    
    // increments the score and changes the scoreboard 
    public void IncrementScoreBy(int by) 
    {
        // sound effect
        cashierSound.Play();

        // calls number incrementing effect 
        UpdateText(currScore + by);
        currScore += by;

        // add to database 
        // modified by - @Bernhard
        Database db = GetComponent<Database>();
        db.AddHearts(by);
    }

    // number incrementing effect
    private void UpdateText(int newScore) 
    {
        if (CountingCoroutine != null) 
        {
            StopCoroutine(CountingCoroutine);
        }
        CountingCoroutine = StartCoroutine(CountText(newScore));
    }

    private IEnumerator CountText(int newScore) 
    {
        // to delay animation
        WaitForSecondsRealtime Wait = new WaitForSecondsRealtime(1f/CountFPS);
        int previousValue = currScore; 
        int stepAmount; 

        stepAmount = 1;

        // will mainly satisfy this condition (always increment)
        if (previousValue < newScore)
        {
            
            while (previousValue < newScore)
            {
                previousValue += stepAmount; 
                if (previousValue > newScore)
                {
                    previousValue = newScore;
                }
                tmp.text = previousValue.ToString();
                yield return Wait; 
            }
            
            
        }
        // for edge case handling 
        else 
        {
            while (previousValue > newScore)
            {
                previousValue += stepAmount; 
                if (previousValue < newScore)
                {
                    previousValue = newScore;
                }
                tmp.text = previousValue.ToString();
                yield return Wait; 
            }
            
            
        }
    }
}
