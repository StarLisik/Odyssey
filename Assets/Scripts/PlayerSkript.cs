using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkript : MonoBehaviour {

    public PlayerSkript instance;

    public static bool GameOver;
    public float NextShot; //время следующего выстрела
    public float ShotDelay; //задержка выстрела
    public GameObject Shot;
    public Transform Gun;
    public float XMin, XMax, ZMin, ZMax;
    public float speed; //скорость
    public float tilt; //поворот
    
    Rigidbody playerShip;

	// Use this for initialization
	void Start () {
        GameOver = false;
        instance = (this);
        playerShip = GetComponent<Rigidbody>();
	}

    private void OnDestroy()
    {
        GameOver = true;
    }

    // Update is called once per frame
    void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal"); //движение по горизонтали
        float moveVertical = Input.GetAxis("Vertical"); // движение по вертикали

        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed; //движение корабля
        playerShip.rotation = Quaternion.Euler(tilt * playerShip.velocity.z, 0, -tilt * playerShip.velocity.x); //поворот корабля

        float newXPosition = Mathf.Clamp(playerShip.position.x, XMin, XMax); //Назначение границ невылета по иксу
        float newZPosition = Mathf.Clamp(playerShip.position.z, ZMin, ZMax); //Назначение границ невылета по зеду

        playerShip.position = new Vector3(newXPosition, 0, newZPosition); //установка ограничения движения

        if (Time.time > NextShot && Input.GetKey("space"))
        {
            Instantiate(Shot, Gun.position, Quaternion.identity); //выстрелы (Instantiate - создание объекта)
            NextShot = Time.time + ShotDelay;
        }
    }
}
