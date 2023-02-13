using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _health;
    [SerializeField]
    turretHealthText textScript;
    [SerializeField]
    Renderer tower_renderer;
    [SerializeField]
    int _gold_cost;

    public int Gold_cost => _gold_cost;

    /// <summary>
    /// Returns health to requestee
    /// </summary>
    /// <returns></returns>
    public float getHealth()
    {
        return _health;
    }


    /// <summary>
    /// Subtracts health from enemy and calls change colour
    /// </summary>
    public void damageTower()
    {
        //Change health
        _health -= 1;
        //Visually change appearance to show that damage was taken
        StartCoroutine(change_colour());

        //Kill enemy if health reaches 0
        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        //Update Text Above Enemy
        textScript.textUpdate();
    }

    private IEnumerator change_colour()
    {
        //Save original colour
        var org_colour = tower_renderer.material.color;
        //Change colour to red
        tower_renderer.material.color = Color.red;
        //Wait 1 second before changing back
        yield return new WaitForSeconds(0.5f);
        tower_renderer.material.color = org_colour;
    }

}
