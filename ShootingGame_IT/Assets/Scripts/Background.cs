using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material bgMaterial;
    public float scrollSpeed = 0.2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //2. 방향이 필요하다.
        Vector2 direction = Vector2.up;
        //3. 스크롤을 하고 싶다. P = P0 + vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
