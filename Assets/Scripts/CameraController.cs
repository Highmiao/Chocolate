using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 rota1;
    public Vector3 rota2;
    public Vector3 rota3;

    private System.Action callback;

    public void ChangeView1(System.Action _callback)
    {
        callback = _callback;
        transform.DOLocalMove(pos2, 2f).SetEase(Ease.InOutQuad);
        transform.DOLocalRotate(rota2, 2f).SetEase(Ease.InSine).OnComplete(OnComplete);
    }

    public void OnComplete()
    {
        Invoke("ChangeView2", 0.5f);
    }

    public void ChangeView2()
    {
        transform.DOLocalMove(pos3, 1f).SetEase(Ease.InQuad);
        transform.DOLocalRotate(rota3, 1f).SetEase(Ease.OutQuad).OnComplete(()=> callback());
    }
}
