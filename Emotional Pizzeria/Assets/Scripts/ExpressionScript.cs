using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using static ScenarioScript;

/// <summary>
/// Used in Expression GameObject in Customer prefab.
/// Function to assign the correct expression sprite matching the context.  
/// author - @Jiwon / modified by - @Shanaia / last modified - October 1st, 2023
/// </summary>
public class ExpressionScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "ExpressionSummary")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + ScenarioScript.exp);
        }
    }

    // This function sets the expression to the one in the given path
    public void SetExpressionByFile(string path) 
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }

    /* This function is obsolete and no longer used due to change in database structure. 
    // This function sets a random expression from the folder "sprite" in the given path
    public void SetExpressionByFolder(string path) 
    {
    
        string[] files = Directory.GetFiles(Path.Combine(path, "sprite"));
        string[] filtered = Array.FindAll(files, files => 
                                            !files.EndsWith("meta"));

        for (int iFile = 0; iFile < filtered.Length; iFile++)
        {
            filtered[iFile] = Path.GetFileNameWithoutExtension(filtered[iFile]);
        }

        string exp_chosen = filtered[UnityEngine.Random.Range(0, filtered.Length)];
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(exp_chosen);
    }
    */

}


