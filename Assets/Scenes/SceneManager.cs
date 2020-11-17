using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private static SceneManager _instance;
    public static SceneManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public SegmentSceneManager currentMainScene;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
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
