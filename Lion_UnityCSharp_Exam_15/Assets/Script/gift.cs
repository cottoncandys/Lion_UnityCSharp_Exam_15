using UnityEngine;
using System.Linq;                
using System.Collections;  
using System.Collections.Generic; 


[ExecuteInEditMode]
public class gift : MonoBehaviour
{
    ///<summary>
    ///所有獎
    ///</summary>
    public List<GameObject> gifts = new List<GameObject>(); //cards  gifts

    /// <summary>
    ///分類
    /// </summary>
   private string[] type = { "A", "B", "C", "D","E" };

   

    private void Start()
    {
        GetAllGifts();
    }

    ///<summary>
    ///取得所有
    ///</summary>
    private void GetAllGifts()
    {
        if (gifts.Count == 25) return; 

        //跑5個
        for (int i = 0; i < type.Length; i++)
        {
            //跑1-5張
            for (int j = 1; j < 6; j++)
            {
                string number = j.ToString();//數字 = j.轉字串

                
                //卡牌 = 素材.載入<遊戲物件>("素材名稱")
                GameObject gift = Resources.Load<GameObject>("gifts_" + number + type[i]); //card   gift
                //.添加
                gifts.Add(gift);
            }
        }
    }


    

    ///<summary>
    ///洗牌
    /// </summary>
    public void Shuffle()
    {
        DeleteAllChild();

        //參考型別 - ToArray() 轉為陣列實值型別 ToList() 轉回清單
        List<GameObject> shuffle = gifts.ToArray().ToList();    //另存一份洗牌用原始牌組
        List<GameObject> newGifts = new List<GameObject>();     //儲存洗牌後的新牌組 //newCards  newGifts

        for (int i = 0; i < 25; i++)
        {
            int r = Random.Range(0, shuffle.Count);                 //從洗牌用牌組隨機挑一張

            GameObject temp = shuffle[r];                           //挑出來的隨機卡牌
            newGifts.Add(temp);                                     //添加到新牌組
            shuffle.RemoveAt(r);                                    //刪除挑出來的牌
        }

        foreach (var item in newGifts) Instantiate(item, transform);

        StartCoroutine(SetChildPosition());
    }

   
    ///<summary>
    ///刪除所有子物件
    /// </summary>
    private void DeleteAllChild()
    {
        for (int i = 0; i < transform.childCount; i++) Destroy(transform.GetChild(i).gameObject);
    }

    ///<summary>
    ///設定子物件座標:排序、大小、角度
    /// </summary>
    private IEnumerator SetChildPosition()
    {
        yield return new WaitForSeconds(0.1f); //避免刪除這次的卡牌

        for (int i = 0; i < transform.childCount; i++) //迴圈執行每一個子物件
        {
            Transform child = transform.GetChild(0);        //取得子物件
            child.eulerAngles = new Vector3(0, 0, 0);     //設定角度
            child.localScale = Vector3.one * 2.5f;            //設定尺寸



            float x = i % 5;

            float y = i / 5;
            child.position = new Vector3((x - 5) * 0.8f, 5 - y * 1, 0);

            yield return transform.GetChild(1);
        }
    }



}
