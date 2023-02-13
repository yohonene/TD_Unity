using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tileInteract : MonoBehaviour
{
    private Renderer obj_renderer;
    Color original_colour;

    [SerializeField]
    GameObject tower_held;



    void Start()
    {
        obj_renderer = GetComponent<Renderer>();
        original_colour = obj_renderer.material.color;
    }

    /// <summary>
    /// Changes tile colour to green when called
    /// </summary>
    public void tileHit()
    {
        obj_renderer.material.color = new Color(0.5f, 1f, 0.5f, 0.33f);
    }

    public bool isHoldingTower()
    {
        if (tower_held != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Changes colour back to normal colour when called
    /// </summary>
    public void tileLeft()
    {
        obj_renderer.material.color = original_colour;
    }

    /// <summary>
    /// Sets Tower GameObject to this tile
    /// </summary>
    public void setTower(GameObject tower, GameObject tower_manager)
    {
        //Get gold check method from tower_manager
        tower_manager.TryGetComponent(out goldPriceCheck checker);
        //Throw an error if manager cannot compare gold
        if (!checker) { throw new System.Exception("No goldPriceCheck component in Tower Manager"); }

        if (!tower_held & checker.priceCheck(tower))
        {
            //Create Vector so Tower is slightly above centre of tile
            Vector3 new_pos = transform.position;
            new_pos.y += 0.25f;
            //Create tower
            var new_tower = Instantiate(tower, new_pos, tower.transform.rotation);
            //Set tower_manager as object parent
            new_tower.transform.SetParent(tower_manager.transform);
            //Object is now holding a tower
            tower_held = new_tower;
        }
    }

}
