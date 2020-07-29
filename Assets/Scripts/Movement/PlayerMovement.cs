using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FaceDirType
{
    mdtNone = 0,
    mdtUp = 1,
    mdtDown = 2,
    mdtLeft = 4,
    mdtRight = 8,
    mdtUpLeft = 5,
    mdtUpRight = 9,
    mdtDownLeft = 6,
    mdtDownRight = 10
}

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRig;
    public Transform playerTF;
    public float moveSpeed;
    public string horizontalMove;
    public string verticalMove;
    public FaceDirType dir;

    private float m_pixelSize = 0.2f;

    private float m_h;
    private float m_v;

    public void CheckMove()
    {
        m_h = Input.GetAxis(horizontalMove);
        m_v = Input.GetAxis(verticalMove);

        playerRig.MovePosition(playerTF.position + (new Vector3(m_h, 0, m_v) * moveSpeed * Time.deltaTime));
        //playerTF.Translate(new Vector3(m_h, 0, m_v) * moveSpeed * Time.deltaTime);
    }

    public FaceDirType CheckFaceDir()
    {
        FaceDirType tmpDir = FaceDirType.mdtNone;

        if (m_h > 0)
        {
            tmpDir |= FaceDirType.mdtRight;
        }
        else if (m_h < 0)
        {
            tmpDir |= FaceDirType.mdtLeft;
        }

        if (m_v > 0)
        {
            tmpDir |= FaceDirType.mdtUp;
        }
        else if (m_v < 0)
        {
            tmpDir |= FaceDirType.mdtDown;
        }

        if (tmpDir != FaceDirType.mdtNone)
        {
            dir = tmpDir;
        }
        return dir;
    }

    public void GetArrayPos(out int _x, out int _y)
    {
        _x = Mathf.RoundToInt(playerTF.position.x / m_pixelSize);
        _y = Mathf.RoundToInt(playerTF.position.z / m_pixelSize);
    }
}
