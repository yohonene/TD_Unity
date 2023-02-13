using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldPriceCheck : MonoBehaviour
{
    [SerializeField]
    player_values _gold;
    [SerializeField]
    goldText gold_text;

    public bool priceCheck(GameObject tower)
    {
        tower.TryGetComponent(out turret turret_);

        Debug.Log("hi");
        if (turret_ != null)
        {
            if (_gold.gold_total >= turret_.Gold_cost)
            {
                //Update total gold
                _gold.gold_total -= turret_.Gold_cost;
                //Update text
                gold_text.updateText();
                return true;
            }
            else
            {
                return false;
            }
        }

        throw new System.Exception("Object has no turret component");

    }
}
