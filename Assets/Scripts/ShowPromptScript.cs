using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Show emotions prompt after customer explains situation.
/// author - @Sammi / last modified - September 15th, 2023
/// </summary>
public class ShowPromptScript : MonoBehaviour
{

    [SerializeField] GameObject customer; 
    [SerializeField] GameObject prompt; 
    
    // Start is called before the first frame update
    void onClick() {
        customer.SetActive(false);
        prompt.SetActive(true);
    }

}
