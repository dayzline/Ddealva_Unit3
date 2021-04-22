using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsPrefab;
    private Vector3 spawn = new Vector3(30, 0, 0);
    private PlayerController p1;

    void Start()
    {
        InvokeRepeating("SpawnObs", 2, 2);
        p1 = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void SpawnObs()
    {
        if (p1.gameOver == false)
        {
            Instantiate(obsPrefab, spawn, obsPrefab.transform.rotation);
        }
    }
}
