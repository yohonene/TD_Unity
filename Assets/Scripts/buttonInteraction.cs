using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class buttonInteraction : MonoBehaviour
{
    [SerializeField]
    GameObject tower;
    [SerializeField]
    goldPriceCheck checker;

    public void buttonSelected()
    {
        Debug.Log("Selected:" + tower.name);

        var button = gameObject.GetComponent<UnityEngine.UI.Button>();
        ColorBlock colours = button.colors;

        //If tower can be bought
        if (checker.priceCheck(tower))
        {
            colours.selectedColor = Color.green;
            
        }
        else
        {
            colours.selectedColor = Color.red;
        }

        button.colors = colours;
    }
}
