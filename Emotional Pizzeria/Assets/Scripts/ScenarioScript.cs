using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using System;
using System.IO;
using System.Linq;

/// <summary>
/// Used to generate prompts for each customer. 
/// author - @Jiwon / modified by - @Shanaia / last modified - October 1st, 2023
/// </summary>
public class ScenarioScript : MonoBehaviour
{

    [SerializeField] private GameObject ExpObject;
    [SerializeField] public TextAsset emotionsJSON;
    public static string exp;
    public static string text;

    public EmotionList emotionList = new EmotionList();
    public Emotion chosenEmotion;

    /// <summary>
    /// This class stores the data for a single emotion
    /// </summary>
    [System.Serializable]
    public class Emotion
    {
        public string name;
        public string[] incorrect;
        public string sprite;
        public int difficulty;
        public string[] scenarios;
    }

    /// <summary>
    /// This class stores the data for a list of emotions
    /// </summary>
    [System.Serializable]
    public class EmotionList
    {
        public Emotion[] emotions;
    }

    // Parse data from json file and allocates each data into datafields 
    public Emotion getChosenEmotion()
    {
        // Read in the emotions.json file, parse it, and find the root element
        emotionList = JsonUtility.FromJson<EmotionList>(emotionsJSON.text);

        // Filter the root element to only include emotions with difficulty <= 3, and convert it to a list
        // For level 1. We need a variable for the level number

        Emotion[] filteredEmotionList;
        if (GameObject.FindGameObjectWithTag("level").name == "Level 1")
        {
            filteredEmotionList = emotionList.emotions.Where(e => e.difficulty <= 3).ToArray();
        }
        else if (GameObject.FindGameObjectWithTag("level").name == "Level 2")
        {
            filteredEmotionList = emotionList.emotions.Where(e => e.difficulty <= 6 && e.difficulty >= 4).ToArray();
        }
        else
        {
            filteredEmotionList = emotionList.emotions.Where(e => e.difficulty > 6).ToArray();
        }

        // Choose a random emotion, and for that emotion, choose a random scenario
        chosenEmotion = filteredEmotionList[UnityEngine.Random.Range(0, filteredEmotionList.Length)];
        text = chosenEmotion.scenarios[UnityEngine.Random.Range(0, chosenEmotion.scenarios.Length)];
        exp = chosenEmotion.sprite;

        return chosenEmotion;
    }

}
