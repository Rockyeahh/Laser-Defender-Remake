using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text myText = GetComponent<Text>(); // Text is tell Unity we are usin that part of the engine. myText is to grb the text this is attached to. Get component grabs the text component.
        myText.text = ScoreKeeper.score.ToString(); // mytext.text is the text object.component = ScoreKeeper tells it to fill that text component with a tostring or words/numbers of the score.
        ScoreKeeper.Reset(); // This resets the scorekeeper script after the score text has been taken outand put here. This makes sure the score doesn't carry over to the next level or when you retry the same level.
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
