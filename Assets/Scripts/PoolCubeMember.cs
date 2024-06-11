using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCubeMember : MonoBehaviour
{
    // Start is called before the first frame update
    public PoolCube pool;

    private void OnBecameInvisible(){
        pool.Kill(this);
    }
}