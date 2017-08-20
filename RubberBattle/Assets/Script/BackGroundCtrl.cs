using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCtrl : MonoBehaviour {


    private Animator m_Animator;
    [SerializeField]
    private GameObject UI;
	// Use this for initialization
	void Start () {
        UI.SetActive(false);
        GameSystem.Instance.GameStart += StartGame;
        m_Animator = GetComponent<Animator>();
	}
    void opening1End()
    {
        GameSystem.Instance.OpeningEnd();

    }
    void StartGame()
    {
        m_Animator.SetTrigger("Start");
    }
    void ToSelect()
    {
        UI.SetActive(true);


    }
    private void OnDestroy()
    {
        GameSystem.Instance.GameStart -= StartGame;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
