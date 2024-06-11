using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolBulletMember : MonoBehaviour
{
    // Start is called before the first frame update
    public PoolBullet pool;

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
        if(other.CompareTag("Enemy"))
        {
            pool.Kill(this);
        }
    }
}