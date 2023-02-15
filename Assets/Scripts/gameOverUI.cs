using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameOverUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text score_Text;
    [SerializeField]
    player_values _time;


    /// <summary>
    /// When called displays game over UI
    /// </summary>
    /// <param name="time"></param>
    public void callGameOver()
    {
        gameObject.SetActive(true);
        score_Text.text = $"Time Survived: {_time.time}";
    }

    /// <summary>
    /// When called, restarts level
    /// </summary>
    public void restartGameButton()
    {
        SceneManager.LoadScene("Fields");
    }

}
