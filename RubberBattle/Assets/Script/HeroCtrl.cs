using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCtrl : MonoBehaviour {




    [SerializeField]
    private float Speed=0;
    [SerializeField]
    private float Jump = 10;
    [SerializeField]
    private float Hp=10;
    [SerializeField]
    private KeyCode UP =KeyCode.UpArrow;
    [SerializeField]
    private KeyCode Left = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode Right = KeyCode.RightArrow;
    [SerializeField]
    private KeyCode Attack = KeyCode.Space;
    private Rigidbody2D rb;
    /// <summary>
    /// 是否站在地上
    /// </summary>
    private bool IsGround=true;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) 
             IsGround = true; 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            IsGround = false;
    }

    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(UP)&&IsGround)
        {
            rb.AddForce(Vector2 .up*Jump, ForceMode2D.Force);
        }
        if (Input.GetKey(Right))
        {

            transform.position+=new Vector3(Speed,0,0)*Time.deltaTime;
        }
        else if(Input.GetKey(Left))
        {

            transform.position -= new Vector3(Speed, 0, 0)*Time.deltaTime;
        }
        if (Input.GetKey(Attack))
        {



        }
	}
}
