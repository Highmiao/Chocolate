using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public Text timerText;

    public void SetTime(float _time)
    {
        timerText.text = Mathf.CeilToInt(_time).ToString();
    }
}
