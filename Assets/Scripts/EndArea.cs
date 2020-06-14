using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
           winner.transform.position = new Vector3 (winner.transform.position.x, winner.transform.position.y + 1);
        }

    }

// Update is called once per frame
void Update()
    {
        
    }
}
