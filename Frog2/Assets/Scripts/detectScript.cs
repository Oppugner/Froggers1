using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class detectScript : MonoBehaviour
{
    //string interactName;
    [SerializeField] Text interactOBJ;
    [SerializeField]LayerMask puzzleMask; //mask for puzzle items
    [SerializeField]LayerMask gravestoneMask; //mask for gravestone
    [SerializeField] LayerMask potionMask; //mask for gravestone

    Vector3 origin;
    Vector3 direction;

    float sphereRadius = 1.5f; //radius of detector
    float maxDistance = 2; //distance from player to target interact item
    float currenthitdistance;

    private void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, puzzleMask, QueryTriggerInteraction.UseGlobal))
        {
            interactOBJ.gameObject.SetActive(true);
            interactOBJ.text = hit.collider.name.ToString();
            currenthitdistance = hit.distance;
        } else if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, gravestoneMask, QueryTriggerInteraction.UseGlobal)) {
            interactOBJ.gameObject.SetActive(true);
            interactOBJ.text = hit.collider.name.ToString()+"\r\nPress [E]";
            if (Input.GetKey(KeyCode.E))
            {
                //Debug.Log(hit.collider.name);
                SceneManager.LoadScene(hit.collider.name);
            }
            currenthitdistance = hit.distance;
        } else if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, potionMask, QueryTriggerInteraction.UseGlobal)) {
            interactOBJ.gameObject.SetActive(true);
            interactOBJ.text = hit.collider.name.ToString();
        } else {
            currenthitdistance = maxDistance;
            interactOBJ.gameObject.SetActive(false);
        }
        //interactOBJ.text = interactName;
    }

    //detect debugger
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currenthitdistance);
        Gizmos.DrawWireSphere(origin + direction * currenthitdistance, sphereRadius);
    }
}

