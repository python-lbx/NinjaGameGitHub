using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Attack_Box_Controller : MonoBehaviour
{
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            FindObjectOfType<Enemy_Health_Test>().Health -= Damage;
        }
    }
}
