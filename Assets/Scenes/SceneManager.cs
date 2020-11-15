using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    public SegmentSceneManager currentMainScene;

    private void Awake()
    {
        instance = this;
    }

    public void SetNewCurrentScene(SegmentSceneManager newCurrentScene)
    {
        currentMainScene.DeactivateAdjacentScenes(newCurrentScene);
        currentMainScene.isCurrentScene = false;

        currentMainScene = newCurrentScene;
        currentMainScene.isCurrentScene = true;
        currentMainScene.ActivateAdjacentScenes();

    }
}
