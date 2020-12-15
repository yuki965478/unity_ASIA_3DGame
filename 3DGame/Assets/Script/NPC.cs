using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCDdata data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;

    //<summary>
    //玩家是否進入感應區
    //</summary>

    public bool playerInArea;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="小名")
        {
            playerInArea = true;
            Dialog();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name=="小名")
        {
            playerInArea = false;
        }
    }
    private void Dialog()
    {
        //print(data.dialougA);//取得字串全部資料


        ////for 迴圈：重複處理相同程式
        //for(int i = 0; i < 10; i++) 
        //{
        //    print("我是迴圈" + i);
        //}

        //字串的長度：dialogA.Length
        for (int i = 0; i < data.dialougA.Length; i++)
        {
            print(data.dialougA[i]);
        }
    }
}
