using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().enabled = false;
        StartCoroutine("SomeRoutine");
    }

    IEnumerator SomeRoutine()
    {

        //do stuff
        Debug.Log("press E to play game");
        //wait for space to be pressed
        while (!Input.GetKeyDown(KeyCode.G))
        {
            yield return null;
        }

        Debug.Log("yes dear,,,,");

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().enabled = true;


        
        // Debug.Log("it's finished!");

        //do stuff once space is pressed

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
