using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 2f;
    

    // Метод вылета пули, со скоростью bulletSpeed
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }


    // Отключение пули, при коллизии
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
