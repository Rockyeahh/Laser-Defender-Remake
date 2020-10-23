using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public bool safeToShoot = true;

    // update safe to shoot? How do I make it update itself to safe to shoot true? It needs to be checking if it is being collided or not.
    // Maybe that get and set thing will work.

        // Update() { if it ain't triggering then it's true. }

    void OnTriggerEnter2D(Collider2D collider)  // Does is Trigger need to be ticked in the Enemy Checker inspector.
    {
        safeToShoot = false;
    }

}
