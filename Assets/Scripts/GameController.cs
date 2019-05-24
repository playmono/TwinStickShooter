using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public Transform enemy;

	[Header("Enemy Waves")]
	private int currentNumberOfEnemies = 0;

	public float timeBeforeSpawning = 1.5f;
	public float timeBetweenEnemies = 0.25f;
	public float timeBetweenWaves = 2.0f;
	public int enemiesPerWave = 10;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Corutina en Unity
    private IEnumerator SpawnEnemies()
    {
    	yield return new WaitForSeconds(this.timeBeforeSpawning);

    	while (true) {
    		if (currentNumberOfEnemies <= 0) {
    			for (int i = 0; i < this.enemiesPerWave; i++) {
    				// Calculamos la distancia y el punto en circunferencia del enemigo
    				float randDistance = Random.Range(10, 25);
    				Vector2 randDirection = Random.insideUnitCircle;

    				// this.transform.position es sobre GameController (0,0)
    				Vector3 enemyPos = this.transform.position;
    				enemyPos.x = randDirection.x * randDistance;
    				enemyPos.y = randDirection.y * randDistance;

    				Instantiate(this.enemy, enemyPos, this.transform.rotation);

    				this.currentNumberOfEnemies++;

    				yield return new WaitForSeconds(timeBetweenEnemies);
    			}
    		}

    		yield return new WaitForSeconds(this.timeBetweenWaves);
    	}
    }

    public void KillEnemy()
    {
    	this.currentNumberOfEnemies--;
    }
}
