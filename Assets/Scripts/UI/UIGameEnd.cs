using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameEnd : MonoBehaviour
{
    public Text gameEndText;
	
    public void ShowText(string _content)
    {
        gameEndText.gameObject.SetActive(true);
        gameEndText.text = _content;
    }

    public void HideText(string _content)
    {
        gameEndText.gameObject.SetActive(false);
    }
}
