using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour2 : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    public float friction;          //Fricción que frena al objecto cuando dejamos de hacerle fuerza o moverlo. Valores entre 0 y 1 

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        Rotate();
        Move();
    }

    // Al rotar la nave, esta mirará el puntero del ratón
    private void Rotate()
    {
        // Obtenemos vector del ratón
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        float dx = this.transform.position.x - worldPos.x;
        float dy = this.transform.position.y - worldPos.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        // Vector de cuatro dimensiones
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        this.transform.rotation = rot;
    }

    // Mover el objeto aplicando fuerza que desaparece con el tiempo, hace el movimiento "mas natural"
    // Requiere un RigidBody2D asignado al objeto
    private void Move()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        //Frena el objecto quitandole fuerza hasta pararlo por completo
        rb2d.velocity = rb2d.velocity * (1f - friction);
        
        
    }
}
