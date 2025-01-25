using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class portail3D : MonoBehaviour
{
    public GameObject scene2D;
    public GameObject scene3D;
    public UnityEvent tpEvent;
    
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            tpEvent.Invoke();
        }
    }

    public void ModeScene3D(int scene){
        scene2D.SetActive(false);
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        scene3D.SetActive(true);

    }
}
