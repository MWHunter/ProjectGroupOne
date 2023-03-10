using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMouseClip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckMouseClick();
        }
    }

    void CheckMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Clicked on " + hit.collider.gameObject.name);
        }
    }
}
