using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    void Pickup (Collider player)
    {
        //attack code
        Debug.Log("Picked up Ability");
        Destroy(gameObject);
    }
}
