using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    [SerializeField]
    GameObject parent;
    [SerializeField]
    ObjectPool m_ObjectPool;

	// Use this for initialization
	void Start () {
        m_ObjectPool = GameObject.FindGameObjectWithTag("Pool").GetComponent<ObjectPool>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.tag == "body" && collision.gameObject != parent) {
            print("hit");
            collision.gameObject.GetComponent<HeroCtrl>().Hurt();
            m_ObjectPool.ReUse(this.transform.position);
        }
    }
}
