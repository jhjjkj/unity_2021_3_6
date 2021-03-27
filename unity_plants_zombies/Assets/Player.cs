using UnityEngine;

public class Player : MonoBehaviour
{
     #region 欄位
    [Header("子彈")]
    public GameObject bullet;
    [Header("子彈生成點")]
    public Transform pointSpawn;
    [Header("子彈速度"), Range(0, 5000)]
    public int speedBullet = 800;
    [Header("開槍音效")]
    public AudioClip soundFire;
    [Header("血量"), Range(0, 200)]
    public float hp = 15;
    [Header("地面判定位移")]
    public Vector3 offset;
    [Header("地面判定半徑")]
    public float radius = 0.3f;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    /// <summary>
    /// 取得玩家水平軸向的值
    /// </summary>
    public float h;
    #endregion

    private void Start()
    {
        // GetComponent<泛型>()
        // 泛型: 泛指所有類型
        // GetComponent<Animator>()
        // GetComponent<AudioSource>()

        // 剛體欄位 = 取得元件<剛體>()
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetHorizontal();
        Fire();
    }

    // 在 Unity 內繪製圖示
    private void OnDrawGizmos()
    {
        // 圖示.顏色 = 顏色
        Gizmos.color = new Color(1, 0, 0, 0.35f);
        // 圖示.繪製球體(中心點, 半徑)
        Gizmos.DrawSphere(transform.position + offset, radius);
    }

    #region 方法
    /// <summary>
    /// 取得水平軸向
    /// </summary>
    private void GetHorizontal()
    {
        // 輸入.取得軸向("水平")
        h = Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))       // 如果按下左鍵 (手機為觸控)
        {
            // 音效來源.播放一次音效(音效片段, 音量)
            aud.PlayOneShot(soundFire, Random.Range(1.2f, 1.5f));
            // 區域變數 名稱 = 生成(物件, 座標, 角度)
            GameObject temp = Instantiate(bullet, pointSpawn.position, pointSpawn.rotation);
            // 暫存子彈.取得元件<剛體>().添加推力(生成點右邊 * 子彈速度 + 生成點上方 * 高度)
            temp.GetComponent<Rigidbody2D>().AddForce(pointSpawn.right * speedBullet + pointSpawn.up * 150);
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="getDamge">造成的傷害</param>
    private void Damge(float getDamge)
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }
    #endregion
}
}
