using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalanceIncrementer : MonoBehaviour
{
    public TextMeshProUGUI text;

    int frameCounter = 0;
    int balance = 123;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((frameCounter++ % 60) == 0) {
            text.text = "Balance: $" + balance++;
        }
    }
}
