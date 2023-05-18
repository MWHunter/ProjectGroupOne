using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance { get; private set; } // static singleton property

    public int currentQuestionIndex = 0; // Current Question Index

    void Awake()
    {
        if (Instance == null) // Check if instance already exists
        {
            Instance = this; // if not, set instance to this
            DontDestroyOnLoad(gameObject); //Sets this to not be destroyed when reloading scene
        }
        else if (Instance != this) // If instance already exists and it's not this
        {
            Destroy(gameObject); // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }
    }
}
