using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager s_instance;

    public int player1Score;
    public int player2Score;

    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
        }
        else if (s_instance != this)
        {
            Destroy(this.gameObject);
        }

    }

    public void AddScore(int _playerID, int _num)
    {
        if (player1Score + player2Score == 10)
        {
            if (_playerID == 1)
            {
                player1Score += _num;
                player2Score -= _num;
            }
            else
            {
                player1Score -= _num;
                player2Score += _num;
            }
        }
        else
        {
            if (_playerID == 1)
            {
                player1Score += _num;
            }
            else
            {
                player2Score += _num;
            }
        }

        UIManager.s_instance.SetScoreProcess(player1Score, (float)player1Score / 10, player2Score, (float)player2Score / 10);

        if (player1Score == 10 || player2Score == 10)
        {
            GameManager.s_instance.SetGameEnd(true);
        }
    }
	
    public int GetWinner()
    {
        if (player1Score > player2Score)
        {
            return 1;
        }
        else if (player2Score > player1Score)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }
}
