using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public int health = 2;

	private void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.gameObject.name.Contains("laser")) {
			LaserBehaviour laser = theCollider.gameObject.GetComponent("LaserBehaviour") as LaserBehaviour;
			this.health -= laser.damage;

			Destroy(theCollider.gameObject);

			if (this.health <= 0) {
				Destroy(this.gameObject);

				GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
				controller.KillEnemy();
			}
		}

		if (theCollider.gameObject.name.Contains("playerShip")) {

		} 
	}
}
