using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] enemies;
    public GameObject enemyBossPrefab;

    //public Animation enemyFormationParentAnimationStart;

    // Start is called before the first frame update
    void Start()
    {
        //enemyFormationParentAnimationStart = GetComponent<Animation>();

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
            // THIS IS WHERE I should put the set animation to entry code. Get the game object component or whatever in start and then do the shit here.
            //enemyFormationParentAnimationStart.Play("Entry");
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

    void Reset()    //Reset Enemies Maybe I should call it reset enemies?
    {
        print("Reset Enemies");
        Start();    // This is too fast. It should be delayed by 2 or 3 seconds with a coroutine. OR have a if button pressed then call Start().
                    // Using a button press to continue, would give them the chance to quit the game or go for a piss or something.
    }

}
