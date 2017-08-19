using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeUI : MonoBehaviour {



    private Text ShowText;
    private GameSystem m_GameSystem;
	// Use this for initialization
	void Start () {
        ShowText = GetComponent<Text>();
        m_GameSystem = GameSystem.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        //數字Floor
        ShowText.text = (Mathf.FloorToInt(m_GameSystem.GameTime)).ToString();
	}
}
