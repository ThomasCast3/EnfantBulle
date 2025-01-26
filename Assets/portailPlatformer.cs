using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portailPlatformer : MonoBehaviour
{
    public Transform nextSpawnPoint;
 //   public GameObject transition;

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
          //  transition.SetActive(true);
            other.transform.position = nextSpawnPoint.position;
            //rb.velocity = Vector2.zero;
        }
    }

}
