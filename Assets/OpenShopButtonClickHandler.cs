using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenShopButtonClickHandler : MonoBehaviour
{
    public GameObject objectToToggle;
    public TextMeshProUGUI shopText;

    public GameObject otherButton;

    private void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(HandleButtonClick);

        Button other = otherButton.GetComponent<Button>();
        other.onClick.AddListener(HandleOtherButtonClick);
    }

    private void HandleOtherButtonClick() {
        if (objectToToggle.activeSelf) {
            HandleButtonClick();
        }
    }

    private void HandleButtonClick()
    {
        // Add your code here to handle the button click event
        objectToToggle.SetActive(!objectToToggle.activeSelf);

        if (shopText.text == "Open Shop"){
            shopText.text = "Close Shop";
        } else {
            shopText.text = "Open Shop";
        }
    }
}
