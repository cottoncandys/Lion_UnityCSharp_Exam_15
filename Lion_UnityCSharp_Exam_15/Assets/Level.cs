using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [Header("下一個關卡的名稱")]
    public string NextSceneName;
    public int LevelID;
    public Text Leveltext;

    [Header("設定每個關卡最高得分數")]
    public float SetHeightScore;
    //儲存每個關卡最高得分數
    string SaveHeightScore = "SaveHeightScore";
    string SaveLevelID = "SaveLevelID";
    //int memeValue;

    //記錄要開啟的關卡數量
    static public int OpenLevelID = 1;
    //抓取所有Level頁面所有關卡按鈕
    public GameObject[] LevelButton;


    private void Start()
    {
       if(Application.loadedLevelName == "Level" && GetComponentInChildren<Text>()!=null)
        {
            //抓去子物件
            Leveltext = GetComponentInChildren<Text>();
            //字串轉成整數值
            LevelID = int.Parse(Leveltext.text);

        }
        //自動抓取tag為LevelButton的按鈕放入陣列中
        LevelButton = GameObject.FindGameObjectsWithTag("LevelButton");
       //用for迴圈開啟按鈕
       for(int i=0; i<= OpenLevelID-1; i++)
        {
            LevelButton[i].GetComponent<Button>().interactable = true;
        }
    }

    public void NextScene()
    {
        //因為按到level頁面再次返回首頁時，會出現重複背景音樂，所以要做刪除動作

        //如果場景名稱為Menu 因為把menu場景的音樂移除，移到logo場景，所以已經不需要刪除的動作
        /*
        if (NextSceneName == "Menu")
        {
            //Destroy刪除物件
            Destroy(GameObject.Find("gamemusic").gameObject);
        }
        */

        //從首頁連進level頁再到movie頁時，背景音樂和movie的音樂會重複到。要在movie頁時移除背景音樂:

        //如果場景名稱為Movie
        if(NextSceneName == "Movie")
        {

            PlayerPrefs.SetFloat(SaveLevelID, LevelID);
            //跳關卡到game畫面前，先將每關最高得分儲存
            PlayerPrefs.SetFloat(SaveHeightScore + LevelID, SetHeightScore);

            //物件在unity關閉時，find是找不到的。 
            //GameObject.Find("物件名稱").SetActive(判斷物件是否要開啟);[[找物件開關]]
            //GameObject.Find("gamemusic").SetActive(false);
            //GameObject.Find("物件名稱").GetComponent(判斷物件是否要開啟);[[控制物件裡面的是否要打開]]
            GameObject.Find("gamemusic").GetComponent<AudioSource>().enabled = false;
        }
        if (NextSceneName == "Game")
        {
            //GameObject.Find("gamemusic").SetActive(true);
            //但是因為在Movie時，物件被關掉false，所以找不到gamemusic了，無法用SetActive來寫。
            GameObject.Find("gamemusic").GetComponent<AudioSource>().enabled = true;
        }


        //到指定關卡名稱內
        Application.LoadLevel(NextSceneName);
    }
}
