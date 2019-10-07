using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        CinemachineDollyCart cart;
        [SerializeField]
        private float speed;

        float posOld;
        // Start is called before the first frame update
        void Start()
        {
            posOld = cart.m_Position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            cart.m_Position += speed * Time.fixedDeltaTime;
        }
    }
}
