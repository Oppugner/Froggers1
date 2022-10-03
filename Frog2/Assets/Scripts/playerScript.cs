using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{

    CharacterController controller;
    float speed = 5.0f;
    float _rotationSpeed = 180;
    Vector3 rotation;

    [SerializeField] Slider healthBar;
    [SerializeField] Image healthFill;
    float life = 20;
    public static float currentLife;

   // Start is called before the first frame update
   void Start()
    {
        controller = GetComponent<CharacterController>();
        transform.position = new Vector3(0, -1, 0);
        currentLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        //life
        lifeSystem();
    }

    void lifeSystem()
    {
        healthBar.value = currentLife;

        if (currentLife == 0) {
            Debug.Log("lil forg is not moving cuz they already died");
        } else {
            move();
        }


        if (currentLife <= 10) {
            healthFill.color = new Color32(205, 47, 47, 255);
        }

        if (currentLife > life) {
            currentLife = life;
        }

    }

    void move() //character controllers
    {
        //movement
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        controller.Move(move * speed);
        this.transform.Rotate(this.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        //damage
        if (other.gameObject.name == "Enemy")
        {
            currentLife -= 2; //kunwari na damage ng snake
        }

        //potions behavior
        if (other.gameObject.name == "Health Potion")
        {
            Destroy(other.gameObject);
            potionsScript.healthPotion++; //press p to heal
            Debug.Log("Number of potions: "+potionsScript.healthPotion); //kunwari may inventory system
        }
    }

   
}
