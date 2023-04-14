using System;
using UnityEngine;
using TMPro;

public class BalanceIncrementer : MonoBehaviour
{
    public TextMeshProUGUI Balancetext;

    public event Action<int> BalanceChanged;

    void Start()
    {
        Balancetext = GetComponent<TextMeshProUGUI>();
        UpdateBalanceText();
    }

    void Update()
    {
        UpdateBalanceText();
    }

    private void UpdateBalanceText()
    {
        if (Balancetext != null)
        {
            Balancetext.text = "Balance: $" + GameManager.Instance.balance;
        }
    }

    public void AddBalance(int amount)
    {
        GameManager.Instance.AddBalance(amount);
        UpdateBalanceText();
        BalanceChanged?.Invoke(GameManager.Instance.balance);
    }
}
