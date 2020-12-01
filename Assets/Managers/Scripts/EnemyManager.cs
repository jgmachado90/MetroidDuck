using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _instance;
    public static EnemyManager Instance
    {
        get
        {
            return _instance;
        }
    }
 
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

    public void RespawnAllEnemies()
    {
        Enemy[] enemies = Resources.FindObjectsOfTypeAll(typeof(Enemy)) as Enemy[];

        foreach (Enemy e in enemies)
        {
            if(e.dead)
                e.Respawn();
        }

    }

}
