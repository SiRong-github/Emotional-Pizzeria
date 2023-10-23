using UnityEngine;

/// <summary>
/// Used in Emotion Prompt GameObject.
/// Coordinates the incorrect / correct prompt choices for each of the buttons.
/// Use in coordination with Answers.cs - script for Emotion buttons.
/// author - @Jiwon / last modified - October 12th, 2023
/// </summary>
public class EmotionScript : MonoBehaviour
{
    [SerializeField] private GameObject scManager;
    public GameObject[] emotionBtns; 

    // Start is called before the first frame update
    void Start()
    {
        int correctIndex = chooseCorrect();
        AssignValues(correctIndex);      
    }

    // Chooses the index of the correct button at random 
    private int chooseCorrect() 
    {
        int correctBtn = Random.Range(0, emotionBtns.Length - 1);
        return correctBtn;
    }

    // Assigns appropriate values to emotion buttons 
    private void AssignValues(int index) 
    {
        // loading the scenario manager 
        ScenarioScript sc = scManager.GetComponent<ScenarioScript>();
        string wrongChosen = "";
        string wrong; 

        // assign values to each of the buttons
        for (int i = 0; i < emotionBtns.Length; i++) 
        {
            Answers asc = emotionBtns[i].GetComponent<Answers>();
            // correct button 
            if (i == index) 
            {
                string correct = sc.chosenEmotion.name;
                Debug.Log(correct);
                asc.AssignValue(correct, true);
            } 
            // incorrect button 
            else 
            {
                string[] wrongEmotions = sc.chosenEmotion.incorrect; 
                // to avoid having same incorrect choices 

                while ((wrong = wrongEmotions[Random.Range(0, wrongEmotions.Length - 1)]) == wrongChosen);
                wrongChosen = wrong; 
                // assign to emotion buttons (Answers script)
                asc.AssignValue(wrong, false);
            }
        }        
    }
}
