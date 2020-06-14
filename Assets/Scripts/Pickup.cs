﻿// using System.Collections;
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

public class Pickup : MonoBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;

    public int value;

    private bool inRange;

    public TextMeshProUGUI selectionText;
    // public GameObject effect;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            // selectionText.SetText("pick up item worth " + value + " by pressing E");
            Vector3 somePosition = new Vector3(transform.position.x, transform.position.y + 1);
            Debug.Log(somePosition);
            // somePosition = transform.InverseTransformPoint(0, 0, 0);
            Vector3 testPos = transform.TransformPoint(somePosition);
            // float test = Camera.main.orthographicSize;
            Debug.Log(testPos);
            // Debug.Log(testPos);
            selectionText.transform.position = somePosition;
            // selectionText.enabled = true;
            // selectionText.transform.position = testPos;
            // selectionText.enabled = true;
            Debug.Log("pickup allowed.");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // inRange = false;
            selectionText.enabled = false;
            Debug.Log("pickup no longer allowed.");

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("he is here!!!!");

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                { // check whether the slot is EMPTY
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.value += value;
                    Destroy(gameObject);
                    Debug.Log("This item is worth " + value);
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