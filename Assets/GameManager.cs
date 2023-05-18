using UnityEngine;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
      
       public int currentQuestionIndex = 0;
    public List<QuestionSO> remainingQuestions;
    public int balance = 0;

    public double bonusChance = 0;
    public int bonusConstant = 0;
    public double bonusMultiplier = 1;
    public int levelIndex = 0; // Update to levelIndex
    public int correctAnswers = 0;
     public bool quizInitialized = false;
    [SerializeField] private ClickSound clickSound;




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
        if (amount > 0) {
            int bonus = bonusConstant;
            System.Random random = new System.Random();
            if (random.NextDouble() < bonusChance)
            {
                bonus += 50;
            }
            bonus = (int) Math.Round(bonus * bonusMultiplier);
            balance += bonus;
        }

        balance += amount;
        
        Debug.Log("Balance updated. Current balance: $" + balance);
    }

    public void DeductBalance(int amount) { 
        balance -= amount;
    }
}
