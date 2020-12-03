using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFormationParent : MonoBehaviour
{
    public Vector3 startPosition;
    public bool okToShoot = false;

    private Animator animator;
    private Animation enemyFormationParentAnimationStart;
    private LevelNumberScript levelNumberScript;
    private LevelStartScript levelStartScript;

    void Awake()
    {
        startPosition = transform.position; // currently pointless
    }

    void Start()
    {
        levelStartScript = GameObject.Find("Level Start").GetComponent<LevelStartScript>();
        animator = gameObject.GetComponent<Animator>();
        enemyFormationParentAnimationStart = GetComponent<Animation>();
    }

    public void EntranceAnimation()
    {
        animator.GetComponent<Animator>().Play("Enemy Entrance");
    }

    public void LevelStartAnimation()
    {
        levelStartScript.LevelStartTextFade();
    }

    public void EnemyNotOkToShoot()
    {
        okToShoot = false;
        print("Not ok to shoot");
    }

    public void EnemyOkToShoot()
    {
        okToShoot = true;
        print("OK to shoot");
        print("The player can start moving and shooting now.");
    }

}
