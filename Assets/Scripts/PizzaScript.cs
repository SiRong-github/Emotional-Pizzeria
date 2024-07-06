using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used for setting the sprite of the pizza differently for each level. 
/// author - @Jiwon / last modified - October 19th, 2023
/// </summary>
public class pizzaScript : MonoBehaviour
{
    // all options of pizza sprites 
    [SerializeField] GameObject[] pizzas;
    [SerializeField] Sprite level2;
    [SerializeField] Sprite level3;

    void Start()
    {
        // changing default sprite to level2 pizza 
        if (GameObject.FindGameObjectWithTag("level").name == "Level 2")
        {
            for (int i = 0; i<pizzas.Length; i++)
            {
                pizzas[i].GetComponent<Image>().overrideSprite = level2;

            }

        } 
        // changing default sprite to level3 pizza 
        else if (GameObject.FindGameObjectWithTag("level").name == "Level 3")
        {
            for (int i = 0; i<pizzas.Length; i++)
            {
                pizzas[i].GetComponent<Image>().overrideSprite = level3;
            }
        }        
    }
}
