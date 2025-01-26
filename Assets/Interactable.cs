using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public int soapAmount = 30;

    public void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.name);
        if(other.CompareTag("Player")){
            GameManager.Instance.IncrementTimer(soapAmount);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
