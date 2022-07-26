using System.Collections.Generic;
using UnityEngine;


// ����� ������ ����
public class ObjectPooler : MonoBehaviour
{

    // ����� ���� ������� ����� Dictionary ����� �� ���� ���������� � �������� ����������� ����� ������������� public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static ObjectPooler instance;

    private List<GameObject> poolObjects = new List<GameObject>();
    private List<GameObject> RagdollObjects = new List<GameObject>();
    private int ColOfPool = 12;

    [SerializeField] private GameObject bulletPre;
    [SerializeField] private GameObject RagdollPre;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // �������� ����� �� �����
    void Start()
    {

        for (int i = 0; i < ColOfPool; i++)
        {
            GameObject obj = Instantiate(bulletPre);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }

        for (int i = 0; i < ColOfPool; i++)
        {
            GameObject obj = Instantiate(RagdollPre);
            obj.SetActive(false);
            RagdollObjects.Add(obj);
        }
    }

    // �������� ����
    public GameObject SpawnBullet()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }

        }
        return null;
    }

    // �������� ���������
    public GameObject SpawnRagdoll()
    {
        for (int i = 0; i < RagdollObjects.Count; i++)
        {
            if (!RagdollObjects[i].activeInHierarchy)
            {
                return RagdollObjects[i];
            }

        }
        return null;
    }

}