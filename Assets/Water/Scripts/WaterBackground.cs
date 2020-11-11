using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBackground : MonoBehaviour
{
    public float speedY;
    private int direction = 1;
    public float maxY;
    public float minY;
    // Start is called before the first frame update
    void Start()
    {
        if (UnityEngine.Random.Range(0, 2) >= 1) { direction = 1; }
        else { direction = -1; }
        speedY = UnityEngine.Random.Range(0.009f, 0.01f);
        maxY = transform.position.y + 0.5f;
        minY = transform.position.y - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (speedY * direction), transform.position.z);
        if (transform.position.y < minY)
            direction = 1;
        if (transform.position.y > maxY)
            direction = -1;
    }
}
