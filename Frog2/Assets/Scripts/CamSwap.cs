using UnityEngine;

public class CamSwap : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            cam1.enabled = false;
            cam2.enabled = true;
        }
    }
}
