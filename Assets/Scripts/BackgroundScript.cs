using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float speed;
    Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Mathf.Repeat(Time.time * speed, 10);
        transform.position = StartPosition + Vector3.back * move;
    }
}
