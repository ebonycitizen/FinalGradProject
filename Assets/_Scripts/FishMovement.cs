using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField]
    private List<Transform> bodyParts = new List<Transform>();

    [SerializeField]
    private float minDist = 0.25f;
    [SerializeField]
    private float speed = 1f;

    private Transform curBodyPart;
    private Transform prevBodyPart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //InputHandler();
        //Move();
    }

    private void InputHandler()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.up * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            transform.position -= Vector3.up * speed * Time.deltaTime;
    }

    private void Move()
    {
        if (bodyParts.Count < 2)
            return;

        for (int i = 1; i < bodyParts.Count; i++)
        {
            curBodyPart = bodyParts[i];
            prevBodyPart = bodyParts[i - 1];

            float dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newpos = prevBodyPart.position;

            float t = Time.deltaTime * dis / minDist * speed;

            if (t > 0.5f)
                t = 0.5f;

            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, t);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, t);
        }
    }
}
