using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class WaterPiece : MonoBehaviour
{
    public float speedX;
    public float maxSpeedX;
    public float maxY;
    public float minY;
    public float speedY;
    private int direction = 1;
    public bool falling = false;
    public float howEarlyFall;
    public bool isJelly;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!isJelly)
        {
            StartCoroutine(DelayedDestroy());
        }
        if (isJelly)
        {
            maxSpeedX = maxSpeedX * 2;
        }
        speedX = UnityEngine.Random.Range(maxSpeedX, maxSpeedX);
        speedY = UnityEngine.Random.Range(0.01f, 0.03f);
        if(UnityEngine.Random.Range(0 , 2) >= 1) { direction = 1;}
        else { direction = -1; }
        
        maxY = transform.position.y + 0.3f;
        minY = transform.position.y - 0.5f;
    }

    public IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(16f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + speedX, transform.position.y + (speedY * direction), transform.position.z);
        if (transform.position.y < minY && !falling)
            direction = 1;
        if (transform.position.y > maxY)
            direction = -1;
        if(transform.position.x > 0f - howEarlyFall)
        {
            falling = true;
            direction = -1;
            minY = -100f;
            speedY += 0.01f;
        }
    }


}
