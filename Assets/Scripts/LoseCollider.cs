using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        print("Load a win screen");
        LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.LoadScene("Win Screen");
    }
}
