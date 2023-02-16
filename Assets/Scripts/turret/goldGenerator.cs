using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class goldGenerator : support
{
    [SerializeField]
    float time_between_gen;
    [SerializeField]
    int gold_per_tick;
    [SerializeField]
    Animator cart_animator;
    [SerializeField]
    AudioClip gold_sfx;

    goldText gold_text;

    // Start is called before the first frame update
    void Start()
    {
        //Get goldText component from parent (that manages all towers)
        //Do this because PREFAB items will only update the text when the game has ENDED
        //I spent like 4 hours working this out. Text must be made in editor NOT PREFABED
        SoundManager.Instance.PlaySound(gold_sfx);
        gold_text = GetComponentInParent<goldText>();
        StartCoroutine(gold_gen());
    }

    /// <summary>
    /// Calls addGold method from gold_text
    /// Repeats every time_between_gen
    /// Adds gold_per_tick
    /// </summary>
    /// <returns></returns>
    private IEnumerator gold_gen()
    {
        while (gameObject != null)
        {
            //Play the animation once
            cart_animator.Play("GetGold", -1, 0f);
            yield return new WaitForSeconds(time_between_gen);
            gold_text.addGold(gold_per_tick);

        }
        
    }


}
