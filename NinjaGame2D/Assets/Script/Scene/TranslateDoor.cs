using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TranslateDoor : MonoBehaviour
{
    Collider2D coll;
    public bool NextLevelIsBoss;
    public bool NextLevelIsEnemy;
    public string BossName;
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D Door) 
    {
        if(Door.gameObject.tag == "Player")
        {
            if(NextLevelIsBoss)
            {
                SceneManager.LoadScene(BossName);
            }
            
            if(NextLevelIsEnemy)
            {
                SceneManager.LoadScene(LevelName);
            }
        }
    }
}
