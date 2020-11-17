using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    public float bounceForce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<DuckController>().Bounce(bounceForce);
            Destroy(this.gameObject);
        }
    }
}
