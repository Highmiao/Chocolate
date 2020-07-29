using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFireCoolDown : MonoBehaviour
{
    public Image coolDownImg;

    public void SetFill(float _rate)
    {
        coolDownImg.fillAmount = _rate;
    }

    public void Show()
    {
        coolDownImg.gameObject.SetActive(true);
    }

    public void Hide()
    {
        coolDownImg.gameObject.SetActive(false);
    }
}
