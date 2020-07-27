using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{

    public Dialog dialog;

    private Queue<string> sentences;

    public Text flavorText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("new scene start!");
        sentences = new Queue<string>();
        try
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().enabled = false;
        }
        catch
        {

        }

        sentences.Clear();

        if (SceneManager.GetActiveScene().name == "End")
        {
            PlayerStats.DetermineResult();
            foreach (string sentence in PlayerStats.bowergirlSpeech)
            {
                if (!string.IsNullOrEmpty(sentence))
                {
                    Debug.Log("adding some sentences");
                sentences.Enqueue(sentence);
                }
            }
        }


        if (SceneManager.GetActiveScene().name == "MainGame")
        {
            foreach (string sentence in dialog.sentences)
            {
                sentences.Enqueue(sentence);
            }
        }

        if (sentences.Count > 0)
        {
        StartCoroutine("SomeRoutine");
        }

        Debug.Log("talking done!");

        // AMethod();
    }

    IEnumerator SomeRoutine()
    {

        //do stuff


        // Debug.Log(talk);
        //wait for space to be pressed
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        StartCoroutine("Cycle");
        Debug.Log("yes dear,,,,");

        // GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().enabled = true;





        // Debug.Log("it's finished!");

        //do stuff once space is pressed

    }

    IEnumerator Cycle()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        string talk = sentences.Dequeue();
        Debug.Log(talk);
        flavorText.text = talk;
        //wait for space to be pressed

        yield return new WaitForSeconds((float)0.1);

        if (sentences.Count > 0)
        {
            Debug.Log("dequeing next...");
            StartCoroutine("Cycle");
        }

        if (sentences.Count == 0)
        {
            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            Debug.Log("finish!");
            if (SceneManager.GetActiveScene().name == "End")
            {
                PlayerStats.Done = true;
            }
            try
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().enabled = true;
            }
            catch { }
            flavorText.text = "";

        }

    }

    void EndText()
    {
        flavorText.text = "";
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
