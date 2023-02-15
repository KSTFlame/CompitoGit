using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float m_Speed; //Speed of the camera when u change area
    private float m_CurrentPosX; //To see where the camera is
    private Vector3 m_Velocity = Vector3.zero;

    [SerializeField] private Transform m_Player;

    private void Update()
    {
        transform.position = new Vector3(m_Player.position.x, transform.position.y, transform.position.z);
    }

    public void MoveToNewArea(Transform NewArea)
    {
        m_CurrentPosX = NewArea.position.x;
    }
}
