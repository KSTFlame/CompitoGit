using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health m_PlayerHeath;
    [SerializeField] private Image m_TotalHealthbar;
    [SerializeField] private Image m_CurrentHealthbar;

    private void Start()
    {
        m_TotalHealthbar.fillAmount = m_PlayerHeath.m_CurrentHealth / 10;
    }

    private void Update()
    {
        m_CurrentHealthbar.fillAmount = m_PlayerHeath.m_CurrentHealth / 10;
    }
}
