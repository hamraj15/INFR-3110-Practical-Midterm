using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject: MonoBehaviour
{

    public Transform waypoint1, waypoint2;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = waypoint1.position;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        gameObject.transform.position = Vector3.Lerp(waypoint1.position, waypoint2.position, time);

    }
}
