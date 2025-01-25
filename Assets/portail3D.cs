using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portail3D : MonoBehaviour
{
    public GameObject scene2D;
    public GameObject scene3D;
    
    //public 
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModeScene3D(int scene){
        scene2D.SetActive(false);
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        scene3D.SetActive(true);
        
    }
}
