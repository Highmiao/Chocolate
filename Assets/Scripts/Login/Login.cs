using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public InputField playerName;
    public Button joinBtn;

	// Use this for initialization
	void Start () {
        joinBtn.onClick.AddListener(onJoinBtnClicked);
	}
	
	public void onJoinBtnClicked()
    {
        string pn = playerName.text;
        if (!string.IsNullOrEmpty(pn))
        {
            Debug.Log("join game");
        }
    }
}
