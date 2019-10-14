using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType
{

}


public class EnemyBase : MonoBehaviour
{
    protected ColorType color;

    // Start is called before the first frame update
    protected virtual void Start() { }

    // Update is called once per frame
    protected virtual void Update() { }

    protected virtual void Movement() { }
    protected virtual void Attack() { }

    public virtual void DamageEffect() { }
}
