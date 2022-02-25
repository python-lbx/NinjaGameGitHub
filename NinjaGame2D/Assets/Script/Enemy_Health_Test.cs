using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health_Test : MonoBehaviour
{
    public int Health;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
