using UnityEngine;
using System.Collections;

public class BottomColliderManager : GameBehavior
{
	// Use this for initialization
	void Start () 
    {
	
	}
	// Update is called once per frame
    void Update() 
    {
        score = int.Parse(guiScore.text.ToString());
        guiScore.text = score.ToString();
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Spawner(Clone)")
        {
            score++;
            guiScore.text = score.ToString();
        }
    }
    void PlaySounds(Collision2D col)
    {
    }
}
