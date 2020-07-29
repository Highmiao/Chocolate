using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public KeyCode fire1;
    public KeyCode fire2;
    public KeyCode reloadKey;
    public Color weaponColor;
    public int fireDistance;
    public int playerID;
    public int ammoNumMax;
    public int attack1Cost;
    public int attack2Cost;
    public float fire1CoolDown;
    public float fire2CoolDown;
    public float reloadCoolDown;
    public int onceReloadNum;
    public PlayerBase player;

    protected float m_curCoolDown;
    protected float m_fireTimer;
    protected bool m_inCoolDown;

    protected float m_reloadTimer;
    protected bool m_canReload;

    protected int m_ammoNumRemain;

    private void Start()
    {
        SetAmmo(ammoNumMax);
    }

    public bool IsFire()
    {
        return Input.GetKey(fire1) || Input.GetKey(fire2);
    }

    public int GetFireType()
    {
        if (Input.GetKey(fire1))
        {
            return 1;
        }
        else if (Input.GetKey(fire2))
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }

    public void AddAmmo(int _num)
    {
        m_ammoNumRemain += _num;
        if (m_ammoNumRemain > ammoNumMax)
        {
            m_ammoNumRemain = ammoNumMax;
        }
        UIManager.s_instance.SetAmmo(playerID, m_ammoNumRemain, (float)m_ammoNumRemain / ammoNumMax);
    }

    public void SetAmmo(int _num)
    {
        m_ammoNumRemain = _num;
        if (m_ammoNumRemain > ammoNumMax)
        {
            m_ammoNumRemain = ammoNumMax;
        }
        UIManager.s_instance.SetAmmo(playerID, m_ammoNumRemain, m_ammoNumRemain / ammoNumMax);
    }

    public bool IsAmmoMax()
    {
        return m_ammoNumRemain == ammoNumMax ? true : false;
    }

    public void CoolDownUpdate(float _time)
    {
        if (!m_inCoolDown)
        {
            return;
        }
        m_fireTimer += _time;
        if (m_fireTimer >= m_curCoolDown)
        {
            m_fireTimer = 0;
            m_inCoolDown = false;
            player.HideFireCoolDown();
            return;
        }
        player.ShowFireCoolDown();
        player.SetFireCoolDown((float)(m_curCoolDown - m_fireTimer) / m_curCoolDown);
    }

    public void ReloadCoolDownUpdate(float _time)
    {
        m_reloadTimer += _time;
        if (m_reloadTimer >= reloadCoolDown)
        {
            m_reloadTimer = 0;
            AddAmmo(onceReloadNum);
        }
        player.SetReloadCoolDown((m_reloadTimer / reloadCoolDown));
    }

    public void ResetReloadCoolDown()
    {
        m_reloadTimer = 0;
        player.SetReloadCoolDown((m_reloadTimer / reloadCoolDown));
    }

    public void CanReload(bool _state)
    {
        m_canReload = _state;
    }

    public bool CanReload()
    {
        return m_canReload;
    }

    public bool IsReloading()
    {
        return Input.GetKey(reloadKey);
    }

    public virtual void Fire1(FaceDirType _dir, int _x, int _y, GameObject _otherPlayer)
    {
        
    }

    public virtual void Fire2(FaceDirType _dir, int _x, int _y, GameObject _otherPlayer, Vector3 _aimPos)
    {
        
    }
}
