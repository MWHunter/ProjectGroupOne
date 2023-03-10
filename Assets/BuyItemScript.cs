using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyItemScript : MonoBehaviour
{
    public GameObject balanceTracker;
    public int itemCost;

    private void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(HandleButtonClick);
    }

    void Update() {
        BalanceIncrementer balanceInc = balanceTracker.GetComponent<BalanceIncrementer>();
        Button myButton = GetComponent<Button>();

        bool hasEnoughMoney = balanceInc.balance >= itemCost;
        if (hasEnoughMoney) {

        } else {

        }
    }

    private void HandleButtonClick()
    {
        Debug.Log("Handled click");
        BalanceIncrementer balanceInc = balanceTracker.GetComponent<BalanceIncrementer>();
        if (balanceInc.balance >= itemCost) {
            balanceInc.balance -= itemCost;
        }
        
        Debug.Log("Done click " + balanceInc.balance);
    }
}
