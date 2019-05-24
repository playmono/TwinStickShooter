using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public int health = 2;
	public Transform explosion;
	public AudioClip hitSound;

	private void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.gameObject.name.Contains("laser")) {
			LaserBehaviour laser = theCollider.gameObject.GetComponent("LaserBehaviour") as LaserBehaviour;
			this.health -= laser.damage;

			Transform.Destroy(theCollider.gameObject);

			if (this.health <= 0) {
				Transform.Destroy(this.gameObject);

				GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
				controller.KillEnemy();
				controller.sumScore(10);

				if (this.explosion) {
					Transform t = Transform.Instantiate(explosion, this.transform.position, this.transform.rotation);
					GameObject exploder = t.gameObject;

					Transform.Destroy(exploder, 2.0f);

					this.GetComponent<AudioSource>().PlayOneShot(hitSound);
				}
			}
		}

		if (theCollider.gameObject.name.Contains("playerShip")) {

		} 
	}
}
