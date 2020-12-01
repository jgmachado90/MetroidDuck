using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSceneManager : MonoBehaviour
{
    public List<SegmentSceneManager> adjacentScenes;
    public bool isCurrentScene;
    public bool isActive;

    private void Start()
    {
        if (!isActive)
        {
            this.gameObject.SetActive(false);
        }
        if (isCurrentScene)
        {
            ActivateAdjacentScenes();
        }
        
    }

    public void ActivateAdjacentScenes()
    {
        foreach(SegmentSceneManager scene in adjacentScenes)
        {
            scene.isActive = true;
            scene.gameObject.SetActive(true);
        }
    }

    public void DeactivateAdjacentScenes(SegmentSceneManager newCurrentScene)
    {
        foreach (SegmentSceneManager scene in adjacentScenes)
        {
            if (scene != newCurrentScene)
            {
                scene.isActive = false;
                scene.gameObject.SetActive(false);
                isCurrentScene = false;
            }
        }
    }

}
