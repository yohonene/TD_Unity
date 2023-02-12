using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class goldText : MonoBehaviour
{
    [SerializeField]
    public gold _gold;
    [SerializeField]
    TextMeshProUGUI gold_text;


    private void Start()
    {
        _gold.gold_total = 0;
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
        Debug.Log("called");
        gold_text.text = "gold: " + _gold.gold_total;
        Debug.Log("updating text" + gold_text.text);
        
    }

    private void FixedUpdate()
    {
        //updateText();
    }
}
