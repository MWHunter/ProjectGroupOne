using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class walkLoop : MonoBehaviour
{
    public Image oldImage;
    public Sprite newImage;
    public Sprite newImage2;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            /* run your code here */ 
                i = i + 1;
                if(i % 2 == 0){
                    oldImage.sprite = newImage2;
                } else{
                    oldImage.sprite = newImage;
                }
    }

    void walk(){
        new Thread(() => 
        {
            
        }).Start();
}



}
