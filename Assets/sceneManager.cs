using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    public float sceneTimer = 0f;
    public int sceneIndex = 0;

    
    void Start()
    {
        GameManager.Instance.current3DScene = sceneIndex;
    }

    // Update is called once per frame
    void Update()
    {
        sceneTimer += Time.deltaTime;
        if(sceneTimer >= 30){
            Debug.LogWarning("fin timer zone");
            GameManager.Instance.portail3D.scene2D.SetActive(true);
            GameManager.Instance.portail3D.ModeScene2D();
        }
    }
}
