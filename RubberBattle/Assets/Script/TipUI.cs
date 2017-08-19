using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TipUI : MonoBehaviour {
    Text TipText;
	// Use this for initialization
	void Start () {
        TipText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {

        TipText.text = "";
        StartCoroutine(Startamin());
    }

    /// <summary>
    /// 作技能倒數
    /// </summary>
    /// <returns></returns>
    IEnumerator Startamin()
    {

        TipText.text ="3";
        yield return new WaitForSeconds(1);
        TipText.text = "2";
        yield return new WaitForSeconds(1);
        TipText.text = "1";
        yield return new WaitForSeconds(1);
        TipText.text = "Finght!";
        yield return new WaitForSeconds(1);
        TipText.text = "";
        GameSystem.Instance.StartBattle();

    }
}
