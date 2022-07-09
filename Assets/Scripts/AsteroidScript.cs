using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AsteroidScript : MonoBehaviour
{

    public GameObject AsteroidExplosion;
    public GameObject PlayerExplosion;
    public GameObject GameOver;

    public float RotationSpeed;
    public float Lives;
    public float MinSpeed, MaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * RotationSpeed;
        Asteroid.velocity = Vector3.back * Random.Range(MinSpeed, MaxSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(PlayerExplosion, other.transform.position, Quaternion.identity);
            Instantiate(GameOver, transform.position, Quaternion.identity);
        }
        else if (other.tag == "Bullet")
        {
            Lives -= 1;
            Destroy(other.gameObject);
            Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);

            if (Lives == 0)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);
                CountingScoreScript.instance.IncrementScore(15);

                string sc = CountingScoreScript.instance.IncrementScore(0).ToString(); //Сохранение при уничтожении астероида

                StreamReader read = new StreamReader(SaveHighScoreScript.playerDataPath);
                if (int.Parse(read.ReadToEnd()) < CountingScoreScript.instance.IncrementScore(0))
                {
                    read.Close();
                    File.WriteAllText(SaveHighScoreScript.playerDataPath, sc);
                }
                read.Close();
            }
        }
    }
}
