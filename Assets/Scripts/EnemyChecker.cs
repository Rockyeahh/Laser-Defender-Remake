using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public bool safeToShoot = true;

    // update safe to shoot? How do I make it update itself to safe to shoot true? It needs to be checking if it is being collided or not.
    // Maybe that get and set thing will work.

        // Update() { if it ain't triggering then it's true. }
        // if enemyCheckerCollisionHappened { safeToShoot = false; else fafeToShoot = true; }

    void OnTriggerEnter2D(Collider2D collider)  // Does is Trigger need to be ticked in the Enemy Checker inspector.
    {
        print("Safe to shoot = false");
        safeToShoot = false;    // Safe to shoot = false is only being called when the players laser reaches the box 
                                // but then it kills the enemy before it can start shooting.
                                // I need something that constantly checks if it is there colliding, not just checks if it has entered or exited.
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        safeToShoot = true;
    }

}
