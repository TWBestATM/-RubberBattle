﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelect : MonoBehaviour {

    [SerializeField]
    private KeyCode UP = KeyCode.UpArrow;
    [SerializeField]
    private KeyCode Left = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode Right = KeyCode.RightArrow;
    [SerializeField]
    private KeyCode Down = KeyCode.DownArrow;
    [SerializeField]
    private KeyCode Select= KeyCode.Space;
    /// <summary>
    /// 選擇的那個框
    /// </summary>
    [SerializeField]
    private Transform SelectBoxRT;
    private int NowHeroID=0;
    private List<GameObject> HeroList;
    private int ListCount=0;
    private enum customPlayID{ Player1, Player2 }
    [SerializeField]
    private customPlayID PlayID;
    private void Start()
    {
        HeroList = new List<GameObject>();
        ListCount = transform.childCount;
        for (int i = 0; i < ListCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            HeroList.Add(go);

        
        }
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(UP))
        {

        }
        else if (Input.GetKeyDown(Right))
        {
            NowHeroID++;
        }
        else if (Input.GetKeyDown(Left))
        {
            NowHeroID--;
        }
        else if (Input.GetKey(Select))
        {
            HeroList.RemoveAt(NowHeroID);
            ListCount--;

        }
         NowHeroID = (NowHeroID + ListCount) % ListCount;
        Debug.Log(NowHeroID);
        SelectBoxRT.position = HeroList[NowHeroID].transform.position;
    }
}
