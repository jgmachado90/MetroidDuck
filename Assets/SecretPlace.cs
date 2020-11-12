using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPlace : MonoBehaviour
{
    
    public void UnlockSecretPlace()
    {
        Debug.Log("entrou no lugar secreto");
        foreach(Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().sortingOrder = 15;
        }
    }

    public void LockSecretPlace()
    {
        Debug.Log("saiu do lugar secreto");
        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }


}
