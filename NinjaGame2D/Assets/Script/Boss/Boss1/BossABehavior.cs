using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossABehavior : MonoBehaviour
{
    BoxCollider2D boxcoll;
    public BossAClone bossAClone;
    public GameObject BossAClone;
    public List<GameObject> Clones;

    public int RangePos;
    public int i;

    public float timer;
    public float timerstart;
    
    // Start is called before the first frame update
    void Start()
    {
        boxcoll = GetComponent<BoxCollider2D>();
        bossAClone = BossAClone.GetComponent<BossAClone>();
        

        for(i=0;i<5;i++)
        {
            Clones.Add(Instantiate(BossAClone,new Vector3(-10+(i*5),5,0),transform.rotation));
            //Clones[i].SetActive(false);
            if(i == RangePos)
            {
                transform.position = Clones[i].transform.position;

                Clones[i].SetActive(false);
            }
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
    }

    void ChangePos()
    {
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

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {    
            print("A");
            bossAClone.ResetPos();        
        }
    }
}
