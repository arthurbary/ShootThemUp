using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    Point point;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Bullet"))
        {
            Point.point++;
        }
    }
}
