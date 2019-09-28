using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFish : MonoBehaviour
{
    public Vector3 direction { get; set; }

    public float speedMin { get; set; }
    public float speedMax { get; set; }

    private float speed;
    private float posY;
    private float elapsedTime;
    private Vector3 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedMin, speedMax);
        posY = transform.position.y;
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - oldPos;
        oldPos = transform.position;

        elapsedTime += Time.deltaTime;
        transform.Translate(direction * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, posY + Mathf.PingPong(elapsedTime * 5, 20), transform.position.z);

        transform.rotation = Quaternion.LookRotation(diff);
    }
}
