using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormationParent : MonoBehaviour
{
    public Animation enemyFormationParentAnimationStart;
    public Vector3 startPosition;
    private Animator animator;
    //private GameController gameController;

    void Awake()
    {
        startPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        //gameController = FindObjectOfType<GameController>();
        animator = gameObject.GetComponent<Animator>();
        enemyFormationParentAnimationStart = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if the children set active false { set animation state to entry } Wait no! That will not work. It needs to do that if start is called.
        // maybe in game controller it says if there are enemies SetActive true then {return} else { set animation state to entry }

        //print("Formation update script");

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            print("WORK");
            // The tranform that needs to be rest is the enemy formation not the children.
            transform.position = startPosition;
            //animator.SetTrigger("Enemies are all dead");
            //enemyFormationParentAnimationStart.Play("Enemy Formation Parent Move Right 1st");       // Not working! They are just continuing the previous animation state.
            print("Enemies are all dead trigger");
        }

    }

    public void IdleAnimation()
    {
        gameObject.GetComponent<Animator>().Play("Idle");
    }

}
