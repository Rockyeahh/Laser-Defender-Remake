using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Vector3 startPosition;

    public GameObject[] enemies;

    private EnemyFormationParent enemyFormationParent;

    void Awake()
    {
        startPosition = transform.position;
    }

    void Start()
    {
        enemyFormationParent = FindObjectOfType<EnemyFormationParent>();
        GameObject levelNumberGameObject = GameObject.FindWithTag("Level Number");
    }

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Invoke("Reset", 2f);
        }
    }

    void Reset()    //Reset Enemies Maybe I should call it reset enemies?
    {
        print("Enemies are all dead trigger");
        print("Reset Enemies");
        enemyFormationParent.EntranceAnimation();
        //transform.position = startPosition;       // currently having this commented out makes no difference to the game.

        // Enable Enemy gameObjects/children. // Game objects tagged as Enemy set disable
        if (enemies == null)
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject Enemy in enemies)
        {
            Enemy.SetActive(true);
        }
    }
}
