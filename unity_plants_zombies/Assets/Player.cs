using UnityEngine;

public class Player : MonoBehaviour
{
     #region 欄位
    [Header("子彈")]
    public GameObject bullet;
    [Header("子彈生成點")]
    public Transform point;
    [Header("子彈速度"), Range(0, 5000)]
    public int speedBullet = 800;
    [Header("開槍音效")]
    public AudioClip soundFire;
    [Header("血量"), Range(0, 200)]
    public float hp = 15;
    [Header("開槍間隔"), Range(0f, 5f)]
    public float interval = 1f;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private float timer;
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
        // 音效來源.播放一次音效(音效片段, 音量)
        aud.PlayOneShot(soundFire, Random.Range(1.2f, 1.5f));
        if (timer >= interval)
        {
            timer = 0;
            GameObject temp = Instantiate(bullet, point.position, point.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(point.right * speedBullet);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }
    #endregion
}
