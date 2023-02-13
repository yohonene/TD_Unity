using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeUpdater : MonoBehaviour
{
    [SerializeField]
    player_values _time;
    [SerializeField]
    GameObject game_over_screen;

    private void Start()
    {
        _time.time = 0f;
    }
    void Update()
    {
        //Update time if GAMEOVERUI is not enabled
        if(!game_over_screen.activeSelf)
        {
            _time.time += Time.deltaTime;
        }
        
    }
}
