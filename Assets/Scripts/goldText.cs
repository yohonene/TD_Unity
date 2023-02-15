using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class goldText : MonoBehaviour
{
    [SerializeField]
    public player_values _gold;
    [SerializeField]
    TextMeshProUGUI gold_text;
    [SerializeField]
    int player_starting_gold;


    private void Start()
    {
        _gold.gold_total = player_starting_gold;
        updateText();
    }


    /// <summary>
    /// Adds gold to total and updates UI Gold Text
    /// </summary>
    /// <param name="gld"></param>
    public void addGold(int gld)
    {
        _gold.gold_total += gld;
        updateText();
    }

    public void updateText()
    {
        gold_text.text = _gold.gold_total.ToString();  
    }

    private void FixedUpdate()
    {
        //updateText();
    }
}
