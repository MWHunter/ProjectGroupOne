using UnityEngine;
using UnityEngine.UI;

public class BuyItemScript : MonoBehaviour
{
    public GameObject balanceTracker;
    public int itemCost;
    

    private BalanceIncrementer balanceInc;
    private Button myButton;

    private void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(HandleButtonClick);

        balanceInc = balanceTracker.GetComponent<BalanceIncrementer>();
        if (balanceInc == null)
        {
            Debug.LogError("No BalanceIncrementer component found on the balanceTracker object.");
        }
        else
        {
            balanceInc.BalanceChanged += OnBalanceChanged; // Subscribe to the BalanceChanged event
        }
    }

    void Update() {
        bool hasEnoughMoney = balanceInc != null && balanceInc.balance >= itemCost;
        if (hasEnoughMoney) {
            // Do something if the player has enough money
        } else {
            // Do something else if the player doesn't have enough money
        }
    }

    private void HandleButtonClick()
    {
        if (balanceInc == null)
        {
            return;
        }

        if (balanceInc.balance >= itemCost) {
            balanceInc.AddBalance(-itemCost); // Deduct the item cost from the balance using AddBalance() method
        }
    }

    private void OnBalanceChanged(int newBalance)
    {
        
        Debug.Log("Balance changed to: $" + newBalance);
    }

    private void OnDestroy()
    {
        if (balanceInc != null)
        {
            balanceInc.BalanceChanged -= OnBalanceChanged; // Unsubscribe from the BalanceChanged event
        }
    }
}
