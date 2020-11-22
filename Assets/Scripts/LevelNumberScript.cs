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
        levelNumberCoroutine = UpdateLevel(2);
        StartCoroutine(levelNumberCoroutine);

    }

    private IEnumerator UpdateLevel(int updateLevel)
    {
        while (true)
        {
            yield return new WaitForSeconds(updateLevel);
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
