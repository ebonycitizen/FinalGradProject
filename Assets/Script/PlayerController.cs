using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Grab hand;
    [SerializeField]
    private GameObject[] cores;//完全体のコア数
    [SerializeField]
    private int defaultCore; //元々あるコア数

    private int currentLightIndex;//今光ってるコア数
    private List<GameObject> currentCoreNum;//今所持コア数

    private GameObject target;//獲物
    private bool hasAdd;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        hasAdd = false;
        currentLightIndex = 0;
        currentCoreNum = new List<GameObject>();

        for (int i = 0; i < defaultCore; i++)
        {
            currentCoreNum.Add(cores[i]);
            currentCoreNum[i].GetComponentInChildren<Core>().Disappear();
        }

        for (int i = defaultCore; i < cores.Length; i++)
            cores[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        if(hand.HasGrab() || Input.GetMouseButtonDown(1))
        {
            target.GetComponent<EnemyBase>().DamageEffect();
            StopAllCoroutines();
            StartCoroutine("LightCore");

            target = null;
        }
    }

    private IEnumerator LightCore()
    {
        if (currentCoreNum.Count == cores.Length)
            yield break;

        int index = 0;

        while (true)
        {
            if (index > currentLightIndex)
                break;

            if(index == currentCoreNum.Count)
                AddCore();

            currentCoreNum[index].GetComponentInChildren<Core>().Appear();
            currentCoreNum[index].GetComponent<Body>().Appear();
            index++;

            yield return new WaitForSeconds(0.1f);
        }

        currentLightIndex++;

        if (currentCoreNum.Count < cores.Length && hasAdd)
        {
            currentLightIndex = 0;
            yield return new WaitForSeconds(0.4f);
            ResetCore();
        }
    }

    private void AddCore()
    {
        cores[currentCoreNum.Count].SetActive(true);
        currentCoreNum.Add(cores[currentCoreNum.Count]);
        hasAdd = true;
    }
    private void ResetCore()
    {
        for (int i = 0; i < currentCoreNum.Count; i++)
            currentCoreNum[i].GetComponentInChildren<Core>().Disappear();
        hasAdd = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            target = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            target = null;
    }
}
