using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFishSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPrefab;

    [SerializeField]
    private float rateOverTime;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime;

    [SerializeField]
    private Vector3 spawnSize;


    private IEnumerator Spawn()
    {
        while(true)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, transform.position + spawnSize);
    }
}
