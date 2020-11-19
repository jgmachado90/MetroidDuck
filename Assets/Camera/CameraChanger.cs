using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{

    public float speed = 1.0f;
    public Transform target;
    public bool willMove = false;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        target.position = new Vector3(target.position.x, target.position.y, -10f);
        willMove = true;
    }

    private void Update()
    {
        if (willMove)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                //target.position *= -1.0f;
                willMove = false;

            }
        }
    }



}
