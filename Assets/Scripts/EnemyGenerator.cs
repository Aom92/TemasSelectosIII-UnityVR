using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Hugo Juárez Pérez.
//Generates enemies at random in a fixed plane.

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform spawnCenter;           // Center of the plane where the enemies will be spawned.
    public Transform goal;
    public float spawnTime = 3f;            // How many seconds between each spawn.
    public float spawnRateIncrease = 0.1f;  // How much the spawn rate increases each time.
    public float spawnRateTime = 10f;       // How many seconds between each spawn rate increase.
    public bool enabled = true;
    public UI_control GameManager;

    private float spawnTimer = 0f;
    private float spawnRateTimer = 0f;
    public int max_enemy = 15;      // Max number of enemies this spawner can generate.
    private int current_enemy = 0;  // Current number of enemies this spawner has generated.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Stop Spawning if game over.
        if (GameManager.GameOver)
        {
            enabled = false;
        }

        //Increase Timer.
        spawnTimer += Time.deltaTime;
        spawnRateTimer += Time.deltaTime;

        //If the timer exceeds the spawn time, spawn a new enemy.
        if (spawnTimer >= spawnTime)
        {
            if (current_enemy < max_enemy)
            {
                if (enabled)
                {
                    GenerateEnemy();
                    
                }
                spawnTimer = 0f;
            }
        }

        //Increase spawn rate timer.
        if (spawnRateTimer >= spawnRateTime)
        {
            if(spawnTime > 1.0)
            {
                spawnTime -= spawnRateIncrease;
                spawnRateTimer = 0f;
            }
            
        }
        

    }

    void GenerateEnemy()
    {
        // Instantiate the enemy at the position.
        Instantiate(enemyPrefab, new Vector3(spawnCenter.position.x, spawnCenter.position.y, 
                    spawnCenter.position.z), Quaternion.identity);
        
        enemyPrefab.GetComponent<MoveTo>().goal = goal;
        enemyPrefab.GetComponent<MoveTo>().script = GameManager;
        //enemyPrefab.transform.SetParent(this.transform);
        current_enemy++;

    }

    public void EnemyDestroyed()
    {
        current_enemy--;
    }
}
