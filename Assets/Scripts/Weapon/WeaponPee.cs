using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPee : WeaponBase
{
    public float pushForce1;
    public float pushForce2;
    public float fire1Dist;
    public float fire2Dist;

    public override void Fire1(FaceDirType _dir, int _x, int _y, GameObject _otherPlayer)
    {
        if (m_inCoolDown)
        {
            return;
        }

        if (m_ammoNumRemain < attack1Cost)
        {
            Debug.Log("not enough ammo");
            return;
        }
        Debug.Log("Fire1");
        AddAmmo(-attack1Cost);

        m_curCoolDown = fire1CoolDown;
        m_inCoolDown = true;

        SoundManager.s_instance.PlayShoot();

        PushPlayer(_otherPlayer, Vector3.zero);


        switch (_dir)
        {
            case FaceDirType.mdtNone:
                break;
            case FaceDirType.mdtUp:
                UpFire1(_x, _y);
                break;
            case FaceDirType.mdtDown:
                DownFire1(_x, _y);
                break;
            case FaceDirType.mdtLeft:
                LeftFire1(_x, _y);
                break;
            case FaceDirType.mdtRight:
                RightFire1(_x, _y);
                break;
            case FaceDirType.mdtUpLeft:
                UpLeftFire1(_x, _y);
                break;
            case FaceDirType.mdtUpRight:
                UpRightFire1(_x, _y);
                break;
            case FaceDirType.mdtDownLeft:
                DownLeftFire1(_x, _y);
                break;
            case FaceDirType.mdtDownRight:
                DownRightFire1(_x, _y);
                break;
            default:
                break;
        }

    }

    private void UpFire1(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x , _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y + 2, weaponColor, playerID);
    }

    private void DownFire1(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y - 2, weaponColor, playerID);
    }

    private void LeftFire1(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 2, _y, weaponColor, playerID);
    }

    private void RightFire1(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 2, _y, weaponColor, playerID);
    }

    private void UpLeftFire1(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x , _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y + 1, weaponColor, playerID);
    }

    private void UpRightFire1(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y + 1, weaponColor, playerID);
    }

    private void DownLeftFire1(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y - 1, weaponColor, playerID);
    }

    private void DownRightFire1(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y - 1, weaponColor, playerID);
    }

    public override void Fire2(FaceDirType _dir, int _x, int _y, GameObject _otherPlayer, Vector3 _aimPos)
    {
        if (m_inCoolDown)
        {
            return;
        }

        if (m_ammoNumRemain < attack2Cost)
        {
            Debug.Log("not enough ammo");
            return;
        }
        Debug.Log("Fire2");
        AddAmmo(-attack2Cost);

        m_curCoolDown = fire2CoolDown;
        m_inCoolDown = true;

        SoundManager.s_instance.PlayShoot();

        PushPlayer(_otherPlayer, _aimPos);

        switch (_dir)
        {
            case FaceDirType.mdtNone:
                break;
            case FaceDirType.mdtUp:
                UpFire2(_x, _y);
                break;
            case FaceDirType.mdtDown:
                DownFire2(_x, _y);
                break;
            case FaceDirType.mdtLeft:
                LeftFire2(_x, _y);
                break;
            case FaceDirType.mdtRight:
                RightFire2(_x, _y);
                break;
            case FaceDirType.mdtUpLeft:
                UpLeftFire2(_x, _y);
                break;
            case FaceDirType.mdtUpRight:
                UpRightFire2(_x, _y);
                break;
            case FaceDirType.mdtDownLeft:
                DownLeftFire2(_x, _y);
                break;
            case FaceDirType.mdtDownRight:
                DownRightFire2(_x, _y);
                break;
            default:
                break;
        }
    }

    private void UpFire2(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x - 1, _y + fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y + fireDistance + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y + fireDistance + 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y + fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y + fireDistance + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y + fireDistance + 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y + fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y + fireDistance + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y + fireDistance + 2, weaponColor, playerID);
    }

    private void DownFire2(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x - 1, _y - fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y - fireDistance - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 1, _y - fireDistance - 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y - fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y - fireDistance - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x, _y - fireDistance - 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y - fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y - fireDistance - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 1, _y - fireDistance - 2, weaponColor, playerID);
    }

    private void LeftFire2(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x - fireDistance, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - fireDistance - 1, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - fireDistance - 2, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - fireDistance, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - fireDistance - 1, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - fireDistance - 2, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - fireDistance, _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - fireDistance - 1, _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - fireDistance - 2, _y + 1, weaponColor, playerID);
    }

    private void RightFire2(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x + fireDistance, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + fireDistance + 1, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + fireDistance + 2, _y - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + fireDistance, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + fireDistance + 1, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + fireDistance + 2, _y, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + fireDistance, _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + fireDistance + 1, _y + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + fireDistance + 2, _y + 1, weaponColor, playerID);
    }

    private void UpLeftFire2(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x - 2, _y + fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 3, _y + fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 4, _y + fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 2, _y + fireDistance - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 3, _y + fireDistance - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 4, _y + fireDistance - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 2, _y + fireDistance - 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 3, _y + fireDistance - 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 4, _y + fireDistance - 2, weaponColor, playerID);
    }

    private void UpRightFire2(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x + 2, _y + fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 3, _y + fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 4, _y + fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 2, _y + fireDistance - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 3, _y + fireDistance - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 4, _y + fireDistance - 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 2, _y + fireDistance - 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 3, _y + fireDistance - 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 4, _y + fireDistance - 2, weaponColor, playerID);
    }

    private void DownLeftFire2(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x - 2, _y - fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 3, _y - fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 4, _y - fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 2, _y - fireDistance + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 3, _y - fireDistance + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 4, _y - fireDistance + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 2, _y - fireDistance + 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 3, _y - fireDistance + 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x - 4, _y - fireDistance + 2, weaponColor, playerID);
    }

    private void DownRightFire2(int _x, int _y)
    {
        MapManager.s_instance.SetColor(_x + 2, _y - fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 3, _y - fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 4, _y - fireDistance, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 2, _y - fireDistance + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 3, _y - fireDistance + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 4, _y - fireDistance + 1, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 2, _y - fireDistance + 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 3, _y - fireDistance + 2, weaponColor, playerID);
        MapManager.s_instance.SetColor(_x + 4, _y - fireDistance + 2, weaponColor, playerID);
    }

    private void PushPlayer(GameObject _otherPlayer, Vector3 _aimPos)
    {
        if (_aimPos == Vector3.zero)
        {
            if (Vector3.Distance(_otherPlayer.transform.position, transform.position) <= fire1Dist)
            {
                _otherPlayer.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(_otherPlayer.transform.position - transform.position) * pushForce1, ForceMode.Impulse);
                ScoreManager.s_instance.AddScore(playerID, 1);
                Debug.Log("push");
                SoundManager.s_instance.PlayPush();
            }
        }
        else
        {
            if (Vector3.Distance(_otherPlayer.transform.position, _aimPos) <= fire2Dist)
            {
                _otherPlayer.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(_otherPlayer.transform.position - transform.position) * pushForce2, ForceMode.Impulse);
                ScoreManager.s_instance.AddScore(playerID, 1);
                Debug.Log("push");
                SoundManager.s_instance.PlayPush();
            }
        }
        Debug.Log("push end");
    }
}
