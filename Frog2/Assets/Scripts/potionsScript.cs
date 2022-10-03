using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionsScript : MonoBehaviour
{
    //quatity
    public static int healthPotion = 0;

    void Start()
    { 
        //kunwari inventory system
    }

    void Update()
    {
        useHealthPotion();
    }

    private void useHealthPotion()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(healthPotion > 0)
            {
                healthPotion--;
                playerScript.currentLife += 3;
            }
        }
    }
}
