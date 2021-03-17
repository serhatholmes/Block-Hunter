using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int breakableBlocks;

    // cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            sceneloader.LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sceneloader.LoadStartScene();
        }

    }



    public void CountBlocks()
    {
        breakableBlocks++;

    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks<= 0)
        {
            sceneloader.LoadNextScene();
        }
    }


}
