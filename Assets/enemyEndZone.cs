using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyEndZone : MonoBehaviour
{
    [SerializeField]
    private int enemies_let_in = 0;
    [SerializeField]
    private int defeat_condition = 3;
    [SerializeField]
    gameOverUI game_over_screen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Only count enemy objects (not their accesories)
            enemies_let_in++;

            //Destroy enemy
            Destroy(other.gameObject);


            if (enemies_let_in >= defeat_condition)
            {
                //Display game over UI
                game_over_screen.callGameOver();
            }
        }

    }
}
