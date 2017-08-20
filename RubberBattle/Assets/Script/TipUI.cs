using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TipUI : MonoBehaviour {
    Text TipText;
    // Use this for initialization
    void Start() {
        TipText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void StartGame()
    {

        TipText.text = "";
        StartCoroutine(StartAmin());
    }
    public void EndGame(int WinID)
    {

        TipText.text = "";
        StartCoroutine(EndAmin(WinID));
    }


    /// <summary>
    /// 作技能倒數
    /// </summary>
    /// <returns></returns>
    IEnumerator StartAmin()
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

/// <summary>
/// 秀勝利畫面
/// </summary>
/// <returns></returns>
IEnumerator EndAmin(int ID)
{
        if (ID == 0)
        {
            TipText.text = "Player1\nWin !";
        }
        else
        {
            TipText.text = "Player2\nWin !";
        }

    yield return new WaitForSeconds(3);
        GameSystem.Instance.ReStart();
   

}
}
