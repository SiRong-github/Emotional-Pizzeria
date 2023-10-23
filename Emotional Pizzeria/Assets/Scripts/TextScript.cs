using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using System.Collections.Generic;


/// <summary>
/// Used to control text generation. 
/// author - @Shanaia / modified by - @Jiwon / last modified - October 1st, 2023
/// </summary>
public class TextScript : MonoBehaviour
{
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private Coroutine coroutine;

    [Header("Typewriter Speed")]
    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;

    [SerializeField] private GameObject prompt;
    [SerializeField] private GameObject customer; 
    [SerializeField] private GameObject takeOrder; 
    [SerializeField] private GameObject scManager;
    
    [Header("Typewriter Status")]
    private ScenarioScript sc;  
    // is typewriter fast forwarded?
    private bool textSkipped = false; 
    // typewriter effect finished?
    public bool textFinished = false; 
    // private static bool updateOn = true; 
    private string txt; 
    // is typewriter on?
    private bool running = false; 


    void Start() 
    {

        // No typewriter effect for summary prompts 
        if (gameObject.name == "ScenarioSummary")
        {
            Initialize();
        }

    }

    private void Update() 
    {
     
        if (Time.timeScale == 0f) 
        {
            return;
        }

        // No typewriter effect for summary prompts 
        if (gameObject.name == "ScenarioSummary")
        {
            return;
        }

        // Typewriter effect implement 

        // Typewriter starting condition 
        if (ScenarioScript.text != null && !running)
        {
            running = true;
            InitializeByString(ScenarioScript.text);
        }

        // Typewriter fast forwarding condition (Okay button appear)
        if (textFinished || (textFinished && Input.GetMouseButtonDown(0)))
        {
            takeOrder.SetActive(true);
        }

        // Typewriter fast forwarding action
        if (!textSkipped && Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
        {
            textSkipped = true;
            textFinished = true;
        }

    }

    // No typewriter effect for summary prompts
    public void Initialize() 
    {   
        ScenarioScript sc = scManager.GetComponent<ScenarioScript>();
        tmp.text = ScenarioScript.text; 
    }

    // Typewriter effect for speech bubble 
    public void Initialize(string path) 
    {
        StreamReader reader = new StreamReader(path);

        tmp.text = "";
        txt = reader.ReadToEnd();
        StartCoroutine("TypeWriterTMP");
    }

    // Typewriter effect for speech bubble 
    public void InitializeByString(string scenario)
    {
        tmp.text = "";
        txt = scenario;
        StartCoroutine("TypeWriterTMP");       
    }

    // Typewriter effect implementation 
    // Taken and adapted from : 
    // https://unitycoder.com/blog/2015/12/03/ui-text-typewriter-effect-script/
    // on September 15th, 2023.
    IEnumerator TypeWriterTMP()
    {
        yield return new WaitForSecondsRealtime(delayBeforeStart);
        yield return new WaitUntil(() => Time.timeScale != 0f);

        // print each character 
        foreach (char c in txt)
        {
            if (textSkipped) {
                tmp.text = txt; 
                break; 
            }

            tmp.text += c;
            yield return new WaitForSecondsRealtime(timeBtwChars);
        }

        textFinished = true; 
    }
}
