using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelect : MonoBehaviour
{

    [SerializeField]
    private KeyCode UP = KeyCode.UpArrow;
    [SerializeField]
    private KeyCode Left = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode Right = KeyCode.RightArrow;
    [SerializeField]
    private KeyCode Down = KeyCode.DownArrow;
    [SerializeField]
    private KeyCode Select = KeyCode.Space;
    /// <summary>
    /// 選擇的那個框
    /// </summary>
    [SerializeField]
    private Transform SelectBoxRT;
    [SerializeField]
    private Text HeroName;
    private int NowHeroID = 0;
    private List<GameObject> HeroList;
    private int ListCount = 0;
    private bool IsReady = false;
    [SerializeField]
    private int PlayID;
    [SerializeField]
    private List<HeroData> HeroDataList;
    private void Start()
    {
        HeroList = new List<GameObject>();
        ListCount = transform.childCount;
        for (int i = 0; i < ListCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            go.GetComponent<Image>().sprite = HeroDataList[i].Head;
            HeroList.Add(go);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsReady)
        {
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
                //HeroList.RemoveAt(NowHeroID);
                //ListCount--;
                GameSystem.Instance.PlayerSelect(PlayID, NowHeroID);
                IsReady = true;


            }
            NowHeroID = (NowHeroID + ListCount) % ListCount;
            SelectBoxRT.position = HeroList[NowHeroID].transform.position;
            HeroName.text = HeroDataList[NowHeroID].HeroName;
        }

    }
}
