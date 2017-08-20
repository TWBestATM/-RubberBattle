using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private HPUI Player1HP;
    [SerializeField]
    private Image Player1Head;
    [SerializeField]
    private HPUI Player2HP;
    [SerializeField]
    private Image Player2Head;
    [SerializeField]
    private TipUI m_TipUI;
    [SerializeField]
    private List<HeroData> HeroDataList;
    public static UIManager instance;
    private GameSystem m_GameSystem;
	// Use this for initialization
    private void Awake()
    {
        instance = this;
        m_GameSystem = GameSystem.Instance;
        Init();
        m_GameSystem.GameStart += BattleStart;

    }
    public void Init()
    {
        Debug.Log(m_GameSystem.GetHeroID(0));
        Player1Head.sprite = HeroDataList[m_GameSystem.GetHeroID(0)].Head;
        Debug.Log(m_GameSystem.GetHeroID(1));
        Player2Head.sprite = HeroDataList[m_GameSystem.GetHeroID(1)].Head;
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
