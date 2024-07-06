using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using static Cinemachine.DocumentationSortingAttribute;

/// <summary>
/// Used in Emotion Buttons GameObject.
/// Functions to assign correctness and prompt option values to each of the choices. 
/// author - @Jiwon / last modified - October 12th, 2023
/// </summary>
public class Answers : MonoBehaviour
{

    // hold correct / incorrect option
    public bool isCorrect = false;  
    // to show different pizzas for each level 
    private Image pizzaImage;  

    [Header("General")]
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private GameObject promptManager;
    [SerializeField] private GameObject pizzaSprite;
    [SerializeField] private QuizManager quizManager;

    // for shaking animation (position)
    [Header("Info")]
    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;
    
    // for shaking animation (speed, time)
    [Header("Shaking settings")]
    [Range(0f, 2f)]
    public float _time = 0.3f;
    [Range(0f, 2f)]
    public float _distance = 0.1f;
    [Range(0f, 0.1f)]
    public float _delayBetweenShakes = 0f;

    private void Awake()
    {
        pizzaImage = pizzaSprite.GetComponent<Image>();
        _startPos = pizzaImage.transform.position;
    }

    // Called by EmotionScripts.cs to assign correctness / incorrectness 
    public void AssignValue(string option, bool correct) 
    {
        isCorrect = correct;

        // changing chosen color for correct option as highlighted 
        // incorrect option has grey color
        if (correct) 
        {
            ColorBlock cb = pizzaSprite.GetComponent<Button>().colors;
            cb.disabledColor = new Color(227, 204, 100, 255);
            pizzaSprite.GetComponent<Button>().colors = cb;
        }
        
        // sets prompt text 
        tmp.text = option; 
    }

    // To implement action when chosen. 
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Incorrect Answer");
            pizzaSprite.GetComponent<Button>().interactable = false; 
            IncorrectAnimation();
            quizManager.Wrong();
        }
    }
 
    private void IncorrectAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }
 
    // shaking movement for incorrect choice is implemented here 
    // code taken and adapted from : 
    // https://forum.unity.com/threads/campfire-how-to-give-a-
    // point-light-a-continuous-small-random-movement.210475/#post-1416913
    // on 3rd October, 2023
    private IEnumerator Shake()
    {
        _timer = 0f;
    
        while (_timer < _time)
        {
            _timer += Time.deltaTime;
            _randomPos = _startPos + (Random.insideUnitSphere * _distance);
            pizzaImage.transform.position = _randomPos;
    
            if (_delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(_delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }
        pizzaImage.transform.position = _startPos;
    }
 
}
