using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 2f;
    Vector2 move; 
    public Vector2 lastMove;
    Animator anim;
    public bool isMoving;
    public int money = 1000;
    [SerializeField] Text moneyText; 


    public float Speed { get => speed; set => speed = value; }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        move = new Vector2(horizontal , vertical);
        anim.SetFloat("horizontal", horizontal);
        anim.SetFloat("vertical", vertical);

        isMoving = horizontal != 0 || vertical != 0;
        anim.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            anim.speed = 1;
            lastMove = new Vector2(horizontal, vertical).normalized;
            anim.SetFloat("lastHorizontal", horizontal);
            anim.SetFloat("lastVertical", vertical);
        }
        else
            anim.speed = 0;

        moneyText.text = "$ " + money.ToString();
    }

    void FixedUpdate() => Move();

    public void Move() => rigidbody2D.velocity = move * Speed;
}
