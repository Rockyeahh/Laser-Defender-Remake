using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartScript : MonoBehaviour
{

    Animation levelTextAnimation;

    void Start()
    {
        levelTextAnimation = gameObject.GetComponent<Animation>();
    }

    public void LevelStartTextFade()
    {
        levelTextAnimation.GetComponent<Animation>().Play("Level Start Text Fade");
    }

}
