using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public Transform spawnPoint;
    

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            other.transform.position = spawnPoint.position;
            gameManager.DecrementTimer(10);
        }
    }
}
