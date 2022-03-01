using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Score_Max;

    [Header("LevelOneScore")]
    public Image LV1_Score_Image;
    public Text LV1_Score_Text;
    public int LV1_Score_Current;

    // Start is called before the first frame update
    void Start()
    {
        LV1_Score_Current = PlayerPrefs.GetInt("LV1_Score");
        LV1_Score_Image.fillAmount = (float)LV1_Score_Current/(float)Score_Max;
        LV1_Score_Text.text = LV1_Score_Current.ToString()+"/"+Score_Max.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        LV1_Score_Image.fillAmount = (float)LV1_Score_Current/(float)Score_Max;
        LV1_Score_Text.text = LV1_Score_Current.ToString()+"/"+Score_Max.ToString();
    }
}
