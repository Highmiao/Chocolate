using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActSlider : MonoBehaviour {
    public Transform[] cubesTF;

	void Start () {
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(ActStart());
        }
    }


    private IEnumerator ActStart()
    {
        for (int i = 0; i < cubesTF.Length; i++)
        {
            Transform cube = cubesTF[i];
            cube.DOScaleY(5f, 0.1f).SetEase(Ease.OutQuad).OnComplete(() => {
                cube.DOScaleY(1f, 0.3f).SetEase(Ease.InCubic);
            });
            yield return new WaitForSecondsRealtime(0.03f);
        }
    }
}
