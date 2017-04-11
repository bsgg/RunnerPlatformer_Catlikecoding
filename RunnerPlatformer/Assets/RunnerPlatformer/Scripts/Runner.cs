using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerPlatformer
{ 
    public class Runner : MonoBehaviour
    {

        public static float m_DistanceTraveled;

        [SerializeField]
        private float m_Acceleration;

        private Rigidbody m_RigidBodyComponent;
        
        private bool m_TouchingPlatform;

        [SerializeField]
        private Vector3 m_JumpVelocity;

        private void Start()
        {
            m_RigidBodyComponent = GetComponent<Rigidbody>();
        }


        void Update()
        {
            //transform.Translate(5f * Time.deltaTime, 0f, 0f);

            if (m_TouchingPlatform && Input.GetButtonDown("Jump"))
            {
                m_RigidBodyComponent.AddForce(m_JumpVelocity, ForceMode.VelocityChange);
                m_TouchingPlatform = false;
            }

            m_DistanceTraveled = transform.localPosition.x;
        }

        private void FixedUpdate()
        {
            if (m_TouchingPlatform)
            {
                m_RigidBodyComponent.AddForce(m_Acceleration, 0.0f, 0.0f, ForceMode.Acceleration);
            }
        }

        void OnCollisionEnter()
        {
            m_TouchingPlatform = true;
        }

        void OnCollisionExit()
        {
            m_TouchingPlatform = false;
        }


    }
}
