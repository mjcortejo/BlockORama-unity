using UnityEngine;
using System.Collections;

public class FallingBlocksScript : GameBehavior
{
	// Use this for initialization
	void Start () 
    {
        rigidbody2D.fixedAngle = true;
	}
	// Update is called once per frame
    void Update() 
    {
        rigidbody2D.velocity = new Vector2(0, -fallingSpeed);
        ChangeSpeed();
	}
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }   
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
    void ChangeSpeed()
    {
        ctrInterval++;
        if (ctrInterval >= 500)
        {
            fallingSpeed += 1.50f;
            ctrInterval = 0;
        }
    }
}
    