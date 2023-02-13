using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldPriceCheck : MonoBehaviour
{
    [SerializeField]
    player_values _gold;
    [SerializeField]
    goldText gold_text;

    /// <summary>
    /// Checks if player can afford tower
    /// </summary>
    /// <param name="tower"></param>
    /// <returns></returns>
    /// <exception cref="System.Exception"></exception>
    public bool priceCheck(GameObject tower)
    {
        tower.TryGetComponent(out turret turret_);
        if (turret_ != null)
        {
            if (_gold.gold_total >= turret_.Gold_cost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        throw new System.Exception("Object has no turret component");

    }
    /// <summary>
    /// Removes X amount of gold from total
    /// Based on gold cost of tower
    /// </summary>
    /// <param name="tower"></param>
    public void priceDeduct(GameObject tower)
    {
        tower.TryGetComponent(out turret turret_);
        //Update total gold
        _gold.gold_total -= turret_.Gold_cost;
        //Update text
        gold_text.updateText();
    }
}
