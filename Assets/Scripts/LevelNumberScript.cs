using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberScript : MonoBehaviour
{
    public static int levelNumbers = 1;
    private Text levelNumberText;
    private IEnumerator levelNumberCoroutine;

    void Start()
    {
        levelNumberText = GetComponent<Text>();

        //print("Starting " + Time.time);

        levelNumberCoroutine = UpdateLevel(2);
        StartCoroutine(levelNumberCoroutine);

        //print("Before WaitAndPrint Finishes " + Time.time);

    }

    private IEnumerator UpdateLevel(int updateLevel)
    {
        while (true)
        {
            yield return new WaitForSeconds(updateLevel);
            //print("WaitAndPrint " + Time.time);
            // if blerg enemies.length == 0 or null { levelNumbers += level; }
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                LevelNumberInt(1);
            }
        }
    }

    public void LevelNumberInt(int level)
    {
        levelNumbers += level;
        levelNumberText.text = levelNumbers.ToString();
    }
}
