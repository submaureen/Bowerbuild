using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EndArea : MonoBehaviour
{
    public TextMeshProUGUI winner;

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
            winner.enabled = true;
            winner.SetText(inventory.value.ToString());
            Debug.Log(winner.transform.position);
            // winner.transform.position = new Vector3 (winner.transform.position.x, winner.transform.position.y + 1);
        }

        if (inventory.value > 10)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().enabled = false;
            StartCoroutine("SomeRoutine");
        }

    }



    IEnumerator SomeRoutine()
    {

        //do stuff
        Debug.Log("Am here");
        winner.SetText("press G to resart and try again !");
        //wait for space to be pressed
        while (!Input.GetKeyDown(KeyCode.G))
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Debug.Log("it's finished!");

        //do stuff once space is pressed

    }


    // Update is called once per frame
    void Update()
    {

    }
}
