using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DuckMovement : MonoBehaviour
{
    ControllerActions playerControls;
    Vector2 move;

    public Transform currentSpawnPoint;
    public static DuckMovement instance;
    public float aceleration;
    public float deceleration;
    public float maxSpeed;
    public bool facingRight = true;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public float bounceForce;

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Enable();
    }

    private void Awake()
    {
        instance = this;
        playerControls = new ControllerActions();

        playerControls.Gameplay.ActionButton.performed += ctx => Action();

        playerControls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        //playerControls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
    }

    void Action()
    {
        Debug.Log("action");
    }

 
    private void Update()
    {
        Vector2 m = new Vector2(move.x, move.y);

        Debug.Log("move = " + m);

        if (move.x != 0)
            transform.position = new Vector2( transform.position.x + (m.x * aceleration * Time.deltaTime), transform.position.y);

        /*if ((Input.GetAxisRaw("Vertical") != 0))
            transform.position = new Vector2(transform.position.x , transform.position.y + (Input.GetAxisRaw("Vertical") * aceleration * Time.deltaTime));
        */


        if (m.x > 0  && facingRight == false){
            facingRight = true;
            sprite.flipX = false;
        }

        else if(m.x < 0 && facingRight == true)
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
            SegmentSceneManager newCurrentScene = collision.GetComponent<CameraInfo>().scene.GetComponent<SegmentSceneManager>();
            SceneManager.instance.SetNewCurrentScene(newCurrentScene);
        }

        if(collision.tag == "SecretPlace")
        {
            collision.GetComponent<SecretPlace>().UnlockSecretPlace();
        }

        if(collision.tag == "SquirtDetector")
        {
            if (collision.GetComponentInParent<Whale>().canSquirt)
            {
                collision.GetComponentInParent<Whale>().Squirt();
                Vector2 force = new Vector2(0, bounceForce * 1.5f);
                rb.AddForce(force, ForceMode2D.Impulse);
            }
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
