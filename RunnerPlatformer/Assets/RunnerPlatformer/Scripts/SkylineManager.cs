using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerPlatformer
{
    public class SkylineManager : MonoBehaviour
    {
        [SerializeField] private Transform m_Prefab;

        [SerializeField]
        private int m_NumberOfObjects;

        [SerializeField]
        private float m_RecycleOffset;
        [SerializeField]
        private Vector3 m_StartPosition;

        private Vector3 m_NextPosition;

        private Queue<Transform> m_ObjectQueue;


        [SerializeField]
        private Vector3 m_MinSize, m_MaxSize;

        void Start()
        {
            m_ObjectQueue = new Queue<Transform>(m_NumberOfObjects);

            for (int i = 0; i < m_NumberOfObjects; i++)
            {
                m_ObjectQueue.Enqueue((Transform)Instantiate(m_Prefab));
            }

            m_NextPosition = m_StartPosition;

            // Instance objects
            for (int i = 0; i < m_NumberOfObjects; i++)
            {
                Recycle();
            }

        }

        private void Recycle()
        {

            Vector3 scale = new Vector3(
            Random.Range(m_MinSize.x, m_MaxSize.x),
            Random.Range(m_MinSize.y, m_MaxSize.y),
            Random.Range(m_MinSize.z, m_MaxSize.z));

            Vector3 position = m_NextPosition;
            position.x += scale.x * 0.5f;
            position.y += scale.y * 0.5f;

            Transform o = m_ObjectQueue.Dequeue();
            o.localScale = scale;
            o.localPosition = position;
            m_NextPosition.x += scale.x;
            m_ObjectQueue.Enqueue(o);
        }


        void Update()
        {
            // Change teh position
            if (m_ObjectQueue.Peek().localPosition.x + m_RecycleOffset < Runner.m_DistanceTraveled)
            {
                Recycle();
            }
        }

    }
}
