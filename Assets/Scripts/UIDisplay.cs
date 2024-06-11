using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    TMPro.TMP_Text text;
    int lastCount;
    Player player;
    void OnEnable()
    {
        player.onLosingLife.AddListener(UpdateCount);
    }

    void OnDisable()
    {
        player.onLosingLife.RemoveListener(UpdateCount);
    }
    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame

    void UpdateCount(int life)
    {
        if( lastCount != life)
        {
            if (life <= 0)
            {
                text.text = "GAME OVER";
            } 
            else 
            {
                text.text = $"Life Count: {life}/{player.totalLife}";
                lastCount = life;
            }
        }
    }
}
