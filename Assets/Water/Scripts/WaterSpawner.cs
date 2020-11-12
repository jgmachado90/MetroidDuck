using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{

    public float spawnDelay;
    public List<GameObject> waterPieces;
    public GameObject jellyFish;
    public float maxWaterPieceScale;
    public bool willJelly = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaterSpawnerCoroutine());
        if(willJelly)
            StartCoroutine(JellyFishSpawnerCoroutine());
    }

    public IEnumerator WaterSpawnerCoroutine()
    {
        while (true)
        {
           
            yield return new WaitForSeconds(spawnDelay);
            GameObject waterPiece = Instantiate(waterPieces[UnityEngine.Random.Range(0, waterPieces.Count)], transform.position, Quaternion.identity, transform);
            waterPiece.transform.localScale = new Vector3(waterPiece.transform.localScale.x * UnityEngine.Random.Range(0.5f, maxWaterPieceScale), waterPiece.transform.localScale.y * UnityEngine.Random.Range(0.5f, maxWaterPieceScale), waterPiece.transform.localScale.z);
            waterPiece.transform.position = new Vector3(transform.position.x, transform.position.y + UnityEngine.Random.Range(-1f, 2f), transform.position.z);
        }
    }

    public IEnumerator JellyFishSpawnerCoroutine()
    {
        while (true)
        {

            yield return new WaitForSeconds(3f);
            GameObject waterPiece = Instantiate(jellyFish, transform.position, Quaternion.identity, transform);
            //waterPiece.transform.localScale = new Vector3(waterPiece.transform.localScale.x * UnityEngine.Random.Range(0.5f, maxWaterPieceScale), waterPiece.transform.localScale.y * UnityEngine.Random.Range(0.5f, maxWaterPieceScale), waterPiece.transform.localScale.z * UnityEngine.Random.Range(0.5f, maxWaterPieceScale));
            waterPiece.transform.position = new Vector3(transform.position.x, transform.position.y + UnityEngine.Random.Range(1.5f, 2.5f), transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
