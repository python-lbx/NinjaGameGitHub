using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAClone : MonoBehaviour
{
    BoxCollider2D boxcoll;
    public Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        boxcoll = GetComponent<BoxCollider2D>();
        startpos = new Vector3(transform.position.x,5,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPos()
    {
        transform.position = startpos;
    }
}
