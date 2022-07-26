using UnityEngine;

public class WeaponFIre : MonoBehaviour
{

    public double dx;
    public double dy;

    public float bulletSpeed = 2f;
    public float speed = 5f;
    Vector3 towardPos;

    // Проверка на тап и на true статической переменной gamestart
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && WaypointController.gamestart)
        {
            TransformBullet();
        }
    }

    // Создание луча из точки тапа, контейнер для сохранения столкновения, и поворот игрока с последующим выстрелом
    void TransformBullet()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)); 
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit)) 
        {
            towardPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = towardPos - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed);
            Fire();
        }
    }

    // Выстрел, включение объекта Bullet
    void Fire()
    {
        GameObject bullet = ObjectPooler.instance.SpawnBullet();
        if (bullet != null)
        {
            var step = bulletSpeed * Time.deltaTime;
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
}