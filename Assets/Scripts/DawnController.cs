using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DawnController : MonoBehaviour
{
    [SerializeField] Rigidbody m_rigidbody = null;
    [SerializeField, Range(0.0f, 5000.0f)] float m_maxSpeed = 10.0f;
    [SerializeField, Range(0.0f, 50.0f)] float m_accToMax = 2.0f;

    Vector3 m_veloctiy = Vector3.zero;
    float m_acc = 0.0f;

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        m_acc = m_maxSpeed * m_accToMax;

        float inX = Input.GetAxis("Horizontal");
        float inZ = Input.GetAxis("Vertical");
        float abX = Mathf.Abs(inX);
        float abZ = Mathf.Abs(inZ);

        if (abX > 0.0f)
        {
            m_veloctiy.x += inX * Time.deltaTime * m_acc;
        }
        else
        {
            m_veloctiy.x = m_rigidbody.velocity.x;
        }

        if (abZ > 0.0f)
        {
            m_veloctiy.z += inZ * Time.deltaTime * m_acc;
        }
        else
        {
            m_veloctiy.z = m_rigidbody.velocity.z;
        }

        if (m_veloctiy.sqrMagnitude > m_maxSpeed * m_maxSpeed)
        {
            m_veloctiy = m_veloctiy.normalized * m_maxSpeed;
        }
        
        if (abX > 0.0f || abZ > 0.0f)
        {
            if (m_veloctiy.sqrMagnitude > 1.0f)
            {
                transform.forward = Vector3.Lerp(transform.forward, m_veloctiy, Time.deltaTime * 5.0f);
            }
        }
        //print(m_rigidbody.velocity.magnitude);

        m_rigidbody.AddForce(m_veloctiy, ForceMode.Force);
    }
}
