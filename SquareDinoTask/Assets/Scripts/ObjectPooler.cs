using System.Collections.Generic;
using UnityEngine;


// Класс объект пула
public class ObjectPooler : MonoBehaviour
{

    // можно было сделать через Dictionary чтобы не было повторений и создание происходило через идентификатор public Dictionary<string, Queue<GameObject>> poolDictionary;
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

    // Создание пулов на сцене
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

    // Создание пуль
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

    // Создание регдоллов
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