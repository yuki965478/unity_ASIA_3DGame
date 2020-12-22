using UnityEngine;
using UnityEngine.UI;
using System.Collections;//引用系統.集合API(包含協同程序)

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCDdata data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話著名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;

    //<summary>
    //玩家是否進入感應區
    //</summary>

    public bool playerInArea;

    //定義列舉eume (下拉是選單-只能選一個)
    public enum NPCState 
    {
        FirstDialog,Missioning,Finish
    }
    //列舉欄位
    //修ˋ慈 列舉平稱 自定義欄位名稱 指定 預設值;
    public NPCState state = NPCState.FirstDialog;

   /* 偕同程序
    * private void Start()
    {
        //啟動協成
        StartCoroutine(Test()); 
    }

    private IEnumerator Test()
    {
        print("嗨~");
        yield return new WaitForSeconds(1.5f);
        print("嗨我是1.5秒後)");
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="小名")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name=="小名")
        {
            playerInArea = false;
            StopDialog();
        }
    }
    /// <summary>
    /// 停止對話
    /// </summary>
    private void StopDialog()
    {
        dialog.SetActive(false);
        StopAllCoroutines();
    
    }
    /// <summary>
    /// 開始對話
    /// </summary>
    private IEnumerator Dialog()
    {
        /**print(data.dialougA);//取得字串全部資料


      for 迴圈：重複處理相同程式
      for(int i = 0; i < 10; i++) 
      {
           print("我是迴圈" + i);}
           字串的長度：dialogA.Length
        **/

        //顯示對話框
        dialog.SetActive(true);
        //清空文字
        textContent.text = "";
        //對話者名稱 指定為 此物件名稱
        textName.text= name;

        //要說的對話
        string dialogString = data.dialougB;

        switch (state)
        {
            case NPCState.FirstDialog:
                dialogString =data.dialougA;
                break;
            case NPCState.Missioning:
                dialogString = data.dialougB;
                break;
            case NPCState.Finish:
                dialogString = data.dialougC;
                break;
         
        }


        textName.text = name;
        //字串的長度dialogA.Length
        for (int i = 0; i < dialogString.Length; i++)
        {
            //print(date.dialogA[i]);
            //文字 串聯
            textContent.text += dialogString[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }
}
