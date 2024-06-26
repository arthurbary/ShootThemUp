using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolCubeMember : MonoBehaviour
{
    // Start is called before the first frame update
    public PoolCube pool;

    private void OnBecameInvisible(){
        pool.Kill(this);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            pool.Kill(this);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            pool.Kill(this);
        }
    }
}