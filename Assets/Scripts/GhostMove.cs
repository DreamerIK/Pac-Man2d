using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;//массив Transform, чтобы позже мы могли установить путевые точки в Инспекторе
    int cur = 0;//индексная переменная, которая отслеживает точку пути, к которой в данный момент идет Blinky
    public float speed = 0.3f;//скорость движения

    void FixedUpdate()
    {
        // Waypoint not reached yet? then m
        Vector2 myPos = transform.position;
        Vector2 endPos = waypoints[cur].position;
        if (myPos.ToString().Equals(endPos.ToString()))
        {
            cur = (cur + 1) % waypoints.Length;
        } else
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }

       

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co)//тут можно добавить ендгейм
    {
        if (co.name == "pacman")
            Destroy(co.gameObject);
    }
}
