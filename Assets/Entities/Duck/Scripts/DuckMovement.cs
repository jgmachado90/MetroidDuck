using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public Transform currentSpawnPoint;

    public float aceleration;
    public float deceleration;
    public float maxSpeed;
    public bool facingRight = true;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public float bounceForce;


    private void Update()
    {

        if ((Input.GetAxisRaw("Horizontal") != 0))
            transform.position = new Vector2( transform.position.x + (Input.GetAxisRaw("Horizontal") * aceleration * Time.deltaTime), transform.position.y);

        /*if ((Input.GetAxisRaw("Vertical") != 0))
            transform.position = new Vector2(transform.position.x , transform.position.y + (Input.GetAxisRaw("Vertical") * aceleration * Time.deltaTime));
        */


        if (Input.GetAxisRaw("Horizontal") > 0  && facingRight == false){
            facingRight = true;
            sprite.flipX = false;
        }

        else if(Input.GetAxisRaw("Horizontal") < 0 && facingRight == true)
        {
            facingRight = false;
            sprite.flipX = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "JellyHead")
        {
            Debug.Log("Colidiu com cabeça");
            rb.velocity = Vector2.zero;
            Vector2 force = new Vector2(0, bounceForce);
            rb.AddForce(force,ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }

        if(collision.tag == "FallDie")
        {
            Debug.Log("Colidiu com rio");
            Die();
        }
        if(collision.tag == "SpawnPoint")
        {
            currentSpawnPoint = collision.transform;
          
        }

        if (collision.tag == "CameraChanger")
        {

            Camera.main.GetComponent<CameraChanger>().SetTarget(collision.transform);

        }

        if(collision.tag == "SecretPlace")
        {
            collision.GetComponent<SecretPlace>().UnlockSecretPlace();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SecretPlace")
        {
            collision.GetComponent<SecretPlace>().LockSecretPlace();
        }
    }

    public void Die()
    {
        Respawn();
    }

    public void Respawn()
    {
        rb.velocity = Vector2.zero;
        transform.position = currentSpawnPoint.position;
    }

}
