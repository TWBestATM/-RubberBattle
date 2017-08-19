using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour {
    /// <summary>
    /// 一回合時間
    /// </summary>
    [SerializeField]
    private float BattleTime =60;
    [SerializeField]
    TipUI m_TipUI;
    enum Satue {
        Select,
        Begin,
        Battle,
        End,
        Idle
    }
    public  static GameSystem Instance;
    public float GameTime = 60;
    private  PlayerData[] m_PlayerData=new PlayerData[2];
    private Satue GameSatue;
    // Use this for initialization
    private void Awake()
    {
         Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
 
        GameSatue = Satue.Begin;
	}
	
	// Update is called once per frame
	void Update () {
        switch (GameSatue)
        {
            case Satue.Begin:
                GameTime = BattleTime;
                m_TipUI.StartGame();
                GameSatue = Satue.Idle;
                break;
            case Satue.Battle:
                //數字倒數
                GameTime -= Time.deltaTime;
                if (GameTime <= 0)
                {
                    GameSatue =Satue.End;
                }
                break;
            case Satue.End:
                break;
        }	
	}

    public void StartBattle( )
    {
        GameSatue = Satue.Battle;
    }

/// <summary>
/// 選角
/// </summary>
/// <param name="playerID"></param>
/// <param name="HeroID"></param>
    public void PlayerSelect(int playerID,int HeroID)
    {
        m_PlayerData[playerID].HeroID = HeroID;
        if (m_PlayerData[playerID].Ready && m_PlayerData[playerID].Ready)
        {
            SceneManager.LoadScene("Game");
            GameSatue = Satue.Begin;


        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
