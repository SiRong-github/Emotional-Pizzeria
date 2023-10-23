using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// To adjust speech speed. Subject to modification. 
/// author - @Shanaia / last modified - October 1st, 2023
/// </summary>
public class SpeechRateAdjuster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); 
        // We want the slider's effects to persist! We should unconditionally not destroy it.
    }
}
