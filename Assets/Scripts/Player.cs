using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int life;
    [SerializeField]public int totalLife = 3;
    public UnityEvent<int> onLosingLife;
    void Start()
    {
        life = totalLife;
    }

    // Update is called once per frame
    void Update()
    {
        playerGameOver();
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            life--;
            onLosingLife?.Invoke(life);
        }
    }
    void playerGameOver()
    {
        if (life <= 0)
        {
            Debug.Log("Enzo aime le caca!");
        }
    }
}
