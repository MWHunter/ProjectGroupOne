using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeBackground : MonoBehaviour
{
    public GameObject objectToToggle;
    public GameObject objectToToggle2;
    public TextMeshProUGUI menuText;

    private void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        // Add your code here to handle the button click event
        objectToToggle.SetActive(!objectToToggle.activeSelf);

        if (menuText.text == "City Office"){
            objectToToggle.SetActive(false);
            objectToToggle2.SetActive(true);
            menuText.text = "Country Office";
            
        } else {
            objectToToggle.SetActive(true);
            objectToToggle2.SetActive(false);
            menuText.text = "City Office";
        }
    }
}
