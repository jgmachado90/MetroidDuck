using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;
    public static CameraManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public Coroutine changeSizeCoroutine;
    public CinemachineVirtualCamera cineCamera;

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

    private void Start()
    {
        targetSize = cineCamera.m_Lens.OrthographicSize;
        changeSizeCoroutine = StartCoroutine(ChangeSizeCoroutine());
    }

    float lerpDuration = 1;
    public float targetSize;
    public static float t = 0.0f;


    public IEnumerator ChangeSizeCoroutine()
    {
        while (true)
        {
            if(targetSize != cineCamera.m_Lens.OrthographicSize)
            {
                var startValue = cineCamera.m_Lens.OrthographicSize;
                var endValue = targetSize;
                var currentTargetSize = targetSize;
                float timeElapsed = 0;

                while(timeElapsed < lerpDuration)
                {
                    cineCamera.m_Lens.OrthographicSize = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                    if (endValue != targetSize)
                        break;
                } 
            }        
            yield return null;
        }
    }


}
