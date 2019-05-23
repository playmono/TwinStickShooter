using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float currentSpeed = 0.0f;
    private Vector3 lastMovement = new Vector3();

    public float playerSpeed = 4.0f;

    // Update is called once per frame
    private void Update()
    {
        this.Rotate();
        this.Move();
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

    private void Move()
    {
        // movement es un vector normalizado de tipo (1,0), (0,1)... etc dependiendo de los axis

        Vector3 movement = new Vector3();

        movement.x += Input.GetAxis("Horizontal");
        movement.y += Input.GetAxis("Vertical");

        movement.Normalize();

        if (movement.magnitude > 0) {
            this.currentSpeed = this.playerSpeed;
            this.transform.Translate(movement * this.currentSpeed * Time.deltaTime, Space.World);
            this.lastMovement = movement;
        } else {
            // Inercia del último movimiento
            this.transform.Translate(movement * this.currentSpeed * Time.deltaTime, Space.World);
            this.currentSpeed *= 0.9f;
        }
    }
}