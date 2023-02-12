using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class turretHealthText : MonoBehaviour
{

    [SerializeField]
    turret turret_values;
    [SerializeField]
    TMP_Text text_component;

    private float turret_health;

    void Start()
    {
        textUpdate();
    }
    /// <summary>
    /// Updates text to current player health when called
    /// </summary>
    public void textUpdate()
    {
        turret_health = turret_values.getHealth();
        text_component.text = $"{turret_health}";
    }

}
