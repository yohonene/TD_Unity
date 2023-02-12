using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class goldGenerator : MonoBehaviour
{
    [SerializeField]
    float time_between_gen;
    [SerializeField]
    int gold_per_tick;

    goldText gold_text;

    // Start is called before the first frame update
    void Start()
    {
        //Get goldText component from parent (that manages all towers)
        //Do this because PREFAB items will only update the text when the game has ENDED
        //I spent like 4 hours working this out. Text must be made in editor NOT PREFABED
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
            Debug.Log("in loop");
            gold_text.addGold(gold_per_tick);
            yield return new WaitForSeconds(time_between_gen);
        }
        
    }


}
