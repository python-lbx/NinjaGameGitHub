using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("移動範圍")]
    public Transform leftPoint;
    public Transform rightPoint;

    [Header("炸藥")]
    public GameObject bombup;
    public GameObject bomodown;

    public Transform shootpoint;
    public GameObject bullet;
    public int shoottime;

    [Header("狀態數值")]
    public GameObject player;
    public bool IsOnGround;
    public bool faceright;
    public float speed;
    public float jumpForce;
    [Header("階段")]
    //技能時間
    public float Stimer;
    public float timer;
    //技能次數
    public int skilltime;
    //階段時間
    public float phaseTime;
    public float StartphaseTime;
    public enum  Status {Patrol,Shoot,Dash,Jump}
    public Status BossStatus;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        faceright = true;

        BossStatus = Status.Patrol;
        StartphaseTime = 5;
        shoottime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        switch(BossStatus)
        {
            case Status.Patrol:
            if(StartphaseTime > 0)
            {
                StartphaseTime -= Time.deltaTime;
                Movement();
            }
            else if(StartphaseTime <= 0)
            {  
                rb.velocity = new Vector2(0,0);
                BossStatus = Status.Shoot;
            }
            break;

            case Status.Shoot:
            if(skilltime == 3)
            {
                timer = 1.4f;
                StartphaseTime = 5f;
                BossStatus = Status.Dash;
            }
            else
            {
                Shoot();
            }
            break;

            case Status.Dash:
            if(StartphaseTime > 0)
            {
                StartphaseTime -= Time.deltaTime;
                speed = 8;
                Movement();
                BombUp();
            }
            else if(StartphaseTime <= 0)
            {
                if(Vector2.Distance(transform.position,leftPoint.position)<0.1f)
                {
                    faceright = true;
                    timer = 1.4f;
                    BossStatus = Status.Jump;

                }
                else if(Vector2.Distance(transform.position,rightPoint.position)<0.1f)
                {
                    timer = 1.4f;
                    faceright = false;
                    BossStatus = Status.Jump;
                }
            }
            break;

            case Status.Jump:
            jumpForce = 11f;
            speed = 11f;
            BombDown();
            Jump();
            break;
        }
    }

    void BombUp()
    {
        if(Stimer >= 0)
        {
            Stimer -= Time.deltaTime;
        }
        else if(Stimer <=0)
        {
            Instantiate(bombup,transform.position,Quaternion.identity);
            Stimer = timer;
        }
    }
    void BombDown()
    {
        if(Stimer >= 0)
        {
            Stimer -= Time.deltaTime;
        }
        else if(Stimer <=0)
        {
            Instantiate(bomodown,transform.position,Quaternion.identity);
            Stimer = timer;
        }
    }

    void Shoot()
    {
        if(faceright)
        {
            if(player.transform.position.x < transform.position.x)
            {
                transform.Rotate(0f,180f,0);
                faceright = false;
            }
            }
            else
            {
            if(player.transform.position.x > transform.position.x)
            {
                transform.Rotate(0f,180f,0);
                faceright = true;
            }
        }

        if(shoottime == 3 && IsOnGround)
        {
            Instantiate(bullet,shootpoint.transform.position,transform.rotation);
            shoottime --;
            rb.velocity = new Vector2(0,jumpForce);
        }
        else if(shoottime == 2 && !IsOnGround && rb.velocity.y<0.1)
        {
            Instantiate(bullet,shootpoint.transform.position,transform.rotation);
            shoottime --;
        }
        else if(shoottime == 1 && IsOnGround)
        {
            Instantiate(bullet,shootpoint.transform.position,transform.rotation);
            shoottime --;
        }
        else if(shoottime == 0 && IsOnGround)
        {
            skilltime ++;
            shoottime = 3;
            BossStatus = Status.Patrol;
            StartphaseTime = 5;
        }
    }

    void Movement()
    {
        if(faceright)
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            if(transform.position.x > rightPoint.position.x)
            {
                flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            if(transform.position.x < leftPoint.position.x)
            {
                flip();
            }
        }
    }

    void flip()
    {
        faceright = !faceright;
        transform.Rotate(0f,180f,0f);
    }
    
    void Jump()
    {
        if(IsOnGround)
        {
            if(faceright)
            {
                rb.velocity = new Vector2(speed,jumpForce);
            }
            else
            {
                rb.velocity = new Vector2(-speed,jumpForce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.name == "Ground" && BossStatus == Status.Jump)
        {
            IsOnGround = true;
            faceright = !faceright;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.name == "Ground")
        {
            IsOnGround = false;
        }
    }
}
