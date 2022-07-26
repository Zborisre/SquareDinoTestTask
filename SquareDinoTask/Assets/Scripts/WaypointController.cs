using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int targetWaypointIndex = 0;
    public float speed = 3.0f;
    private Transform waypointPos;
    private NavMeshAgent agent;
    public static bool gamestart;

    public GameObject panel;
    private Animator animator;
    private int SumOfEnemy = 9;

    public Text PointScore;

    // Назначение компонентов
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        waypointPos = waypoints[targetWaypointIndex];
        gamestart = false;
    }

    void Update()
    {
        // Первое нажатие экрана, начало движения
        if (Input.GetMouseButton(0))
        {
            GoToWaypoint();
            panel.SetActive(false);

        }

        // Проверка на законченность уровня, если да, то перезапуск сцены, если нет то остановка и начало возможности стрелять
        if (transform.position.x == waypointPos.position.x && transform.position.z == waypointPos.position.z && targetWaypointIndex == 4)
            SceneManager.LoadScene("MainScene");
        else if (transform.position.x == waypointPos.position.x && transform.position.z == waypointPos.position.z)
        {
            gamestart = true;
            animator.SetBool("Start", false);
        }

        // Условие нахожедения колличества врагов, благодаря чему и происходит дальнейщее движение по вейпоинту
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == SumOfEnemy)
        {
            WaypointChange();
            gamestart = false;
        }
        PointScore.text = ("Убито: " + Enemy.Score);

    }

    // Движение к следующему вейпоинту
    void GoToWaypoint()
    {
        agent.SetDestination(waypointPos.position);
        animator.SetBool("Start", true);
    }


    // Изменение вейпоинта на следующую
    void WaypointChange()
    {
        targetWaypointIndex += 1;
        waypointPos = waypoints[targetWaypointIndex];
        SumOfEnemy -= 3;
    }
}
