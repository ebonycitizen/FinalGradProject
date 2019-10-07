using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveObject : MonoBehaviour
{
    [SerializeField]
    private float switchOnSpeed;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private ParticleSystem startEffect;
    [SerializeField]
    private ParticleSystem switchOnEffect;
    [SerializeField]
    private GameObject lightSphere;

    private Collider collider;
    private Animator animator;
    private Renderer renderer;

    private float curTime;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;

        renderer = GetComponent<Renderer>();
        renderer.material.SetFloat("_SeparationHeight", -1);

        animator = GetComponent<Animator>();

        curTime = -1f;
        lightSphere.SetActive(false);
    }

    private void EnableSwitch()
    {
        collider.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EnableSwitch", 1);
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
        //vrで消す
        if (Input.GetMouseButton(0))
        {
            if (curTime >= 1 && Input.GetMouseButtonDown(1))
            {
                SwitchOn();
                return;
            }
            curTime += switchOnSpeed * Time.deltaTime;
            LightUp();
        }
    }

    private void MoveDown()
    {
        if (transform.localPosition.y < -5)
            return;

        transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void LightUp()
    {
        float height = Mathf.Clamp(curTime, -1, 1);
        renderer.material.SetFloat("_SeparationHeight", height);
    }

    private void SwitchOn()
    {
        switchOnEffect.Play();
        lightSphere.SetActive(true);
        collider.enabled = false;
        animator.enabled = false;
        renderer.enabled = false;
        Destroy(gameObject, 1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (curTime >= 1)
        {
            startEffect.loop = false;
            SwitchOn();
            return;
        }

        curTime += switchOnSpeed * Time.deltaTime;
        LightUp();
    }
}
