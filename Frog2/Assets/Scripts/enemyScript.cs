using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyScript : MonoBehaviour
{
    //enemy health bar
    GameObject enemy;
    [SerializeField] Slider enemyHPBar;
    float enemyHP = 5;
    float currentenemyHP;

    GameObject cam;
    Camera lookCam;

    void Start()
    {
        currentenemyHP = enemyHP;
        enemy = GetComponent<GameObject>();
        cam = GameObject.Find("Main Camera");
        lookCam = cam.GetComponent<Camera>();
    }

    void Update()
    {
        enemyHPBar.value = currentenemyHP;
    
        //health bar facing camera
        Vector3 v = lookCam.transform.position - transform.position;
        v.x = v.z = .0f;
        transform.LookAt(lookCam.transform.position-v);
        transform.Rotate(0, 180, 0);

        if (currentenemyHP < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentenemyHP--;
    }
}
