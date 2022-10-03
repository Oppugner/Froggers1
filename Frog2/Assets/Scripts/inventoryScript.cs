using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventoryScript : MonoBehaviour
{
    //insert inventory script here

    [SerializeField] Toggle inventory;

    void Update()
    {
        GameObject objPanel = GameObject.Find("Objectives Panel");

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventory.isOn = !inventory.isOn;
           
        }
    }
}
