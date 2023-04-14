using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class helpBehavior : MonoBehaviour
{
    public GameObject objectToToggle;

    private void Start()
    {
        Button myButton = GameObject.Find("HelpButton").GetComponent<Button>();
        myButton.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        // Add your code here to handle the button click event
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}
