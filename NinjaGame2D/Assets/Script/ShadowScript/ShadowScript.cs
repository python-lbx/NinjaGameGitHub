using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    Transform Boss; //目標對象
    SpriteRenderer thisSprite;
    SpriteRenderer BossSprite; //目標對象
    Color color;

    [Header("時間控制參數")]
    public float activeTime; //顯示時間
    public float activeStart; //開始顯示的時間點

    [Header("不透明度控制")]
    float alpha;
    public float alphaSet; //初始值
    public float alphaMultiplier;


    private void OnEnable() 
    {
        Boss = GameObject.FindGameObjectWithTag("Boss").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        BossSprite = Boss.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = BossSprite.sprite;

        transform.position = Boss.position;
        transform.localScale = Boss.localScale;
        transform.rotation = Boss.rotation;

        activeStart = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(1,0.5f,0.5f,alpha); //偏紅色

        thisSprite.color = color;

        if(Time.time >= activeStart + activeTime)
        {
            //返回對象池
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }
}
