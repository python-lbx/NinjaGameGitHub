using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int Health;

    CapsuleCollider2D capsulecoll;
    // Start is called before the first frame update
    void Start()
    {
        capsulecoll = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D PlayerColl) 
    {
        if(PlayerColl.gameObject.tag == "Enemy")
        {
            Health -= GameObject.FindObjectOfType<Enemy_Health_Test>().Damage;
        }
    }
}
