using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public int PlayerLayer;
    private PlayerBase m_player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == PlayerLayer)
        {
            if (m_player == null)
            {
                m_player = other.GetComponent<PlayerBase>();
            }
            m_player.weapon.CanReload(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == PlayerLayer)
        {
            if (m_player == null)
            {
                m_player = other.GetComponent<PlayerBase>();
            }
            m_player.weapon.CanReload(false);
        }
    }
}
