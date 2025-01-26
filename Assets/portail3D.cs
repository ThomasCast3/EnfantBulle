using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class portail3D : MonoBehaviour
{
    public GameObject scene2D;
   // public GameObject scene3D;
    public UnityEvent tpEvent;
    public GameObject parent;
    public Transform nextSpawnPoint;
    public Scene current3DScene;
    
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            tpEvent.Invoke();
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.MovePosition(nextSpawnPoint.position);
            rb.velocity = Vector2.zero;
        }
    }
    public void LoadScene(int scene)
    {
        ModeScene3D(scene);
    }

    public void  ModeScene3D(int scene){
        scene2D.SetActive(false);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        asyncOperation.completed += (operation) =>
        {
            Debug.LogWarning("scene finit de charger ");
            current3DScene = SceneManager.GetSceneByBuildIndex(scene);
        };
    }

    public void ModeScene2D(){
        SceneManager.UnloadSceneAsync(current3DScene);

    }
}
