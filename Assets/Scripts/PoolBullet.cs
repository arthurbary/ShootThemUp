using System.Collections.Generic;
using UnityEngine;

public class PoolBullet : MonoBehaviour
{
    private Stack<PoolBulletMember> pool = new();
    [Range(1, 100)][SerializeField] private int initialBatch = 50;
    [Range(1, 100)][SerializeField] private int batch = 10;

    [SerializeField] GameObject prefab;


    public void Awake()
    {
        Create(initialBatch);
    }

    private void Create(int number)
    {
        for (int _ = 0; _ < number; _++)
        {
            GameObject newOne = Instantiate(prefab);
            newOne.GetComponent<PoolBulletMember>().pool = this;
            Kill(newOne.GetComponent<PoolBulletMember>());
        }
    }

    public PoolBulletMember Spawn(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            Create(batch);
        }
        PoolBulletMember member = pool.Pop();
        Revive(member,position, rotation);
        return member;
    }

    public void Kill(PoolBulletMember member)
    {
        member.gameObject.SetActive(false);
        pool.Push(member);
    }

    public void Revive(PoolBulletMember member, Vector3 position, Quaternion rotation){
        member.gameObject.SetActive(true);
        member.transform.position = position;
        member.transform.rotation = rotation;
    }

}
