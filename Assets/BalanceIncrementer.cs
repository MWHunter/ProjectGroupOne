using System;
using UnityEngine;
using TMPro;

public class BalanceIncrementer : MonoBehaviour
{
    public TextMeshProUGUI Balancetext;

    public int balance = 0;

    public event Action<int> BalanceChanged;

    // Start is called before the first frame update
    void Start()
    {
        Balancetext = GetComponent<TextMeshProUGUI>();
        if (Balancetext != null)
        {
            Balancetext.text = "Balance: $" + balance;
        }
    }

    void Update()
    {
        if (Balancetext != null)
        {
            Balancetext.text = "Balance: $" + balance;
        }
    }

    public void AddBalance(int amount)
    {
        balance += amount;
        Update();
        BalanceChanged?.Invoke(balance); // Invoke the BalanceChanged event, passing in the new balance value
        Debug.Log("Balance updated. Current balance: $" + balance);
    }
}