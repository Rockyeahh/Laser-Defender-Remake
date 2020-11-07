using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormationParent : MonoBehaviour
{
    public Animation enemyFormationParentAnimationStart;
    public Vector3 startPosition;
    private Animator animator;

    void Awake()
    {
        startPosition = transform.position;
    }

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        enemyFormationParentAnimationStart = GetComponent<Animation>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            //print("WORK");
            transform.position = startPosition;
            print("Enemies are all dead trigger");
        }

    }

    public void IdleAnimation()
    {
        gameObject.GetComponent<Animator>().Play("Idle");
    }

}
