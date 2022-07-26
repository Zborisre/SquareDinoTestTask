using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 2;
    private int Health;

    public Image HealthBar;
    private float fill;

    public static int Score;

    private void Start()
    {
        Health = maxHealth;
        fill = 1f;
        Score = 0;
    }

    // �������� �� �������� � ����� ����� ��������� 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if(Health == 1)
            {
                Dead();
                Score += 1;
            }
            else
            {
                Health--;
                fill = (float)Health / maxHealth;
                HealthBar.fillAmount = fill;
            }
        }
    }

    // ������ ��� ������, ���������� ������� � �������� ������
    void Dead()
    {
        GameObject ragdoll = ObjectPooler.instance.SpawnRagdoll();
        if (ragdoll != null)
        {
            ragdoll.transform.position = transform.position;
            ragdoll.transform.rotation = transform.rotation;
            ragdoll.SetActive(true);

        }

        Destroy(gameObject);
    }


}
