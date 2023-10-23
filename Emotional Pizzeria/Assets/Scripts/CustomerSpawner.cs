using System.Collections;
using UnityEngine;

/// <summary>
/// Used to spawn characters for each level (general). 
/// Uses character prefab to spawn customers.
/// author - @Shanaia / last modified - October 10th, 2023
/// </summary>
public class Spawner : MonoBehaviour
{
    
    [Header("General")]
    [SerializeField] GameObject customer;
    [SerializeField] AudioSource customerIn;
    [SerializeField] AudioSource customerOut;
    [SerializeField] Transform SpriteCanvas;
    [SerializeField] float timer;

    private bool hasNextCustomer = false;

    [Header("Customer Customizing")]
    private Transform character;
    private GameObject currCustomer;
    private GameObject body;
    private GameObject expression;
    private GameObject scenario;
    private GameObject speechBubble;
    private GameObject speechBubbleText;

    /// <summary>
    /// Manages brief rest periods between movements of the customer.
    /// </summary>
    IEnumerator CustomerCoroutine()
    {
        // Gets children of Customer Game Object 
        character = currCustomer.transform.GetChild(0);
        body = character.GetChild(0).gameObject;
        expression = character.GetChild(1).gameObject;
        speechBubble = currCustomer.transform.GetChild(1).gameObject;
        scenario = currCustomer.transform.GetChild(3).gameObject;

        // Renders Customer after some time 
        yield return new WaitForSecondsRealtime(timer);
        customerIn.Play();
        yield return new WaitUntil(() => Time.timeScale != 0f);
        yield return new WaitUntil(() => customerIn.isPlaying == false);
        yield return new WaitUntil(() => Time.timeScale != 0f);
        
        body.GetComponent<CharacterScript>().Render();
        
        // Renders Speech Bubble after some time
        speechBubbleText = speechBubble.transform.GetChild(0).gameObject;
        speechBubble.SetActive(true);
        ScenarioScript.Emotion emotion = scenario.GetComponent<ScenarioScript>().getChosenEmotion();
        Debug.Log("emotion " + emotion);
        expression.GetComponent<ExpressionScript>().SetExpressionByFile("Sprites/" + emotion.name);

    }

    void Update()
    {

        // Creates next customer 
        if (hasNextCustomer)
        {
            if (currCustomer != null)
            {
                Destroy(currCustomer);
            }

            currCustomer = Instantiate(customer, SpriteCanvas, false);
            StartCoroutine(CustomerCoroutine());
            hasNextCustomer = false;
        }
        

    }

    /* some getters and setters */

    public void HasNextCustomer()
    {
        hasNextCustomer = true;
    }

    public void HasNoCustomer()
    {
        hasNextCustomer = false;
        customerIn.Stop();
        customerOut.Stop();

        if (currCustomer != null)
        {
            Destroy(currCustomer);
        }
    }

    public GameObject GetCurrentCustomer()
    {
        return currCustomer;
    }

    public bool customerOutStopped()
    {
        return !customerOut.isPlaying;
    }

    /// <summary>
    /// Called after order is submitted to remove the customer prefab.
    /// </summary>
    public void RemoveCurrCustomer()
    {
        if (currCustomer != null)
        {
            Debug.Log("Customer exists, can be removed.");
            Destroy(currCustomer);
            //customerOut.Play();
        } else
        {
            Debug.Log("Customer already destroyed.");
        }
        
    }

}
