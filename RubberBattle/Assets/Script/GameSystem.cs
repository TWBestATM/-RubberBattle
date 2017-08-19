using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    /// <summary>
    /// 一回合時間
    /// </summary>
    [SerializeField]
    private float BattleTime =60;

    enum Satue {
        Begin,
        Battle,
        End
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

                GameSatue = Satue.Battle;
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

    private void OnDestroy()
    {
        Instance = null;
    }
}
