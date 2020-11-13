using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    public ParticleSystem squirt;
    public bool canSquirt = true;
    public float reloadSquirtTime;

    private void Start()
    {
        
    }

    public void Squirt()
    {
        squirt.Play();
        canSquirt = false;
        StartCoroutine(LoadingSquirtCoroutine());
    }

    public IEnumerator LoadingSquirtCoroutine()
    {
        yield return new WaitForSeconds(reloadSquirtTime);
        canSquirt = true;
    }

    private void Update()
    {
     
    }

}
