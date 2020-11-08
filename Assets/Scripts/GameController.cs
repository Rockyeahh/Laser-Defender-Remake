using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] enemies;
    //public GameObject enemyBossPrefab;
    public Text levelNumberText;
    public static int levelNumber = 1;

    private EnemyFormationParent enemyFormationParent;

    //public Animation enemyFormationParentAnimationStart;

    // Start is called before the first frame update
    void Start()
    {
        enemyFormationParent = FindObjectOfType<EnemyFormationParent>();
        GameObject levelNumberGameObject = GameObject.FindWithTag("Level Number");
        levelNumberText = levelNumberGameObject.GetComponent<Text>();
        //levelNumberText = gameObject.GetComponent<Text>();  // using gameObject didn't help.
        //enemyFormationParentAnimationStart = GetComponent<Animation>();

        //Start the coroutine we define below named ExampleCoroutine.
        //  StartCoroutine(ExampleCoroutine());

        //Invoke("Reset", 200f);

    }

  //  IEnumerator ExampleCoroutine()
  //  {
        //Print the time of when the function is first called.
  //      Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
  //      yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
    //    Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    //    print("Reset");
     //   Reset();
   // }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print("level " + levelNumber);
        levelNumberText.text = levelNumber.ToString();
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            // THIS IS WHERE I should put the set animation to entry code. Get the game object component or whatever in start and then do the shit here.
            //enemyFormationParentAnimationStart.Play("Entry");

            Invoke("Reset", 2f);
            //levelNumber++;
            //levelNumberText.text = levelNumber.ToString();
            //Reset();
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
        enemyFormationParent.IdleAnimation();
        levelNumber += 1;
        //levelNumberText.text = levelNumber.ToString();

        // Enable Enemy gameObjects/children. // Game objects tagged as Enemy set disable
        if (enemies == null)
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject Enemy in enemies)
        {
            //print("work you cunt");
            Enemy.SetActive(true);
            print("Set enemy active");
        }

        //Start();                   // This is too fast. It should be delayed by 2 or 3 seconds with a coroutine. OR have a if button pressed then call Start().
                                  // Using a button press to continue, would give them the chance to quit the game or go for a piss or something.
       //Invoke("Start", 2.0f);
    }

}
