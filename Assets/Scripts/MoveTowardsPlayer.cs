using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
	private Transform player;

	public float speed = 0.03f;

    // Start is called before the first frame update
    private void Start()
    {
        this.player = GameObject.Find("playerShip").transform;
    }

    // Update is called once per frame
    private void Update()
    {
   		if (!PauseMenuBehaviour.isPaused) {
			Vector3 direction = player.position - this.transform.position;
			direction.Normalize();

			this.transform.position += direction * speed;
		}
    }
}
