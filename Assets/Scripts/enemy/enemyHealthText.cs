using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyHealthText : MonoBehaviour
{
    [SerializeField]
    enemy enemy_values;
    [SerializeField]
    TMP_Text text_component;

    private float enemy_health;

    void Start()
    {
        textUpdate();
    }

    /// <summary>
    /// Updates text to current player health when called
    /// </summary>
    public void textUpdate()
    {
        enemy_health = enemy_values.getHealth();
        text_component.text = "HP:" + enemy_health;
    }

}
