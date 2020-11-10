using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] enemies;
    //public GameObject enemyBossPrefab;

    private EnemyFormationParent enemyFormationParent;


    void Start()
    {
        enemyFormationParent = FindObjectOfType<EnemyFormationParent>();
        GameObject levelNumberGameObject = GameObject.FindWithTag("Level Number");

        //Start the coroutine we define below named ExampleCoroutine.
       // StartCoroutine(CheckForEnemies());
    }

 //   IEnumerator CheckForEnemies()
 //  {
        //Print the time of when the function is first called.
      //  Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
       // yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
     //   Debug.Log("Finished Coroutine at timestamp : " + Time.time);
      //  if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    //    {
            //Invoke("Reset", 2f);
            //Reset();
     //   }
   // }

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Invoke("Reset", 2f);
        }
    }

    void Reset()    //Reset Enemies Maybe I should call it reset enemies?
    {
        print("Reset Enemies");
        enemyFormationParent.IdleAnimation();

        // Enable Enemy gameObjects/children. // Game objects tagged as Enemy set disable
        if (enemies == null)
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject Enemy in enemies)
        {
            Enemy.SetActive(true);
        }
    }
}
