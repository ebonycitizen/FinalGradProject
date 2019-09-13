using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using DG.Tweening;
using System;
using UniRx.Triggers;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


public class JellyFishSpwaner : MonoBehaviour
{
    [SerializeField] private int maxSpwanCount = 20;

    [SerializeField] private JellyFish m_jellyfish = null;

    [SerializeField] private float spawnCount = 10;

    [SerializeField] private float spawnRange = 20;

    [SerializeField] private float spawnInterval = 10;

    [SerializeField] private float spawnMinHeight = 0;

    [SerializeField] private float spawnMaxHeight = 10;

    [SerializeField] private float spawnScaleMin = 1;

    [SerializeField] private float spawnScaleMax = 2;

    [SerializeField] private float spawnRotationMin = 5;

    [SerializeField] private float spwanRotationMax = 10;

    [SerializeField] private string deleteTag = "Clean";

    [Range(0, 5)] [SerializeField] private float rotateStartTimeMin = 0;

    [Range(5, 10)] [SerializeField] private float rotateStartTimeMax = 5;

    private List<JellyFish> jellyFishList = new List<JellyFish>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject jellyFishLists = new GameObject("JellyFishList");

        Observable.Timer(System.TimeSpan.FromSeconds(1), System.TimeSpan.FromSeconds(spawnInterval))
            .Where(_ => jellyFishList.Count < maxSpwanCount)
            .Subscribe(_ => CreateJellyFish(jellyFishLists))
            .AddTo(this.transform);
    }

    private void CreateJellyFish(GameObject parent)
    {
        for (int i = 0; i <= spawnCount; i++)
        {
            var randomXzIncrement = Random.insideUnitCircle * spawnRange;

            var randomYIncrement = Random.Range(spawnMinHeight, spawnMaxHeight);

            var randomSize = Random.Range(spawnScaleMin, spawnScaleMax);

            var randomRotation = Random.Range(spawnRotationMin, spwanRotationMax);

            var randomRotateStartTime = Random.Range(rotateStartTimeMin, rotateStartTimeMax);

            var bornPosition = this.transform.position + new Vector3(randomXzIncrement.x, randomYIncrement, randomXzIncrement.y);

            var jellyfishPrefab = Instantiate(m_jellyfish) as JellyFish;

            jellyfishPrefab.transform.parent = parent.transform;

            var shouldChangeValue = Random.Range(0, 2);
            
            if (shouldChangeValue == 0)
            {
                jellyfishPrefab.SetUp(randomSize, randomRotation, randomRotateStartTime, bornPosition, false);
            }
            else
            {
                jellyfishPrefab.SetUp(randomSize, randomRotation, randomRotateStartTime, bornPosition, true);
            }

            jellyfishPrefab.OnTriggerEnterAsObservable()
                .Where(x => x.gameObject.tag == deleteTag)
                .Subscribe(_ =>
            {
                Destroy(jellyfishPrefab.gameObject);
                jellyFishList.Remove(jellyfishPrefab);
            }).AddTo(this);

            jellyfishPrefab.GetComponent<JellyFish>().OnStart();
            
            jellyFishList.Add(jellyfishPrefab);
        }

    }
}
