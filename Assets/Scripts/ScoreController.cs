using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text scoreText;
    public int score = 0;
	// Use this for initialization
	void Start () {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void increaseScore(int i)
    {
        score += i;
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

    }
}
