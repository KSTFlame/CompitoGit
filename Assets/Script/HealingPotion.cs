using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    [SerializeField] private float m_HealingValue;
    [SerializeField] private int m_Quantity;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && m_Quantity > 0)
        {
            GetComponent<Health>().AddHealth(m_HealingValue);
            m_Quantity --;
        }

    }
}
