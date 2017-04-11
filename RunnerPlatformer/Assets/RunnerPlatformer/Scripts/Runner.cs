using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerPlatformer
{ 
    public class Runner : MonoBehaviour
    {

        public static float m_DistanceTraveled;

        void Update()
        {
            transform.Translate(5f * Time.deltaTime, 0f, 0f);
            m_DistanceTraveled = transform.localPosition.x;
        }


    }
}
