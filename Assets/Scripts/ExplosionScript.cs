using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }

    public void LoadEndScreen()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadScene("End Screen");
    }

}
