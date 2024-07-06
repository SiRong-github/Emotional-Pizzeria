using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the choice of sprite for Body in Character Prefab.
/// author - @Jiwon / last modified - September 9th, 2023
/// </summary>
public class CharacterScript : MonoBehaviour
{
    // all sprite choices 
    [SerializeField] public Sprite[] character_sprites;

    public void Render()
    {
        // random selection of body sprite
        GetComponent<SpriteRenderer>().sprite = character_sprites[Random.Range(0, character_sprites.Length)];
    }
}