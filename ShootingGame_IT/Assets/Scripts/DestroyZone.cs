using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //1.만약 부딪힌 물체가 Bullet 이거나 Enemy 이라면
        if (other.gameObject.name.Contains("Bullet") ||
            other.gameObject.name.Contains("Enemy"))
        {
            //2.부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);
            //3. 부딪힌 물체가 총알일 경우 총알 리스트에 삽입
            if (other.gameObject.name.Contains("Bullet"))
            {
                // PlayerFire 클래스 얻어오기
                PlayerFire player =
                GameObject.Find("Player").GetComponent<PlayerFire>();
                // list 에 총알 삽입
                player.bulletObjectPool.Add(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                // EnemyManager 클래스 얻어오기
                GameObject emObject =
                              GameObject.Find("EnemyManager");
                EnemyManager manager =
                              emObject.GetComponent<EnemyManager>();
                // list 에 총알 삽입
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
    }
}
