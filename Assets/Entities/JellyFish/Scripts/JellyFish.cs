using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class JellyFish : Enemy
{
    public float bounceForce = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<DuckController>().Bounce(bounceForce);
            Death();
        }
    }
    public override void Respawn()
    {
        base.Respawn();
        Debug.Log("jelly respawn");
    }

    public override void Death()
    {
        Debug.Log("jelly death");
        base.Death();
        gameObject.SetActive(false);
    }
}
