using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsPrefab;
    private Vector3 spawn = new Vector3(15, 0, 0);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("SpawnObs", 2, 2);
    }

    void SpawnObs()
    {
         Instantiate(obsPrefab, spawn, obsPrefab.transform.rotation);
    }
}
