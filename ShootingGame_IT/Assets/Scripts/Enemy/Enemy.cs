using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public float speed = 5;
    public GameObject explosionFactory;
    void Start()
    {
        int randValue = UnityEngine.Random.Range(0, 10);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // 2. 이동하고 싶다. 공식 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            // 에너미를 잡을 때마다 현재 점수 표시하고 싶다.
            ScoreManager.Instance.Score++;
        }
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        // 만약 부딪힌 객체가 Bullet 인 경우에는 비활성화 시켜 탄창에 다시 넣어준다.
        //1.만약 부딪힌 물체가 Bullet 이라면
        if (other.gameObject.name.Contains("Bullet"))
        {
            //2.부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);
            // PlayerFire 클래스 얻어오기
            PlayerFire player =
            GameObject.Find("Player").GetComponent<PlayerFire>();
            // list 에 총알 삽입
            player.bulletObjectPool.Add(other.gameObject);
        }
        //3.그렇지 않으면 제거
        else
        {
            Destroy(other.gameObject);
        }
        gameObject.SetActive(false);
        // EnemyManager 클래스 얻어오기
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager =
                              emObject.GetComponent<EnemyManager>();
        // list 에 총알 삽입
        manager.enemyObjectPool.Add(gameObject);
    }
}
