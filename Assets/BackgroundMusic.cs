using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    AudioClip music;
    void Start()
    {
        SoundManager.Instance.PlayBGM(music);
    }


}
