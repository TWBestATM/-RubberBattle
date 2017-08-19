using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private HPUI Player1HP;
    [SerializeField]
    private HPUI Player2HP;
    [SerializeField]
    private TipUI m_TipUI;
    public static UIManager instance;
	// Use this for initialization
    private void Awake()
    {
        instance = this;
        GameSystem.Instance.GameStart += BattleStart;

    }

    // Update is called once per frame
    void Update () {

	}

    public void Hurt(int PlayerID,float nowHP)
    {
        if(PlayerID==0)
            Player1HP.UpdateHPUI(nowHP);
        else
            Player2HP.UpdateHPUI(nowHP);
    }

    public void BattleStart()
    {
        m_TipUI.StartGame();
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
