using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform leftPoint;
    public Transform rightPoint;

    public GameObject bombup;
    public GameObject bomodown;

    public bool IsOnGround;
    public bool faceright;
    public float speed;

    public float jumpForce;
    public float Stimer;
    public float timer;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        faceright = true;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
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

    void Movement()
    {
        if(faceright)
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            if(transform.position.x > rightPoint.position.x)
            {
                faceright = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            if(transform.position.x < leftPoint.position.x)
            {
                faceright = true;
            }
        }
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
        if(other.gameObject.name == "Ground")
        {
            IsOnGround = true;
            faceright = !faceright;
            print(transform.position);
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
