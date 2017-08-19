using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    /// <summary>
    /// 一回合時間
    /// </summary>
    [SerializeField]
    private float BattleTime =60;
    [SerializeField]
    TipUI m_TipUI;
    enum Satue {
        Begin,
        Battle,
        End,
        Idle
    }
    public  static GameSystem Instance;
    public float GameTime = 60;
    private Satue GameSatue;

    // Use this for initialization
    private void Awake()
    {
         Instance = this;      
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

    private void OnDestroy()
    {
        Instance = null;
    }
}
