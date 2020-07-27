// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Pickup : MonoBehaviour {

//     private Inventory inventory;
//     public GameObject itemButton;

//     public int value;
//     public GameObject effect;

//     private void Start()
//     {
//         inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player")) {   
//             for (int i = 0; i < inventory.slots.Length; i++)
//             {
//                 if (inventory.isFull[i] == false) { // check whether the slot is EMPTY
//                     inventory.isFull[i] = true;
//                     Instantiate(itemButton, inventory.slots[i].transform, false);
//                     inventory.value += value;
//                     Destroy(gameObject);
//                     Debug.Log("This item is worth " + value);
//                     break;
//                 }
//             }
//         }

//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;

    public int value;

    private bool inRange;

    public string flavorContent;

    public string name;
    // public GameObject effect;

    public Text flavorText;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            Vector3 somePosition = new Vector3(transform.position.x, transform.position.y + 1);
            Debug.Log(somePosition);
            // somePosition = transform.InverseTransformPoint(0, 0, 0);
            Vector3 testPos = transform.TransformPoint(somePosition);
            // float test = Camera.main.orthographicSize;
            Debug.Log(testPos);
            // Debug.Log(testPos);
            // selectionText.enabled = true;
            // selectionText.transform.position = testPos;
            // selectionText.enabled = true;
            Debug.Log("pickup allowed.");

            flavorText.text = flavorContent;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // inRange = false;
            Debug.Log("pickup no longer allowed.");
            flavorText.text = "";

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("he is here!!!!");

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                { // check whether the slot is EMPTY
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.value += value;
                    inventory.name[i] = name;
                    Destroy(gameObject);
                    Debug.Log("This item is worth " + value);
                    PlayerStats.Points = inventory.value;
                    PlayerStats.Content[i] = name;
                    Debug.Log($"player stats are {PlayerStats.Points}");
                    break;
                }
            }


        }
    }

    private void PickHe(GameObject gameObject)
    {
        Debug.Log(value);
    }

    private void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.F))
        {
            PickHe(gameObject);
        }
    }
}