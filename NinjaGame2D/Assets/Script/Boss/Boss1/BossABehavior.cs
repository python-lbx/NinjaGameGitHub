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

    public enum Status {patrol,Fall};
    public Status BossA_Status;
    
    // Start is called before the first frame update
    void Start()
    {
        boxcoll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        

        for(i=0;i<5;i++)
        {
            Clones.Add(Instantiate(BossAClone,new Vector3(-10+(i*5),5,0),transform.rotation));
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if(timerstart <=0)
        {
            ChangePos();
            timerstart = timer;
        }
        else if(timerstart>0)
        {
            timerstart -= Time.deltaTime;
        }*/

        switch (BossA_Status)
        {
            case Status.patrol:
                rb.gravityScale = 0;
                        if(timerstart <=0)
                        {
                            BossA_Status = Status.Fall;
                            timerstart = timer;
                        }
                        else if(timerstart>0)
                        {
                            timerstart -= Time.deltaTime;
                        }
            break;
            case Status.Fall:
                if(time == 4)
                {                    
                    time = 0;
                    BossA_Status = Status.patrol;
                }
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
                Clones[i].transform.position = Clones[i].GetComponent<BossAClone>().startpos;
            }
            else
            {
                Clones[i].SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground" && time < 4)
        {   
            time++;
            ChangePos();
        }
    }
}
