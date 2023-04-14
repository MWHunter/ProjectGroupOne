using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int balance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddBalance(int amount)
    {
        balance += amount;
        Debug.Log("Balance updated. Current balance: $" + balance);
    }
}
