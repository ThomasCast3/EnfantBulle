using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    public float sceneTimer = 0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneTimer += Time.deltaTime;
        if(sceneTimer >= 30){
            Debug.LogWarning("fin timer zone");
            GameManager.Instance.portail3D.scene2D.SetActive(true);
        }
    }
}
