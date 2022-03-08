using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBbehaviour : MonoBehaviour
{
    public Transform[] point;
    public int BossBRndPos;
    public Transform MovePos;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        BossBRndPos = Random.Range(0,4);
        transform.position = point[BossBRndPos].transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position,MovePos.position,speed * Time.deltaTime);

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
            BossBRndPos = Random.Range(0,4);
            transform.position = point[BossBRndPos].transform.position;
        }
    }
}
