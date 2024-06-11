using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    TMPro.TMP_Text text;
    int lastLifeCount;
    int lastPointCount;
    Player player;
    Enemy enemy;
    void OnEnable()
    {
        player.onLosingLife.AddListener(UpdateLife);
    }

    void OnDisable()
    {
        player.onLosingLife.RemoveListener(UpdateLife);
    }
    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        text.text = $"Life Count: {player.totalLife}/{player.totalLife} - Point {Point.point}";
    }

    // Update is called once per frame

    void UpdateLife(int life)
    {
        if( lastLifeCount != life)
        {
            if (life <= 0)
            {
                text.text = "GAME OVER";
            } 
            else 
            {
                text.text = $"Life Count: {life}/{player.totalLife} - Point {Point.point}";
                lastLifeCount = life;
            }
        }
    }
}
