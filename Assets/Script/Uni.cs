﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uni : EnemyBase
{
    [SerializeField]
    private ParticleSystem deadEffect;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void DamageEffect()
    {
        deadEffect.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(transform.gameObject, 1);
    }
}
