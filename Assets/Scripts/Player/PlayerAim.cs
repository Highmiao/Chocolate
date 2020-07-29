using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public int fireDistance;
    public Transform aimTF;
    public Color aimColor;
    public float pixelSize = 0.2f;

    private void Start()
    {
        aimTF.GetComponentInChildren<MeshRenderer>().material.color = aimColor;
    }

    public Vector3 SetAimPos(FaceDirType _dir, int _x, int _y)
    {
        switch (_dir)
        {
            case FaceDirType.mdtNone:
                break;
            case FaceDirType.mdtUp:
                aimTF.position = new Vector3(_x * 0.2f, 0.01f, _y * 0.2f + (fireDistance + 1) * pixelSize);
                break;
            case FaceDirType.mdtDown:
                aimTF.position = new Vector3(_x * 0.2f, 0.01f, _y * 0.2f - (fireDistance + 1) * pixelSize);
                break;
            case FaceDirType.mdtLeft:
                aimTF.position = new Vector3(_x * 0.2f - (fireDistance + 1) * pixelSize, 0.01f, _y * 0.2f);
                break;
            case FaceDirType.mdtRight:
                aimTF.position = new Vector3(_x * 0.2f + (fireDistance + 1) * pixelSize, 0.01f, _y * 0.2f);
                break;
            case FaceDirType.mdtUpLeft:
                aimTF.position = new Vector3(_x * 0.2f - fireDistance * pixelSize, 0.01f, _y * 0.2f + fireDistance * pixelSize);
                break;
            case FaceDirType.mdtUpRight:
                aimTF.position = new Vector3(_x * 0.2f + fireDistance * pixelSize, 0.01f, _y * 0.2f + fireDistance * pixelSize);
                break;
            case FaceDirType.mdtDownLeft:
                aimTF.position = new Vector3(_x * 0.2f - fireDistance * pixelSize, 0.01f, _y * 0.2f - fireDistance * pixelSize);
                break;
            case FaceDirType.mdtDownRight:
                aimTF.position = new Vector3(_x * 0.2f + fireDistance * pixelSize, 0.01f, _y * 0.2f - fireDistance * pixelSize);
                break;
            default:
                break;
        }

        return aimTF.position;
    }
}
