using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Coordinates the BGM throughout the whole game.
/// author - @Shanaia / last modified - September 7th, 2023
/// </summary>
public class BGMAdjuster : MonoBehaviour
{

    void Start()
    {
        // We want the slider's effects to persist! We should unconditionally not destroy it.
        DontDestroyOnLoad(this.gameObject); 
    }

    void Update()
    {
        if (Time.timeScale == 0f) 
        {
            return;
        }
        
        // Iterate over all SFX game objects and adjust their volume. 
        GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("bgm");

        foreach (GameObject obj in sfxObjects) {
            AudioSource sfxAudio = obj.GetComponent<AudioSource>();
            // Update the audio to meet the current volume
            if (sfxAudio != null)
            {
                sfxAudio.volume = this.gameObject.GetComponent<Slider>().value;
            }
        }
    }
}
