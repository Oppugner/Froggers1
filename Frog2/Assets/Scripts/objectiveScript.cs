using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectiveScript : MonoBehaviour
{

    //insert objective script here
    Toggle objective;
    [SerializeField] GameObject objectPanel;
    bool current = false;

    private void Start()
    {
        objective = GetComponent<Toggle>();
        objective.onValueChanged.AddListener(delegate { ToggleValueChanged(objective);});
        objectPanel.SetActive(current);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            current = !current;
            objective.isOn = !objective.isOn;
            objectPanel.SetActive(current);
        }
    }

    void ToggleValueChanged(Toggle change)
    {
        objectPanel.SetActive(current);
    }
}
