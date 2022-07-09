using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{

    public GameObject Enemy;
    public float MinDelay, MaxDelay;

    float NextLaunch;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > NextLaunch)
        {
            float size = transform.localScale.x;
            float xPos = Random.Range(-size / 2, size / 2);
            Vector3 EnemyPosition = new Vector3(xPos, 0, transform.position.z);
            Instantiate(Enemy, EnemyPosition, Quaternion.identity);
            NextLaunch = Time.time + Random.Range(MinDelay, MaxDelay);
        }
    }
}
