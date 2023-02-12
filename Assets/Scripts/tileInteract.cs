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
    public void setTower(GameObject tower)
    {
        
        if (!tower_held)
        {
            //Create Vector so Tower is slightly above centre of tile
            Vector3 new_pos = transform.position;
            new_pos.y += 0.25f;
            //Create tower
            var new_tower = Instantiate(tower, new_pos, tower.transform.rotation);
            //Object is now holding a tower
            tower_held = new_tower;
        }
    }

}
