using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manage SFX (volume, start, etc.)
/// author - @Shanaia / last modified - September 12th, 2023
/// </summary>
public class SFXAdjuster : MonoBehaviour
{

    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("SFXHandler");

        // At any given moment, we should have only one slider managing the SFX stuff 
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Don't destroy it if it's the first initialization of our SFX Volume Slider 
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        if (Time.timeScale == 0f) 
        {
            return;
        }
        
        /* Iterate over all SFX game objects and adjust their volume. */
        GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("sfx");
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
