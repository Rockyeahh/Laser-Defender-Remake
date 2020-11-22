using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public bool safeToShoot = false;

   // void FixedUpdate()
    //{
        // Cast a ray straight down.
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        // Check for a Enemy.
        //LayerMask enemyMask = LayerMask.GetMask("Enemy");

        //print("Raycast start");
        //Debug.DrawRay(transform.position, -Vector2.up, Color.green);

        //if (hit.collider.tag == ("Enemy"))   // This isn't doing anything?
        //if (hit.collider != null)              // Using this instead causes FUCK to be printed but nothing further than that occurs.
        //{
        //print("FUCK");
        //safeToShoot = false;
        //print(safeToShoot);             // This is saying that it's false. Maybe it isn't being updated on the game objects?
        // Do I need to say game object bla bla is now safe to shoot = false or what? Fuckkkkkkkkkkkkk

        //Hit something, print the tag of the object
        //Debug.Log("Hitting: " + hit.collider.tag);
        //Debug.Log("Hitting: " + hit.collider.gameObject.name);

            // Check if a Enemy is hit.
            //   if (Physics.Raycast(transform.position, -Vector2.up, 20.0f, enemyMask))
            // {
            //      Debug.Log("Fired and hit a enemy.");
            //  }
        //} else
        //{
        //    safeToShoot = true;
        //}

    //}

     //   if (hit.collider.tag == ("Enemy"))
     //   {
     //       safeToShoot = false;
     //       print("not safe to shoot = " + safeToShoot);
      //  }

        //else if (!hit.collider)             // This doesn't get called at all.
        //{
        //    safeToShoot = true;
        //    print("safe to shoot = " + safeToShoot);
        //}
   // }


    // update safe to shoot? How do I make it update itself to safe to shoot true? It needs to be checking if it is being collided or not.
    // Maybe that get and set thing will work.

    // Update() { if it ain't triggering then it's true. }
    // if enemyCheckerCollisionHappened { safeToShoot = false; else fafeToShoot = true; }

    // ALL THE Enemy Weak are currently not set to is Trigger.
      void OnTriggerEnter2D(Collider2D collider)  // Does is Trigger need to be ticked in the Enemy Checker inspector.
      {
          print("Safe to shoot = false");
          safeToShoot = false;    // Safe to shoot = false is only being called when the players laser reaches the box 
    // but then it kills the enemy before it can start shooting.
    // I need something that constantly checks if it is there colliding, not just checks if it has entered or exited.
      }

   // void OnCollisionStay(Collision collisionInfo)
   // {
   //     safeToShoot = false;
   //     print("NOT SAFE TO SHOOT");
   // }

     // void OnTriggerStay(Collider other)
     // {
     //     safeToShoot = false;
     //   print("PLEASE WORK");
      //}

    //void OnTriggerExit2D(Collider2D collider)
    //{
    //    safeToShoot = true;
    //}

}
