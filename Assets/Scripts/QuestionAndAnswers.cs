using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Questions and Answers template for quizmanager. 
/// author - @Bernhard / last modified - October 1st, 2023
/// </summary>
[System.Serializable]
public class QuestionAndAnswers
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;
}