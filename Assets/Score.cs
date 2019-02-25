using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private float score = 0.0f;

    public Text scoreText;
	
	// Update is called once per frame
	void Update ()
    {
        score += Time.deltaTime * 5;
        scoreText.text = ((int)score).ToString(); 
	}

}
