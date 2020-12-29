
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;

    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance=2.5f;
    [Header("冷卻時間"), Range(0, 50)]
    public float cd = 2.5f;

    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;


    private void Awake()
    {
        //取得身上的元件<代理器>
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        //尋找其他遊戲物件("物件名稱").變形元件
        player = GameObject.Find("小名").transform;
        //代理器 的 速度 與 停止距離
        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }
    private void Update()
    {
        Track();
        Attack();
    }
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        if(nav.remainingDistance<stopDistance)
        {
            //時間 累加(一禎的時間)
            timer += Time.deltaTime;
            //取得玩家的座標
            Vector3 pos = player.position;
            //將玩家座標Y軸指定為 本物件的Y軸
            pos.y = transform.position.y;
            //看向(玩家的座標)
            transform.LookAt(pos);

            //如果 計時器>=冷卻時間 就攻擊 並且計時歸零
            if (timer >= cd)
            {
                ani.SetTrigger("攻擊");
                timer = 0;
            }
        }
    }



    ///<summary>
    ///追蹤
    /// </summary>
    private void Track()
    {
        nav.SetDestination(player.position);

        ani.SetBool("走路", nav.remainingDistance > stopDistance);
        
    }
}
