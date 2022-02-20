using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D capsulecoll;
    Animator anim;

    [Header("移動參數")]
    public float speed;
    private float horizontalmove;

    [Header("角色狀態")]
    public bool isCrouch;
    
    Vector2 colliderStandSize; //站立碰撞框尺寸
    Vector2 colliderStandOffset; //站立碰撞框位置
    Vector2 colliderCrouchSize; //下蹲碰撞框尺寸
    Vector2 colliderCrouchOffset; //下蹲碰撞框位置

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsulecoll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();

        //獲取碰撞框參數
        colliderStandSize = capsulecoll.size; //站立
        colliderStandOffset = capsulecoll.offset;
        colliderCrouchSize = new Vector2(0.7667918f,0.7667921f); //下蹲
        colliderCrouchOffset = new Vector2(-0.07691693f,-0.5154546f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundMovement();
    }
    void Update()
    {
    }

    void GroundMovement(){
        horizontalmove = Input.GetAxisRaw("Horizontal");
        //print(horizontalmove);
        rb.velocity = new Vector2(horizontalmove * speed,rb.velocity.y);
        
        FilpDirection();

        if(Input.GetButton("Crouch"))
        {
            Crouch();
        }
        else if(!Input.GetButton("Crouch") && isCrouch)
        {
            StandUp();
        }
    }

    void FilpDirection()
    {
        if(horizontalmove <0 )
        {
            transform.localScale = new Vector2(-1,1);
        }
        else if(horizontalmove >0 )
        {
            transform.localScale = new Vector2(1,1);
        }
    }

    void Crouch()
    {
        isCrouch = true;
        capsulecoll.size = colliderCrouchSize;
        capsulecoll.offset = colliderCrouchOffset;
    }

    void StandUp()
    {
       isCrouch = false;
       capsulecoll.size = colliderStandSize;
       capsulecoll.offset = colliderStandOffset;
    }
}
