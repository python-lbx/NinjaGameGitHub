using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck2 : MonoBehaviour
{
    public bool jumpPressed;
    public bool Z_AttackPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpPressed()
    {
        jumpPressed = true;
    }

    public void Z_Attack()
    {
        Z_AttackPressed = true;
    }
}
