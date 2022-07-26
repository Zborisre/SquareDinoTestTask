using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 2f;
    

    // ����� ������ ����, �� ��������� bulletSpeed
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }


    // ���������� ����, ��� ��������
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
