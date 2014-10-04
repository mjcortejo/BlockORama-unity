using UnityEngine;
using System.Collections;

public class RestartScript : GameBehavior
{
    public GUIText finalScore;
	// Use this for initialization
	void Start () 
    {
        finalScore.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("MainScene");
        }
	}
}
