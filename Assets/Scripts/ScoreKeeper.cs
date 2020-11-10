using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    private Text scoreKeeperText;

    void Start()
    {
        scoreKeeperText = GetComponent<Text>();
        Reset();
    }

    public void Score(int points)
    {
        score += points;
        scoreKeeperText.text = score.ToString();
    }

    public static void Reset()
    {
        score = 0;
    }
}
