using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class HeroCtrl : MonoBehaviour {


    [SerializeField]
    private int id;
    [SerializeField]
    private float Speed=0;
    [SerializeField]
    private float Jump = 10;
    private float Hp=10;
    [SerializeField]
    private float MaxHp = 10;
    [SerializeField]
    private float AttackTime = 1.0f;
    [SerializeField]
    private KeyCode UP =KeyCode.UpArrow;
    [SerializeField]
    private KeyCode Left = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode Right = KeyCode.RightArrow;
    [SerializeField]
    private KeyCode Attack = KeyCode.Space;
    [SerializeField]
    private KeyCode Down = KeyCode.DownArrow;
    /// <summary>
    /// 要改動態
    /// </summary>
    [SerializeField]
    private HPUI hpUI;
    private Rigidbody2D rb;
    /// <summary>
    /// 是否站在地上
    /// </summary>
    private bool IsGround=false;

    SkeletonAnimation spineState;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        spineState = GetComponent<SkeletonAnimation>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) 
             IsGround = true;
        spineState.AnimationName = "idle";
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            IsGround = false;
    }
    public void Init(int PlayID) 
    {
        id = PlayID;
        Hp = MaxHp;
        if (PlayID == 0) {
            UP = KeyCode.W;
            Left = KeyCode.A;
            Right = KeyCode.D;
            Attack = KeyCode.G;
            Down = KeyCode.S;
        }
        else {
            UP = KeyCode.UpArrow;
            Left = KeyCode.LeftArrow;
            Right = KeyCode.RightArrow;
            Attack = KeyCode.Alpha0;
            Down = KeyCode.DownArrow;
        }
        
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(UP)&&IsGround)
        {
            rb.AddForce(Vector2 .up*Jump, ForceMode2D.Force);
            spineState.AnimationName = "jump";
        }
        if (Input.GetKey(Right))
        {
            transform.localScale = new Vector3(-0.15f, 0.15f, 1);
            transform.position+=new Vector3(Speed,0,0)*Time.deltaTime;
        }
        else if(Input.GetKey(Left))
        {
            transform.localScale = new Vector3(0.15f, 0.15f, 1);
            transform.position -= new Vector3(Speed, 0, 0)*Time.deltaTime;
        }
        if (Input.GetKeyDown(Attack))
        {

            spineState.AnimationName = "attack";
            Invoke("RecoverIdle", AttackTime);

        }

        if (Input.GetKey(Down) && IsGround) {
            spineState.AnimationName = "idle down";
        }
        else if (Input.GetKeyUp(Down)) {
            spineState.AnimationName = "idle";
        }
    }

    private void RecoverIdle() {
        spineState.AnimationName = "idle";
    }

    public void Hurt() {

        Hp--;
        UIManager.instance.Hurt(id, Hp/MaxHp);
      

        if (Hp <= 0) {
            Debug.Log(id + "Dead");
            GameSystem.Instance.GameOver(id);

        }
    }
}
