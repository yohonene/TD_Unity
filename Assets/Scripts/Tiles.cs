using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Tiles : MonoBehaviour
{
    [SerializeField]
    GameObject Tile;
    [SerializeField]
    float tile_padding;
    [SerializeField]
    private int rows;
    [SerializeField]
    private int columns;
    [SerializeField]
    GameObject enemySpawner;

    private GameObject[,] tile_list;

    void Start()
    {
        //Starting Position - Tile Manager
        Vector3 tile_manager_pos = gameObject.transform.position;
        //Position that will be updated
        Vector3 new_pos = tile_manager_pos;
        //Distance tile will move
        Vector3 vector_move = new Vector3(1 + tile_padding, 0, 0);
        //Initialise new tile list
        tile_list = new GameObject[rows, columns];
        //Fill 2D array with Tile objects
        for (int x = 0; x < rows; x++)
        {
            
            for (int y = 0; y < columns; y++)
            {
                //Place spawners only on top row
                if (x == 0) { attachEnemySpawner(new_pos); } 
                //Spawn tile
                var new_tile = Instantiate(Tile, tile_manager_pos, transform.rotation);
                //Add as child to TileHandler
                new_tile.transform.parent = gameObject.transform;
                //Change value to relevant position
                new_tile.transform.position = new_pos;
                //Add tile to array
                tile_list[x,y] = new_tile;
                new_pos += vector_move;
            }
            //Move to next column (with optional padding) and reset row
            new_pos.x = tile_manager_pos.x;
            new_pos += Vector3.back;
        }
    }
    
    /// <summary>
    /// When called places an enemy spawner
    /// </summary>
    private void attachEnemySpawner(Vector3 spawn_pos)
    {
        //Create Vector so Tower is slightly above centre of tile
        Vector3 new_pos = transform.position;
        spawn_pos.y += 0.25f;
        //Put spawners just before tile (not on)
        spawn_pos.z += 1.5f;
        //Create spawner, flip 180
        var spawner = Instantiate(enemySpawner, spawn_pos, 
            enemySpawner.transform.rotation * Quaternion.Euler (0f, 180f, 0f));
    }


}
