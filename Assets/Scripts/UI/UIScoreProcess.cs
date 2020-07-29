using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreProcess : MonoBehaviour
{
    public Image player1Img;
    public Image player2Img;
    public Text player1Text;
    public Text player2Text;

    public void SetPlayerScore(int _player1Num, float _player1Rate, int _player2Num, float _player2Rate)
    {
        player1Img.fillAmount = _player1Rate;
        player2Img.fillAmount = _player2Rate;
        player1Text.text = _player1Num.ToString();
        player2Text.text = _player2Num.ToString();
    }
	
}
