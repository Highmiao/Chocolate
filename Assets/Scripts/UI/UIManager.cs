using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager s_instance;

    public UITimer timer;
    public UIScore score;
    public UIAmmo ammo;
    public UIScoreProcess scoreProcess;
    public UIGameEnd gameEnd;
    public GameObject startBtn;

    public CanvasGroup canvasGroup;

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

    public void SetTime(float _time)
    {
        timer.SetTime(_time);
    }

    public void SetScore(int _player1, int _player2)
    {
        score.SetScore(_player1, _player2);
    }

    public void SetAmmo(int _playerID, int _num, float _rate)
    {
        ammo.SetAmmoNum(_playerID, _num, _rate);
    }

    public void SetScoreProcess(int _player1Num, float _player1Rate, int _player2Num, float _player2Rate)
    {
        scoreProcess.SetPlayerScore(_player1Num, _player1Rate, _player2Num, _player2Rate);
    }

    public void ShowGameEnd(string _content)
    {
        gameEnd.ShowText(_content);
    }

    public void HideGameEnd(string _content)
    {
        gameEnd.HideText(_content);
    }

    public void HideStartBtn()
    {
        startBtn.SetActive(false);
    }

    public void ShowUI()
    {
        canvasGroup.DOFade(1f, 0.5f);
        //canvasGroup.alpha = 1;
    }
}
