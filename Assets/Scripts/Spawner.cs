using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnables;
    [SerializeField] Vector3 spawnPos = new Vector3 (-6, 1.04f, 0);
    private GameManager gameManager;
    public float spawnDelay = 2, spawnRate = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        InvokeRepeating("spawnRandomObjects", spawnDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnRandomObjects()
    {
        if (gameManager.gameOver == false)
        {
            GameObject spawnedObject = spawnables[Random.Range(0, spawnables.Length)];
            Instantiate(spawnedObject, spawnPos, spawnedObject.transform.rotation);
        }
    }
}
