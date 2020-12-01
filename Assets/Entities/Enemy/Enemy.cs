using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 spawnPosition;
    public bool dead;
    private void Awake()
    {
        dead = false;
        spawnPosition = transform.position;
    }

    public virtual void Respawn()
    {
        Debug.Log("base respawn");
        Debug.Log(gameObject);
        dead = false;
        gameObject.SetActive(true);
        transform.position = spawnPosition;
    }

    public virtual void Death()
    {
        Debug.Log("base death");
        dead = true;
    }

   

}
