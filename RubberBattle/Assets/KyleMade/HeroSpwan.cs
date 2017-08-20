using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpwan : MonoBehaviour {
    [SerializeField]
    private GameObject[] heroSpecies;
	// Use this for initialization
	void Start () {
        SpwanPlayer1();
        SpwanPlayer2();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpwanPlayer1() {
        GameObject P1 = Instantiate(heroSpecies[GameSystem.Instance.GetHeroID(0)], new Vector3(-5, -2,0), Quaternion.identity);
        P1.GetComponent<HeroCtrl>().Init(0);
    }

    public void SpwanPlayer2() {
        GameObject P2 = Instantiate(heroSpecies[GameSystem.Instance.GetHeroID(1)], new Vector3(5, -2, 0), Quaternion.identity);
        P2.GetComponent<HeroCtrl>().Init(1);
    }
    //GameSystem.Instance.GetHeroID(0)
}
