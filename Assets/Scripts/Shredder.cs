using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Projectile")
        {
        Destroy(col.gameObject);
        }

        if (col.tag == "Player Projectile")
        {
            Destroy(col.gameObject);
        }

    }
}
