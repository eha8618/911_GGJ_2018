using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public Board board;
    public Board incomingCallBoard;
    public int lives;
    public Text text;
    public GameObject[] easyCalls;
    public GameObject[] moderateCalls;
    public GameObject[] hardCalls;

    private int score;
    private GameObject currentCall;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        lives = 3;
        currentCall = null;
        //GameObject tempCall = GenerateRandomCall(1);
        //incomingCallBoard.FillBoardSpaces(tempCall, new Vector2(Random.Range(0, 2), Random.Range(0, 12)));
        //CallScript call = tempCall.GetComponent<CallScript>();
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
            if (currentCall == null)
            {
                Vector2 boardLoc = incomingCallBoard.GetClosestIndex(Input.mousePosition);
                //if (boardLoc.x != 1000000 && boardLoc.y != 1000000)
                //{
                //    CallScript call = incomingCallBoard.GetShape(boardLoc).GetComponent<CallScript>();
                //    call.Selected = true;
                //}
                // Figure out which jack is closest to mouse cursor
                // Change currentCall's value if the return is valid
                //Vector2 boardIndex = incomingCallBoard.GetClosestIndex(Input.mousePosition);
                //currentCall = incomingCallBoard.GetShape(boardIndex);

            }

            else if (currentCall != null)
            {
                CallScript call = currentCall.GetComponent<CallScript>();
                Vector2 boardLoc = board.GetClosestIndex(Input.mousePosition);
                if (board.CheckEmpty(currentCall, boardLoc))
                {
                    board.FillBoardSpaces(currentCall, boardLoc);
                    call.Selected = false;
                }
                currentCall = null;
            }
            // Place currentCall's shape in board if valid
            //else if (currentCall != null && board.checkEmpty(currentCall, incomingCallBoard.GetClosestIndex(Input.mousePosition)))
            //{
            //    // Placing currentCall's Shape in Board
            //    board.fillBoardSpaces(currentCall, board.GetClosestIndex(Input.mousePosition));

            //    // set current call to null so that we can assign the next generated call
            //    currentCall = null;
            //}
        }

        if (currentCall != null)
        {
        }

        // Handle level difficulty
        //GenerateRandomCall(2);
    }

    // Changes the score by the given amount
    public void ChangeScore(int change)
    {
        score += change;
    }

    // Returns a random shape based on given difficulty
    GameObject GenerateRandomCall(int difficulty)
    {
        GameObject nextCall;
        GameObject callToReturn;

        switch (difficulty)
        {
            case 1:
                nextCall = easyCalls[Random.Range(0, easyCalls.Length - 1)];
                callToReturn = Instantiate(nextCall);
                return callToReturn;
            case 2:
                nextCall = moderateCalls[Random.Range(0, moderateCalls.Length - 1)];
                callToReturn = Instantiate(nextCall);
                return callToReturn;
            case 3:
                nextCall = hardCalls[Random.Range(0, hardCalls.Length - 1)];
                callToReturn = Instantiate(nextCall);
                return callToReturn;
        }

        return null;
    }
}
