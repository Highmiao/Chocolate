using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerBillBoard : MonoBehaviour
{
    //public RectTransform rectTransform;
    //public Transform playerTF;
    //public float xOffset;
    //public float yOffset;

    public Camera Camera;  
    public Vector3 Normal;//面法线  
    Quaternion direction;

    private void Start()
    {
        Camera = Camera.main;
        direction = Quaternion.FromToRotation(new Vector3(0, 0, 1), Normal);
        Debug.Log(direction);
        //transform.rotation = Camera.transform.rotation * direction;

    }

    private void Update()
    {
        //Vector2 player2DPosition = Camera.main.WorldToScreenPoint(playerTF.position);
        //rectTransform.position = player2DPosition + new Vector2(xOffset, yOffset);

        transform.rotation = Camera.transform.rotation * direction;
    }
}
