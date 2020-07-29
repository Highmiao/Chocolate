using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager s_instance;

    public MapManager mapManager;
    public GameObject playerPrefab_1;
    public GameObject playerPrefab_2;
    public Transform playerBornPos_1;
    public Transform playerBornPos_2;
    public GameObject homePrefab_1;
    public GameObject homePrefab_2;
    public Transform homePos_1;
    public Transform homePos_2;
    public GameObject BGPrefab;

    private float m_timer;
    public float timeMax;
    private bool m_gameEnd;
    private bool m_gameStart;

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

        m_gameEnd = false;
        m_gameStart = false;
    }

    private void Start()
    {
        m_timer = timeMax;
        mapManager.CreateMap();
        Instantiate(BGPrefab);
        GameObject player1 = Instantiate(playerPrefab_1, playerBornPos_1.position, Quaternion.identity);
        GameObject player2 = Instantiate(playerPrefab_2, playerBornPos_2.position, Quaternion.identity);
        player1.GetComponent<PlayerBase>().SetData(player2);
        player2.GetComponent<PlayerBase>().SetData(player1);
        Instantiate(homePrefab_1, homePos_1.position, Quaternion.identity);
        Instantiate(homePrefab_2, homePos_2.position, Quaternion.identity);
    }

    public void StartView()
    {
        UIManager.s_instance.HideStartBtn();
        SoundManager.s_instance.PlayBG();
        Camera.main.GetComponent<CameraController>().ChangeView1(()=> {
            SetGameStart(true);
            UIManager.s_instance.ShowUI();
        });
    }

    private void Update()
    {
        if (!m_gameStart)
        {
            return;
        }
        if (m_gameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
            return;
        }
        if (m_timer <= 0 && !m_gameEnd)
        {
            SetGameEnd(true);
            return;
        }
        m_timer -= Time.deltaTime;
        UIManager.s_instance.SetTime(m_timer);
    }

    private void OnGameEnd()
    {
        //int player1, player2;
        //MapManager.s_instance.GetScore(out player1, out player2);

        //UIManager.s_instance.SetScore(player1, player2);
        int winnner = ScoreManager.s_instance.GetWinner();
        string content = "";
        if (winnner == 0)
        {
            content = "Tied";
        }
        else if (winnner == 1)
        {
            content = "Player 1 Win";
        }
        else
        {
            content = "Player 2 Win";
        }
        UIManager.s_instance.ShowGameEnd(content);
    }

    public void SetGameEnd(bool _state)
    {
        m_gameEnd = _state;
        OnGameEnd();
    }

    public bool IsGameEnd()
    {
        return m_gameEnd;
    }

    public void SetGameStart(bool _state)
    {
        m_gameStart = _state;
    }

    public bool IsGameStart()
    {
        return m_gameStart;
    }
}
