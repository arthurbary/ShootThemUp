using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] GameObject prefab;
    [SerializeField]private PoolBullet pool;
    [SerializeField] private GameObject launchPoint;
    // Start is called before the first frame update
    void Start()
    {

        if (pool == null)
        {
            pool = GetComponent<PoolBullet>();
        }
        if (pool == null)
        {
            pool = FindObjectOfType<PoolBullet>();
        }
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while (true)
        {
            if (pool != null)
            {
                pool.Spawn(transform.position + Vector3.right, Quaternion.identity);
            }
            else
            {
                Instantiate(prefab, transform.position + Vector3.right, Quaternion.identity);
            }
            yield return new WaitForSeconds(cooldown);
        }
    }

}
