using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager s_instance;

    public Transform cellParentTF;
    public GameObject cellPrefab;
    public GameObject planePrefab;
    public float cellSize;
    public int mapWidth;
    public int mapHeight;

    private Material[][] m_cellMRs;
    private Collider[][] m_cellColliders;

    private int m_player1Score;
    private int m_player2Score;

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

    public void CreateMap()
    {
        CreateMap(mapWidth, mapHeight);
    }

    private void CreateMap(int _width, int _height)
    {
        //初始化
        m_cellMRs = new Material[_height][];
        m_cellColliders = new Collider[_height][];
        //生成地图
        Vector3 position = new Vector3(0, 0, 0);
        for (int i = 0; i < _height; i++)
        {
            m_cellMRs[i] = new Material[_width];
            m_cellColliders[i] = new Collider[_width];
            position.z = i * cellSize;
            for (int j = 0; j < _width; j++)
            {
                position.x = j * cellSize;
                GameObject pixel = CreateCell(position, cellParentTF);
                pixel.transform.localScale = new Vector3(1, 1, 1) * cellSize;
                m_cellMRs[i][j] = pixel.GetComponentInChildren<MeshRenderer>().material;
                m_cellColliders[i][j] = pixel.GetComponentInChildren<Collider>();
                //m_cellColliders[i][j].enabled = false;
            }
        }

        //GameObject plane = CreatePlane(_width, _height, cellParentTF);
        //plane.transform.GetChild(0).localScale = new Vector3(cellSize * _width, cellSize * _height, 0.1f);
    }

    //private IEnumerator IECreateMap(int _width, int _height)
    //{
    //    //初始化
    //    m_pixelMRs = new Material[_width * _height];
    //    //生成地图
    //    int count = 0;
    //    Vector3 position = new Vector3(0, 0, 0);
    //    for (int i = 0; i < _height; i++)
    //    {
    //        position.z = i * pixelSize;
    //        for (int j = 0; j < _width; j++)
    //        {
    //            position.x = j * pixelSize;
    //            GameObject pixel = CreatePixel(position, pixelParentTF);
    //            m_pixelMRs[count] = pixel.GetComponentInChildren<MeshRenderer>().material;
    //            count++;
    //            yield return null;
    //        }
    //    }
    //}

    private GameObject CreateCell(Vector3 _position, Transform _parent)
    {
        return Instantiate(cellPrefab, _position, Quaternion.identity, _parent);
    }

    private GameObject CreatePlane(int _width, int _height, Transform _parent)
    {
        float x = (_width * cellSize) * 0.5f - 0.05f;
        float y = (_height * cellSize) * 0.5f - 0.05f;
        return Instantiate(planePrefab, new Vector3(x, 0, y), Quaternion.identity, _parent);
    }

    public void SetColor(int _x, int _y, Color _color, int _player)
    {
        if (m_cellMRs[_y][_x].color == Color.white)
        {
            if (_player == 1)
            {
                AddPlayerScore(1, 1);
            }
            else
            {
                AddPlayerScore(2, 1);
            }
        }
        else if (m_cellMRs[_y][_x].color != _color)
        {
            if (_player == 1)
            {
                AddPlayerScore(1, 1);
                AddPlayerScore(2, -1);
            }
            else
            {
                AddPlayerScore(1, -1);
                AddPlayerScore(2, 1);
            }
        }
        m_cellMRs[_y][_x].color = _color;
        if (_player == 1)
        {
            SetCollider(_x, _y, 11);
        }
        else
        {
            SetCollider(_x, _y, 12);
        }
    }

    private void AddPlayerScore(int _playerID, int _num)
    {
        if (_playerID == 1)
        {
            m_player1Score += _num;
        }
        else
        {
            m_player2Score += _num;
        }

        UIManager.s_instance.SetScore(m_player1Score, m_player2Score);
    }

    private void SetCollider(int _x, int _y, int _layer)
    {
        if (!m_cellColliders[_y][_x].enabled)
        {
            m_cellColliders[_y][_x].enabled = true;
        }
        m_cellColliders[_y][_x].gameObject.layer = _layer;
    }

    private void CloseAllCollider()
    {
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                m_cellColliders[i][j].enabled = false;
            }
        }
    }

    public void GetScore(out int _player1, out int _player2)
    {
        _player1 = m_player1Score;
        _player2 = m_player2Score;
    }
}
