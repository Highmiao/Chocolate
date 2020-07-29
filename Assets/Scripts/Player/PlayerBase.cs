using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public PlayerMovement movement;
    public WeaponBase weapon;
    public PlayerAim aim;
    public UIFireCoolDown fireCoolDown;
    public UIReloadCoolDown reloadCoolDown;

    private GameObject m_otherPlayer;

    private void FixedUpdate()
    {
        if (!GameManager.s_instance.IsGameStart())
        {
            return;
        }
        if (GameManager.s_instance.IsGameEnd())
        {
            return;
        }

        movement.CheckMove();

        FaceDirType dir = movement.CheckFaceDir();

        int x, y;
        movement.GetArrayPos(out x, out y);

        Vector3 aimPos = aim.SetAimPos(dir, x, y);

        weapon.CoolDownUpdate(Time.deltaTime);

        if (weapon.IsFire())
        {
            int type = weapon.GetFireType();
            switch (type)
            {
                case 0:
                    break;
                case 1:
                    weapon.Fire1(dir, x, y, m_otherPlayer);
                    break;
                case 2:
                    weapon.Fire2(dir, x, y, m_otherPlayer, aimPos);
                    break;
                default:
                    break;
            }
        }

        if (weapon.CanReload() 
            && !weapon.IsAmmoMax() 
            && weapon.IsReloading())
        {
            reloadCoolDown.Show();
            weapon.ReloadCoolDownUpdate(Time.deltaTime);
        }
        else
        {
            weapon.ResetReloadCoolDown();
            reloadCoolDown.Hide();
        }
    }

    public void SetFireCoolDown(float _rate)
    {
        fireCoolDown.SetFill(_rate);
    }

    public void ShowFireCoolDown()
    {
        fireCoolDown.Show();
    }

    public void HideFireCoolDown()
    {
        fireCoolDown.Hide();
    }

    public void SetReloadCoolDown(float _rate)
    {
        reloadCoolDown.SetFill(_rate);
    }

    public void ShowReloadCoolDown()
    {
        reloadCoolDown.Show();
    }

    public void HideReloadCoolDown()
    {
        reloadCoolDown.Hide();
    }

    public void SetData(GameObject _other)
    {
        m_otherPlayer = _other;
    }
}
