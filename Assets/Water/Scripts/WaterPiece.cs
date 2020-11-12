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
    public float minimestY;
    public bool wontFall;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {

        if (!isJelly)
        {
            StartCoroutine(DelayedDestroy());
        }
        if (isJelly)
        {
            Debug.Log("I M JELLY" + gameObject, gameObject);
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
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < minimestY)
        {
            Destroy(this.gameObject);
        }

        transform.position = new Vector3(transform.position.x + speedX, transform.position.y + (speedY * direction), transform.position.z);
        if (transform.position.y < minY && !falling)
            direction = 1;
        if (transform.position.y > maxY)
            direction = -1;
        

        if(!wontFall && transform.position.x > 0f - howEarlyFall)
        {
            falling = true;
            direction = -1;
            minY = -100f;
            speedY += 0.01f;
            if(speedX > 0)
            {
                speedX -= 0.01f;
            }
            else
            {
                speedX = 0;
            }
        }
    }



}
