using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //public Board board;
    public int lives;
    public Text text;
    public GameObject callPrefab;
    public GameObject[] easyShapes;
    public GameObject[] moderateShapes;
    public GameObject[] hardShapes;

    private int score;
    private GameObject currentCall;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        lives = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // UI Handling
        text.text = "Lives: " + lives + "\n" + "Score: " + score;

        // Act on Left-Click Input
        if (Input.GetMouseButtonDown(0))
        {
            // Get a call object set to currentCall
            if (currentCall != null)
            {
                // Figure out which jack is closest to mouse cursor
                // Change currentCall's value if the return is valid
            }
            // Place currentCall's shape in board if valid
            //else if ()
            //{
            //    // Placing currentCall's Shape in Board
            //    currentCall.GetComponent<CallScript>().
            //    currentCall = null;
            //}
        }

        if (currentCall != null)
        {
            currentCall.transform.position = Input.mousePosition;
        }

        // Handle level difficulty
	}

    // Changes the score by the given amount
    public void ChangeScore(int change)
    {
        score += change;
    }

    // Returns a random shape based on given difficulty
    GameObject GenerateRandomShape(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                return easyShapes[Random.Range(0, easyShapes.Length - 1)];
            case 2:
                return moderateShapes[Random.Range(0, easyShapes.Length - 1)];
            case 3:
                return hardShapes[Random.Range(0, easyShapes.Length - 1)];
        }
        return null;
    }

    // Generates a random call based on given difficulty
    void GenerateRandomCall(int difficulty)
    {
        GameObject nextCall = Instantiate(callPrefab);
        CallScript nextCallScript = nextCall.GetComponent<CallScript>();
        nextCallScript.Shape = GenerateRandomShape(difficulty);
    }
}
