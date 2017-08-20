using System;
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
    enum Satue {
        Opening,
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
    public delegate void SystemDelegate();
    public delegate void SystemDelegateInt(int PlayID);
    public   event SystemDelegate BattleStart ;
    public event SystemDelegate GameStart;
    public event SystemDelegateInt GameEnd;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
 
        }

    }
    void Start () {
        Init();
	}
    private void Init()
    {
        m_PlayerData[0] = new PlayerData();
        m_PlayerData[0].Ready = false;
        m_PlayerData[1] = new PlayerData();
        m_PlayerData[1].Ready = false;
        GameSatue = Satue.Idle;


    }
	// Update is called once per frame
	void Update () {
        switch (GameSatue)
        {
            case Satue.Opening:
                if (Input.anyKeyDown)
                {
                    GameSatue = Satue.Select;
                    GameStart();
                }
                break;
            case Satue.Begin:
                if (BattleStart != null)
                {
                    GameTime = BattleTime;
                    GameSatue = Satue.Idle;
                    BattleStart();
                }
                break;
            case Satue.Battle:
                //數字倒數
                GameTime -= Time.deltaTime;
                if (GameTime <= 0)
                {
                    GameOver(0);
                }
                break;
        }	
	}

    public void OpeningEnd()
    {
        GameSatue = Satue.Opening;
    }
    public void StartBattle()
    {
        GameSatue = Satue.Battle;
    }

    public void GameOver(int PlayerID)
    {
        GameEnd(PlayerID==0?1:0);
        GameSatue = Satue.End;

    }
    public int GetHeroID(int PlayerID)
    {
        return m_PlayerData[PlayerID].HeroID;
    }
/// <summary>
/// 選角
/// </summary>
/// <param name="playerID"></param>
/// <param name="HeroID"></param>
    public void PlayerSelect(int playerID,int HeroID)
    {
        m_PlayerData[playerID].HeroID = HeroID;
        m_PlayerData[playerID].Ready = true;
        if (m_PlayerData[0].Ready && m_PlayerData[1].Ready)
        {
            SceneManager.LoadScene("Game");
            GameSatue = Satue.Begin;
        }
    }
    public void ReStart()
    {
        GameSatue = Satue.Idle;
        Init();
        SceneManager.LoadScene("HeroSelect");

    }
    private void OnDestroy()
    {
       // Instance = null;
    }
}
