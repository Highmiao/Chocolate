using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReloadCoolDown : MonoBehaviour
{
    public Image reloadCoolDownImg;

    public void SetFill(float _rate)
    {
        reloadCoolDownImg.fillAmount = _rate;
    }

    public void Show()
    {
        reloadCoolDownImg.gameObject.SetActive(true);
    }

    public void Hide()
    {
        reloadCoolDownImg.gameObject.SetActive(false);
    }
}
