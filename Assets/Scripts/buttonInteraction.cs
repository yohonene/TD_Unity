using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonInteraction : MonoBehaviour
{
    [SerializeField]
    GameObject tower;
    public void buttonSelected()
    {
        Debug.Log("Selected:" + tower.name);
    }
}
