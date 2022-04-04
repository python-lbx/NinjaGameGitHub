using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    SpriteRenderer SR;
    Animator anim;

    public float force;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        rb.AddForce(transform.up*force , ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.name == "Ground")
        {
            anim.SetTrigger("Start");
        }
    }

    void ChangeRed()
    {
        Destroy(this.gameObject);
    }
}
