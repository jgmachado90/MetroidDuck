using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    public ParticleSystem squirt;
    public Transform whaleTail;
    

    private void Start()
    {
        
    }

    public void Squirt()
    {
        squirt.Play();
    }

    private void Update()
    {
     
    }

}
