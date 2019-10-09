using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyFade : MonoBehaviour
{
    [SerializeField]
    private float delayTime;

    private EnemySpawn spawn;
    private float moveTime;
    private float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponentInParent<EnemySpawn>();
        moveTime = spawn.GetMoveTime();
        fadeTime = spawn.GetFadeTime();

        Material mat = GetComponent<MeshRenderer>().material;
        mat.DOFade(0, fadeTime).From();

        transform.DOLocalMoveY(transform.localPosition.y - 50.0f, moveTime).From().SetDelay(delayTime).SetEase(Ease.OutQuad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
