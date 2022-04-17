using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    Animator anim;
    PlayerMovementController PlayerMovement;
    public ButtonCheck2 buttonCheck;

    public GameObject Z_Attack_Box;

    public GameObject FireBall;
    public Transform ShootPoint;

    [Header("普通攻擊")]
    public float Z_Attack_CD;
    public float Z_Attack_SCD; //Start Cool Down;

    public float Fire_CD;
    public float Fire_SCD;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerMovement = GetComponent<PlayerMovementController>();
        buttonCheck = GameObject.FindObjectOfType<ButtonCheck2>();

    }

    // Update is called once per frame
    void Update()
    {
        if(buttonCheck.Z_AttackPressed && Z_Attack_SCD <=0) //地面攻擊
        {   
            Z_Attack_SCD = Z_Attack_CD;
            anim.SetTrigger("IsAttack");
            buttonCheck.Z_AttackPressed = false;
        }
        else if(buttonCheck.Z_AttackPressed && Z_Attack_SCD <=0 && !PlayerMovement.isOnGround) //空中攻擊
        {
            Z_Attack_SCD = Z_Attack_CD;
            anim.SetTrigger("IsAttack");
            buttonCheck.Z_AttackPressed = false;
        }
        else
        {
            buttonCheck.Z_AttackPressed = false;
        }

        if(buttonCheck.firePressed && Fire_SCD <=0 && !PlayerMovement.isOnGround) //空中噴火
        {
            Fire_SCD = Fire_CD;
            anim.SetTrigger("JumpFire");
            buttonCheck.firePressed = false;
            Instantiate(FireBall,ShootPoint.position,transform.rotation);
        }
        else if(buttonCheck.firePressed && Fire_SCD <= 0) //地面噴火
        {
            Fire_SCD = Fire_CD;
            anim.SetTrigger("GroundFire");
            buttonCheck.firePressed = false;
            Instantiate(FireBall,ShootPoint.position,transform.rotation);
        }
        else
        {
            buttonCheck.firePressed = false;
        }

        if(Z_Attack_SCD >0)
        {
            Z_Attack_SCD -= Time.deltaTime;
        }

        if(Fire_SCD >0)
        {
            Fire_SCD -= Time.deltaTime;
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
