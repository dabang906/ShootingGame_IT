using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //ÃÑ¾Ë »ý»êÇÒ °øÀå
    public GameObject bulletFactory;
    //ÃÑ±¸
    public GameObject firePosition;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
