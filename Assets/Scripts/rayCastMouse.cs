using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class rayCastMouse : MonoBehaviour
{
    Camera cam;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    GameObject tower;
    [SerializeField]
    GameObject tower_manager;
    [SerializeField]
    GameObject tower_displayed = null;
    [SerializeField]
    goldPriceCheck checker;
    [SerializeField]
    UnityEngine.UI.Button banana_button;
    [SerializeField]
    AudioClip sfx;

    public bool canBuyBanana = true;

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

    /// <summary>
    /// Called by ButtonClick() Event in UI
    /// </summary>
    /// <param name="new_tower"></param>
    public void updateTowerHeld(GameObject new_tower)
    {;

        //If can afford, change tower to button allocated tower, reset potential tower display
        if (checker.priceCheck(new_tower)) { tower = new_tower; tower_displayed = null;} 
        else
        {
            tower = null;
        }
    }

    private void rayCastCamera()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos, Color.green);
    }

    /// <summary>
    /// Displays tower after a button has been clicked and before 
    /// tower has been placed
    /// </summary>
    private void displayPotentialTower(Ray ray)
    {
        //Check if a tower is currently being displayed by mouse
        if (tower_displayed)
        {
            //If so, ray cast to detect tiles and only show
            //When an avaliable tile is detected
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                //If a tile before this was selected, deselect that one
                if (previous_tile != null) { previous_tile.tileLeft(); }

                var tile_hit = hit.transform.GetComponent<tileInteract>();

                //If this tile is not holding a tower
                if (!tile_hit.isHoldingTower())
                {
                    //Indicate that tile was hit
                    tile_hit.tileHit();

                    //If tile detected, snap to centre and show
                    tower_displayed.SetActive(true);
                    var tile_pos = hit.collider.gameObject.transform.position;
                    //Offset so it isn't halfway in the ground
                    tile_pos.y += 0.25f;
                    tower_displayed.transform.position = tile_pos;

                } else
                {
                    //Else if hovering over already placed tower
                    tower_displayed.SetActive(false);
                }
                //Update previous tile
                previous_tile = tile_hit;

            } else
            {
                //If a tile has not been detected, hide both object and green select
                if (previous_tile != null) { previous_tile.tileLeft(); }
                tower_displayed.SetActive(false);

            }
            return;
        }

        //If no tower is displayed and a tower has been clicked, display potential tower
        if (tower_displayed == null & tower)
        {
            tower_displayed = Instantiate(tower);
            //Remove any components that would affect gameplay
            tower_displayed.TryGetComponent(out turretShoot shoot);
            Destroy(shoot);
            tower_displayed.TryGetComponent(out turret twer);
            Destroy(twer);
            tower_displayed.TryGetComponent(out support supp);
            Destroy(supp);
            tower_displayed.TryGetComponent(out banana ban);
            Destroy(ban);
            tower_displayed.layer = 8; //8 refers to layer Potential_Tower;
        }
    }                

    //Stop user from buying banana for X seconds
    private IEnumerator buyCooldown(int time)
    {
        canBuyBanana = false;
        banana_button.interactable = false;
        //Set button to grey to signify off cooldown
        ColorBlock colours = banana_button.colors;
        colours.normalColor = Color.gray;
        yield return new WaitForSeconds(time);
        colours.normalColor = Color.white;
        banana_button.interactable = true;
        canBuyBanana = true;
    }


    private void checkSupport()
    {
        //If support tower is bought and its not on cooldown, set it on cooldown and continue, else return
        if (tower.CompareTag("Support"))
        {

            if (!canBuyBanana) { return; }
            else
            {
                StartCoroutine(buyCooldown(5));
            }
        }

    }

    private void rayCastHit()
    {
        //Calculate ray baed on screen/camera position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        displayPotentialTower(ray);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            //Remove highlight under tile
            if (previous_tile != null) { previous_tile.tileLeft(); }

            //Sends out ray, checks LayerMask and only detects those
            //In this instance it will be the TILE layer
            if (Physics.Raycast(ray, out hit, 100,mask))
            {
                var tile_hit = hit.transform.GetComponent<tileInteract>();
                //Indicate that tile was hit

                //Check if banana is able to be placed
                if (!canBuyBanana & tower.CompareTag("Support")) { return; }

                if (tower) {
                    //Deduct gold from player
                    checker.priceDeduct(tower);
                    checkSupport(); //Put banana on cooldown if it was chosen
                    //Place tower and remove it from hand
                    tile_hit.setTower(tower, tower_manager); tower = null;
                    SoundManager.Instance.PlaySound(sfx);
                    Destroy(tower_displayed); //Remove potential_tower being displayed

                    tower_displayed = null; 
                } 

            }
        }
    }
}
