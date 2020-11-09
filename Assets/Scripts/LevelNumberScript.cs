using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberScript : MonoBehaviour
{
    public static int levelNumbers = 1;
    private Text myText;
    private IEnumerator coroutine;

    void Start()
    {
        myText = GetComponent<Text>();
        //Reset();

        // put corotutine here
        print("Starting " + Time.time);

        // Start function WaitAndPrint as a coroutine.

        coroutine = UpdateLevel(2);
        StartCoroutine(coroutine);

        print("Before WaitAndPrint Finishes " + Time.time);

    }

    // every 2 seconds perform the print()
    private IEnumerator UpdateLevel(int updateLevel)
    {
        while (true)
        {
            yield return new WaitForSeconds(updateLevel);
            print("WaitAndPrint " + Time.time);
            // if blerg enemies.length == 0 or null { levelNumbers += level; }
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                LevelNumberInt(1);
                //myText.text = levelNumbers.ToString();
            }
            //myText.text = levelNumbers.ToString();
        }
    }

    void Update()
    {
        
    }

    public void LevelNumberInt(int level)
    {
        levelNumbers += level;
        myText.text = levelNumbers.ToString();
    }

    //  public static void Reset()
    //{
    //     levelNumbers = 0;
    // }
}
