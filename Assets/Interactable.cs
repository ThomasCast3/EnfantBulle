using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            //incrementTime
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
