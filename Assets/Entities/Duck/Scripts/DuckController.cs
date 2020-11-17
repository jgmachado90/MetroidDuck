using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DuckController : MonoBehaviour
{
    public Transform currentSpawnPoint;

    ControllerActions playerControls;
    Vector2 move;
    public float minXToMove;
    public float speedX;
    public bool facingRight = true;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;


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
        playerControls = new ControllerActions();

        playerControls.Gameplay.ActionButton.performed += ctx => Duck.Instance.Action();

        playerControls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
    }


    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 m = new Vector2(move.x, move.y);

        if (m.x > minXToMove || m.x < -minXToMove)
            transform.position = new Vector2(transform.position.x + (m.x * speedX * Time.deltaTime), transform.position.y);


        if (m.x > minXToMove && facingRight == false)
        {
            facingRight = true;
            sprite.flipX = false;
        }

        else if (m.x < -minXToMove && facingRight == true)
        {
            facingRight = false;
            sprite.flipX = true;
        }
    }

    public void Bounce(float bounceForce)
    {
        rb.velocity = Vector2.zero;
        Vector2 force = new Vector2(0, bounceForce);
        rb.AddForce(force, ForceMode2D.Impulse);
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if(collision.tag == "FallDie")
        {
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
                Vector2 force = new Vector2(0, 22 * 1.5f);
                rb.AddForce(force, ForceMode2D.Impulse);
            }
        }

        if (collision.tag == "DialogueEntity")
        {
            Duck.Instance.currentDialogueEntity = collision.GetComponent<DialogueTrigger>();
        }


    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SecretPlace")
        {
            collision.GetComponent<SecretPlace>().LockSecretPlace();
        }

        if (collision.tag == "DialogueEntity")
        {
            Duck.Instance.currentDialogueEntity = null;
            DialogueManager.Instance.EndDialogue();
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
