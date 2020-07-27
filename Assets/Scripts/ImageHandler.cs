using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageHandler : MonoBehaviour
{

    public Image image;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.Done)
        {
            text.text = $"you had a {PlayerStats.grade} rated nest. thanks for playing .";
            image.enabled = true;
        }
        
    }
}
