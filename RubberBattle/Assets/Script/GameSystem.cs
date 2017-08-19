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
    public   event SystemDelegate GameStart ;


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
            case Satue.Begin:
                if (GameStart != null)
                {
                    GameTime = BattleTime;
                    GameSatue = Satue.Idle;
                    GameStart();
                }
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


    public void StartBattle()
    {
        GameSatue = Satue.Battle;
    }
    public void GameOver()
    {
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

    private void OnDestroy()
    {
       // Instance = null;
    }
}
