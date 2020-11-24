using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInfo : MonoBehaviour
{
    public int id;
    public Transform scene;
    public float size;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Camera.main.GetComponent<CameraChanger>().SetTarget(transform);
            SegmentSceneManager newCurrentScene = scene.GetComponent<SegmentSceneManager>();
            SceneManager.Instance.SetNewCurrentScene(newCurrentScene);
            if(size != 0)
            {
                Camera.main.orthographicSize = size;
            }
        }
    }
}
