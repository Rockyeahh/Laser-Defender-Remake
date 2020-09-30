using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] enemies;
    public GameObject enemyBossPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Enable Enemy gameObjects/children. // Game objects tagged as Enemy set disable
        if (enemies == null)
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject Enemy in enemies)
        {
            print("work you cunt");
            Enemy.SetActive(true);
            print("Set enemy active");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Reset();
        }
    }

    // Spawn Enemies // test by spawning one enemy first. Then if it works have them spawn as a whole formation under a prefab
    void SpawnEnemies()
    {
        //GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
    }

    // Spawn Boss
    void SpawnBoss()
    {
        //GameObject enemyBoss = Instantiate(enemyBossPrefab, transform.position, Quaternion.identity) as GameObject;
    }

    // Reset Eneimes    // Reset Enemy transform.position, animations?
    void Reset()
    {
        print("Reset Enemies");
    }

}
