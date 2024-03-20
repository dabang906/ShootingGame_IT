using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        // 1. 방향을 구한다.
        Vector3 dir = Vector3.down;
        // 2. 이동하고 싶다. 공식 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
