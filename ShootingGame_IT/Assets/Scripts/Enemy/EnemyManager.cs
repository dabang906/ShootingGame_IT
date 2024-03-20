using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 현재시간
    float minTime = 1f;
    float maxTime = 5f;
    float currentTime;
    // 일정시간
    public float createTime = 1;
    // 적 공장
    public GameObject enemyFactory;
    void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }
    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            // 3. 적 공장에서 적을 생성해서
            GameObject enemy = Instantiate(enemyFactory);
            // 내 위치에 갖다 놓고 싶다.
            enemy.transform.position = transform.position;
            currentTime = 0;
            // 현재시간을 0으로 초기화
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}