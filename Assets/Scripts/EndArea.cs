using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndArea : MonoBehaviour
{    public Text flavorText;

    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Be Here");
            // winner.SetActive(true);
            // winner.transform.position = new Vector3 (winner.transform.position.x, winner.transform.position.y + 1);
        }


        flavorText.text = "Press space to turn in items.";

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        flavorText.enabled = false;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(3);

        }
    }
}
