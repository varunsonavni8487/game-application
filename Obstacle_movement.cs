using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_movement : MonoBehaviour
{
    public float speed_rotate_x = 0;
    public float speed_rotate_y = 2;
    public float speed_rotate_z = 0;

    void Update()
    {
        transform.Rotate(speed_rotate_x, speed_rotate_y, speed_rotate_z);
    }
}
