using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormationParent : MonoBehaviour
{
    public Vector3 startPosition;
    private Animator animator;

    private Animation enemyFormationParentAnimationStart;
    private LevelNumberScript levelNumberScript;

    void Awake()
    {
        startPosition = transform.position;
    }

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        enemyFormationParentAnimationStart = GetComponent<Animation>();
        levelNumberScript = GameObject.Find("Level Number").GetComponent<LevelNumberScript>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            transform.position = startPosition;
            print("Enemies are all dead trigger");
        }

    }

    public void IdleAnimation()
    {
        gameObject.GetComponent<Animator>().Play("Idle");
    }

}
