using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlide : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float m_MovementDistance;
    [SerializeField] private float m_Speed;
    private bool m_movingLeft;
    private float m_LeftEdge;
    private float m_RightEdge;

    private void Awake()
    {
        m_LeftEdge = transform.position.x - m_MovementDistance;
        m_RightEdge = transform.position.x + m_MovementDistance;
        m_movingLeft = true;
    }

    public void Update()
    {
        if (m_movingLeft)
            if (transform.position.x > m_LeftEdge)
            {
                transform.position = new Vector3(transform.position.x - m_Speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(1, 1, 1); //Flip to left
            }
            else
                m_movingLeft = false;

        else if (transform.position.x < m_RightEdge)
        {
            transform.position = new Vector3(transform.position.x + m_Speed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(-1, 1, 1);   //Flip to right
        }
        else
            m_movingLeft = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

 
}
