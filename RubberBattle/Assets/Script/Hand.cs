﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    [SerializeField]
    GameObject parent;
    [SerializeField]
    GameObject hurtEffect;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "body" && collision.gameObject != parent) {
            collision.gameObject.GetComponent<HeroCtrl>().Hurt();
            GameObject effect = Instantiate(hurtEffect, collision.transform);

        }
    }
}
