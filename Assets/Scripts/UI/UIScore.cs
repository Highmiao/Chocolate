using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Text Player1ScoreText;
    public Text Player2ScoreText;

    public void SetScore(int _player1, int _player2)
    {
        Player1ScoreText.text = "Player1 : " + _player1;
        Player2ScoreText.text = "Player2 : " + _player2;
    }
}
