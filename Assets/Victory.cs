using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{

    public GameManager gameManager;
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            gameManager.victoryScreen.SetActive(true);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
