using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TranslateDoor : MonoBehaviour
{
    Collider2D coll;
    public bool NextLevelIsBoss;
    public bool NextLevelIsEnemy;
    public int currentLevel;
    public int nextLevel;
    public int currentBossLevel;
    public int nextBossLevel;
    public string BossName;
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        currentLevel = PlayerPrefs.GetInt("levelsUnlocked");
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
                if(nextBossLevel > currentBossLevel)
                {
                    PlayerPrefs.SetInt("boss_levelsUnlocked",nextBossLevel);
                }
                Debug.Log("BossLevel"+PlayerPrefs.GetInt("boss_levelsUnlocked")+"Unlocked");
                SceneManager.LoadScene(BossName);
            }
            
            if(NextLevelIsEnemy)
            {

                if(nextLevel > currentLevel )
                {
                    PlayerPrefs.SetInt("levelsUnlocked",nextLevel);
                }
            
                Debug.Log("Level"+PlayerPrefs.GetInt("levelsUnlocked")+"Unlocked");
                SceneManager.LoadScene(LevelName);
            }
        }
    }
}
