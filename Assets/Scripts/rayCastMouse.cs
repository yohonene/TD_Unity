using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastMouse : MonoBehaviour
{
    Camera cam;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    GameObject tower;

    private tileInteract previous_tile;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        rayCastCamera();
        rayCastHit();
    }

    public void updateTowerHeld(GameObject new_tower)
    {
        tower = new_tower;
    }

    private void rayCastCamera()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos, Color.green);
    }

    private void rayCastHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Calculate ray baed on screen/camera position
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //If a tile before this was selected, deselect that one
            if(previous_tile != null) { previous_tile.tileLeft(); }

            //Sends out ray, checks LayerMask and only detects those
            //In this instance it will be the TILE layer
            if (Physics.Raycast(ray, out hit, 100,mask))
            {
                var tile_hit = hit.transform.GetComponent<tileInteract>();
                //Indicate that tile was hit
                tile_hit.tileHit();
                if (tower) { tile_hit.setTower(tower); tower = null; } //Set tower then remove it from "hand"
                previous_tile = tile_hit;
            }
        }
    }
}
