using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    ptNone = 0,
    ptLocal = 1,
    ptNet = 2
}


public class PlayerMovementNet : MonoBehaviour {

    public Rigidbody playerRig;
    public Transform playerTF;
    public float moveSpeed;
    public string horizontalMove;
    public string verticalMove;

    public PlayerType playerType;

    public void SetPlayerType(PlayerType playerType)
    {
        this.playerType = playerType;
    }

    public void SetPlayerTransform()
    {

    }
}
