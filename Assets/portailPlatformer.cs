using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portailPlatformer : MonoBehaviour
{
    public Transform nextSpawnPoint;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Debug.Log("player teleport");
            rb.MovePosition(nextSpawnPoint.position);
            rb.velocity = Vector2.zero;
        }
    }

}
