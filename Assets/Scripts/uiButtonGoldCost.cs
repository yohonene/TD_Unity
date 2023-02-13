using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class uiButtonGoldCost : MonoBehaviour
{
    [SerializeField]
    turret tower_cost;
    [SerializeField]
    TextMeshProUGUI ui_gold_cost;
    void Start()
    {
        ui_gold_cost.text = tower_cost.Gold_cost.ToString();
    }

}
