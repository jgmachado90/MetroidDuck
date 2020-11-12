using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public LayerMask groundLayer;


    public bool platformMover;
    public int direction = 1;
    public float speed;

    private void Update()
    {
        if (IsGrounded())
        {
            transform.position = new Vector2(transform.position.x + speed * direction * Time.deltaTime, transform.position.y);
        }
        else
        {
            direction *= -1;
            transform.position = new Vector2(transform.position.x + speed * direction * Time.deltaTime, transform.position.y);
        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            Debug.Log("bateu com chão");
            return true;
        }
        Debug.Log(hit);
        return false;
    }



}
