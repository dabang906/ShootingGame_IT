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
            // 1. 씬에서 ScoreManager 객체를 찾아오자
            GameObject smObject = GameObject.Find("ScoreManager");
            // 2.ScoreManager 게임오브젝트에서 얻어 온다
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            // 3. ScoreManager 의 Get/Set 함수로 수정
            sm.SetScore(sm.GetScore() + 1);
        }
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
