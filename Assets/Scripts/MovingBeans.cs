using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBeans : MonoBehaviour
{
    void Update()
    {
    transform.position = new Vector3( transform.position.x, Mathf.PingPong(Time.time,1),transform.position.z);
    }
}
