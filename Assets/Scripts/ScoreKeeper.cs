using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    private Text myText;

    void Start()
    {
        myText = GetComponent<Text>();
        Reset();
    }

    public void Score(int points)
    {
        score += points;//adds to what it currently equals or simply increased by.
        myText.text = score.ToString(); //it finds the text that this script is attached to and it does something with ToString.
    }

    public static void Reset()
    {
        score = 0;
    }
	
}
