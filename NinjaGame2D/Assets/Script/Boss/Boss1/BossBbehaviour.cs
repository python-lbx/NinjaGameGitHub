using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBbehaviour : MonoBehaviour
{
    [Header("巡邏")]
    public float Patrolspeed;
    public float startWaitTime;
    public float WaitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    [Header("橫衝")]
    public Transform[] point;
    public int BossBRndPos;
    public Transform MovePos;
    public int Rushspeed;
    public int time;

    [Header("階段")]
    public bool phase;
    public float phaseTime;
    public float StartphaseTime;
    public enum Status {patrol,HRush};
    public Status BossB_Status;

    // Start is called before the first frame update
    void Start()
    {
        BossBRndPos = Random.Range(0,4);
        phaseTime = 5;
        BossB_Status = Status.patrol;

    }

    // Update is called once per frame
    void Update()
    {
        switch(BossB_Status)
        {
            case Status.patrol:
            if(phaseTime>0)
            {
                RndPatrol();
                phaseTime -= Time.deltaTime;
            }
            else if(phaseTime<=0)
            {
                transform.position = point[BossBRndPos].transform.position;
                BossB_Status = Status.HRush;
            }
            break;
            case Status.HRush:
            if(time == 4)
            {
                time = 0;
                phaseTime =5;
                BossB_Status = Status.patrol;
            }
            else
            {
                HorizontalRush();
            }
            break;
            
        }
 
    }

    void RndPatrol()
    {
        transform.position = Vector2.MoveTowards(transform.position,movePos.position,Patrolspeed * Time.deltaTime);

        if(Vector2.Distance(transform.position,movePos.position) < 0.1f)
        {
            if(WaitTime <= 0)
            {
                movePos.position =  GetRandomPos();
                WaitTime = startWaitTime;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x),Random.Range(leftDownPos.position.y,rightUpPos.position.y));
        return rndPos;
    }

    void HorizontalRush()
    {
        transform.position = Vector2.MoveTowards(transform.position,MovePos.position,Rushspeed * Time.deltaTime);

        if(BossBRndPos == 0)
        {
            MovePos.position = point[1].position;
        }
        else if(BossBRndPos == 1)
        {
            MovePos.position = point[0].position;
        }
        else if(BossBRndPos == 2)
        {
            MovePos.position = point[3].position;
        }
        else if(BossBRndPos == 3)
        {
            MovePos.position = point[2].position;
        }


        if(Vector2.Distance(this.transform.position,MovePos.position)<0.1f)
        {
            time++;
            BossBRndPos = Random.Range(0,4);
            transform.position = point[BossBRndPos].transform.position;
        }
    }
}
