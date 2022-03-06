using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossABehavior : MonoBehaviour
{
    BoxCollider2D boxcoll;
    Rigidbody2D rb;

    [Header("克隆體")]
    public GameObject BossAClone;
    public List<GameObject> Clones;
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

    [Header("階段")]
    public bool phase;
    public float phaseTime;
    public float StartphaseTime;
    public enum Status {patrol,Fall};
    public Status BossA_Status;
    
    private void Awake() 
    {
        //製作分身後隱藏
        for(i=0;i<5;i++)
        {
            Clones.Add(Instantiate(BossAClone,new Vector3(-10+(i*5),5,0),transform.rotation));
            //Clones[i].SetActive(false);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        boxcoll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        

        ChangePos();

        WaitTime = startWaitTime;
        movePos.position =  GetRandomPos();

    }

    // Update is called once per frame
    void Update()
    {

        switch (BossA_Status)
        {
            case Status.patrol:
            break;
            case Status.Fall:
            break;
        }
    }

    void ChangePos()
    {
        RangePos = Random.Range(0,5);

        for(i=0;i<5;i++)
        {
            if(i == RangePos)
            {
                transform.position = Clones[i].GetComponent<BossAClone>().startpos;

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

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x),Random.Range(leftDownPos.position.y,rightUpPos.position.y));
        return rndPos;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {   
            ChangePos();
        }
    }
}
