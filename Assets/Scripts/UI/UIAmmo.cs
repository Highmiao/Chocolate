using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
    public Image player1AmmoImg;
    public Image player2AmmoImg;
    public Text player1AmmoText;
    public Text player2AmmoText;

    public void SetAmmoNum(int _playerID, int _num, float _rate)
    {
        if (_playerID == 1)
        {
            player1AmmoImg.fillAmount = _rate;
            player1AmmoText.text = _num.ToString();
        }
        else
        {
            player2AmmoImg.fillAmount = _rate;
            player2AmmoText.text = _num.ToString();
        }
    }
}
