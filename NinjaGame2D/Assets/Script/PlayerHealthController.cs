using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int Health;
    public bool isHurt;

    CapsuleCollider2D capsulecoll;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        capsulecoll = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHurt && Mathf.Abs(rb.velocity.x)<0.1f)
        {
            isHurt = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D PlayerColl) 
    {
        if(PlayerColl.gameObject.tag == "Enemy")
        {
            Health -= GameObject.FindObjectOfType<Enemy_Health_Test>().Damage;
            if(transform.position.x < PlayerColl.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-5f,rb.velocity.y);
                isHurt = true;
            }
            else if(transform.position.x > PlayerColl.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(5f,rb.velocity.y);
                isHurt = true;
            }
        }
    }
}
