using UnityEngine;
using System.Collections;

public class ControllerScript : GameBehavior
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block;
    public Transform[] spawners;
    public Transform[] spawnersLeft;
    public Transform[] spawnersRight;
    public int score;
    public double spawnInterval;
    public int moveSpeed;
        
	// Use this for initialization
	void Start () 
    {
        fallingSpeed = 5.0f;
        ctrInterval = 0;
        intervalLevel = 0;
        block1.transform.position = new Vector2(spawnersLeft[2].position.x, this.transform.position.y);
        block2.transform.position = new Vector2(spawnersRight[2].position.x, this.transform.position.y);
	}
	
	// Update is called once per frame
    void Update() 
    {
        PlayerControls();
        IntervalSpawn();
        UpdateLevelText();
	}
    #region Players related codes
    void PlayerControls()
    {
        Block1Controller();
        Block2Controller();
    }
    void MenuControls()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0.0f;
        }
    }
    //Updated Controls
    void Block1Controls()
    {

    }
    void Block1Controller()
    {
        block1.rigidbody2D.velocity = new Vector2(GetVelocityForBlock1(), 0);
    }
    void Block2Controller()
    {
        block2.rigidbody2D.velocity = new Vector2(GetVelocityForBlock2(), 0);
    }
    int GetVelocityForBlock1()
    {
        int v = 0;
        if (Input.GetKey(KeyCode.A))
        {
            v = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            v = moveSpeed;
        }
        return v;
    }
    int GetVelocityForBlock2()
    {
        int v = 0;
        if (Input.GetKey(KeyCode.J))
        {
            v = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            v = moveSpeed;
        }
        return v;
    }
    #endregion
    void SpawnBlocks()
    {
        int prefabIndex = Random.Range(0, spawners.Length);
        Instantiate(block, spawners[prefabIndex].position, spawners[prefabIndex].rotation);
    }
    int x = 0;
    int ctr = 0;
    int synCtr = 0;
    void IntervalSpawn()
    {
        x++;
        ctr++;
        synCtr++;
        if (x >= spawnInterval)
        {
            SpawnBlocks();
            x = 0;
        }
        if (ctr >= 100)
        {
            ChangeInterval();
            ctr = 0;
        }
    }
    void ChangeInterval()
    {
        spawnInterval /= 1.01;
        intervalLevel++;
        Debug.Log(spawnInterval);
    }
    void UpdateLevelText()
    {
        guiLevel.text = intervalLevel.ToString();
    }
}
