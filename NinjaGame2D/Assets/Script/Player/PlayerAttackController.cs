using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    Animator anim;
    PlayerMovementController PlayerMovement;

    public GameObject Z_Attack_Box;

    [Header("普通攻擊")]
    public float Z_Attack_CD;
    public float Z_Attack_SCD; //Start Cool Down;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerMovement = GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && Z_Attack_SCD <=0) //地面攻擊
        {   
            Z_Attack_SCD = Z_Attack_CD;
            anim.SetTrigger("IsAttack");
        }
        if(Input.GetKeyDown(KeyCode.Z) && Z_Attack_SCD <=0 && !PlayerMovement.isOnGround) //空中攻擊
        {
            Z_Attack_SCD = Z_Attack_CD;
            anim.SetTrigger("IsAttack");
        }

        if(Z_Attack_SCD >0)
        {
            Z_Attack_SCD -= Time.deltaTime;
        }
    }

    void ZboxAttive()
    {
        Z_Attack_Box.SetActive(true);
    }

    void ZboxUnAttive()
    {
        Z_Attack_Box.SetActive(false);
    }
}
