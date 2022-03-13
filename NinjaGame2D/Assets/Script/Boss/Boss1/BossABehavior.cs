using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossABehavior : MonoBehaviour
{
    BoxCollider2D boxcoll;
    Rigidbody2D rb;

    public BossBbehaviour BossB;

    public Transform transformPoint;

    [Header("克隆體")]
    //public GameObject BossAClone;
    public GameObject[] Clones;
    public int RangePos;
    public int i;

    public float timer;
    public float timerstart;
    public int time;

    [Header("巡邏")]
    public float speed;
    public float startWaitTime;
    public float WaitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    
    [Header("圓運動")]
    public Transform Center;


    [Header("階段")]
    public bool phase;
    public float phaseTime;
    public float StartphaseTime;
    public enum Status {Idle,patrol,Fall,CircleMove,Transform,Transform_I,Transform_II};
    public Status BossA_Status;
    
    // Start is called before the first frame update
    void Start()
    {
        boxcoll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        BossB = GameObject.Find("BossB").GetComponent<BossBbehaviour>();
        
        WaitTime = startWaitTime;
        //巡邏
        phaseTime = 5; //巡邏階段時間
        //BossA_Status = Status.patrol; //巡邏階段

        BossA_Status = Status.Idle;
        //BossA_Status = Status.CircleMove;


    }

    // Update is called once per frame
    void Update()
    {

        switch (BossA_Status)
        {
            case Status.Idle:
            if(phaseTime > 0)
            {
                phaseTime -= Time.deltaTime;
            }
            else if(phaseTime <= 0)
            {        
                phaseTime = 5; //巡邏階段時間
                BossA_Status = Status.patrol;
                BossB.BossB_Status = BossBbehaviour.Status.patrol;
            }
            break;

            case Status.Transform: //什麼也不做
                transform.position = transformPoint.position; //時間內固定在傳送點
            break;

            case Status.Transform_I:
                if(phaseTime > 0)
                {
                    transform.position = transformPoint.position; //時間內固定在傳送點
                    phaseTime -= Time.deltaTime;
                }
                else if(phaseTime <= 0)
                {
                    ChangePos();
                    BossA_Status = Status.Fall;
                }
            break;

            case Status.patrol:
            if(phaseTime>0)
            {
                
                RndPatrol();
                phaseTime -= Time.deltaTime;
            }
            else if(phaseTime<=0)
            {
                WaitTime = startWaitTime;
                phaseTime = 2;
                BossA_Status = Status.Transform_I;
                BossB.BossB_Status = BossBbehaviour.Status.Transform;
            }
            break;

            case Status.Fall:
            if(time == 4)
            {
                time = 0;
                phaseTime = 5;
                CancelInvoke("ChangePos");
                Invoke("trans",2f);
            }
            break;

            case Status.CircleMove:
            transform.position = Center.position;
            rb.gravityScale = 0;
            break;
        }
    }

    void ChangePos()
    {
        rb.gravityScale = 1;
        RangePos = Random.Range(0,5);

        for(i=0;i<5;i++)
        {
            if(i == RangePos)
            {
                transform.position = Clones[i].transform.position;
                Clones[i].SetActive(false);
            }
            else
            {
                Clones[i].SetActive(true);
            }
        }
    }

    void RndPatrol()
    {
        rb.gravityScale = 0;
        transform.position = Vector2.MoveTowards(transform.position,movePos.position,speed * Time.deltaTime);

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

    void trans()
    {
        BossA_Status = Status.Transform;
        BossB.phaseTime = 2f;
        BossB.BossB_Status = BossBbehaviour.Status.HRush;
        BossB.transform.position = BossB.point[BossB.BossBRndPos].transform.position;
        CancelInvoke("trans");
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x),Random.Range(leftDownPos.position.y,rightUpPos.position.y));
        return rndPos;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(BossA_Status == Status.Fall && time < 4)
        {
            Invoke("ChangePos",2f);
            time++;
        }
    }
}
