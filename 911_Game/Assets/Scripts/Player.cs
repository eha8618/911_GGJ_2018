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
    public GameObject easyIncomingCall;
    public GameObject moderateIncomingCall;
    public GameObject hardIncomingCall;

    private int score;
    private GameObject currentCall;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        lives = 3;
        currentCall = null;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                switch (hit.collider.tag)
                {
                    case "Main":
                        if (currentCall != null)
                        {
                            Vector2 boardLoc = hit.collider.gameObject.GetComponent<JackScript>().BoardLocation;
                            currentCall.GetComponent<CallScript>().Selected = false;
                            PlaceCall(currentCall.GetComponent<CallScript>(), boardLoc);
                        }
                        //Debug.Log(hit.collider.tag);
                        //Debug.Log(hit.collider.gameObject.GetComponent<JackScript>().BoardLocation);
                        break;

                    case "Incoming":
                        // Get a call from the incoming board
                        if (currentCall == null)
                        {
                            incomingCallBoard.GetCall(hit.collider.gameObject.GetComponent<JackScript>().BoardLocation);
                            if (currentCall != null)
                            {
                                currentCall.GetComponent<CallScript>().Selected = true;
                            }
                        }
                        //Debug.Log(hit.collider.tag);
                        //Debug.Log(hit.collider.gameObject.GetComponent<JackScript>().BoardLocation);
                        break;
                }
            }
        }





        // UI Handling
        text.text = "Lives: " + lives + "\n" + "Score: " + score;

        //// Act on Left-Click Input
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // Get a call object set to currentCall
        //    if (currentCall == null)
        //    {
        //    }
        //}

        //if (currentCall != null)
        //{
        //}

        // Handle level difficulty
        
    }

    // Changes the score by the given amount
    public void ChangeScore(int change)
    {
        score += change;
    }

    // Returns a random shape based on given difficulty
    GameObject GenerateRandomCall(int difficulty)
    {
        GameObject callToReturn;

        switch (difficulty)
        {
            case 1:
                callToReturn = Instantiate(easyCalls[Random.Range(0, easyCalls.Length - 1)]);
                return callToReturn;
            case 2:
                callToReturn = Instantiate(moderateCalls[Random.Range(0, moderateCalls.Length - 1)]);
                return callToReturn;
            case 3:
                callToReturn = Instantiate(hardCalls[Random.Range(0, hardCalls.Length - 1)]);
                return callToReturn;
        }

        return null;
    }

    GameObject GenerateIncomingCall(int difficulty)
    {
        GameObject callToReturn;

        switch (difficulty)
        {
            case 1:
                callToReturn = Instantiate(easyIncomingCall);
                return callToReturn;
            case 2:
                callToReturn = Instantiate(moderateIncomingCall);
                return callToReturn;
            case 3:
                callToReturn = Instantiate(hardIncomingCall);
                return callToReturn;
        }

        return null;
    }

    void PopulateIncomingCall(int difficulty)
    {
        Vector2 incomingBoardLoc = new Vector2(Random.Range(0, incomingCallBoard.xLength), Random.Range(0, incomingCallBoard.yLength));
        while (incomingCallBoard.GetCall(incomingBoardLoc) == null)
        {
            incomingBoardLoc = new Vector2(Random.Range(0, incomingCallBoard.xLength), Random.Range(0, incomingCallBoard.yLength));
        }
        incomingCallBoard.CallBoard[(int)incomingBoardLoc.x, (int)incomingBoardLoc.y] = GenerateIncomingCall(difficulty);
    }

    // Puts the call in the board and changes the transform appropriately
    void PlaceCall(CallScript call, Vector2 start)
    {
        call.centerBlock.transform.position = board.BoardPositionToWorldPosition(start);
        for (int i = 0; i < call.blocks.Length; i++)
        {
            Debug.Log(start);
            Debug.Log(call.points[i]);
            Vector2 spot = start + call.points[i];
            Debug.Log(spot);
            board.CallBoard[(int)spot.x, (int)spot.y] = call.blocks[i];
            call.blocks[i].transform.position = board.BoardPositionToWorldPosition(spot);
        }
    }






    //Vector2 boardLoc = incomingCallBoard.GetClosestIndex(Input.mousePosition);
    //if (boardLoc.x != 1000000 && boardLoc.y != 1000000)
    //{
    //    CallScript call = incomingCallBoard.GetShape(boardLoc).GetComponent<CallScript>();
    //    call.Selected = true;
    //}
    // Figure out which jack is closest to mouse cursor
    // Change currentCall's value if the return is valid
    //Vector2 boardIndex = incomingCallBoard.GetClosestIndex(Input.mousePosition);
    //currentCall = incomingCallBoard.GetShape(boardIndex);

    //else if (currentCall != null)
    //{
    //    CallScript call = currentCall.GetComponent<CallScript>();
    //    Vector2 boardLoc = board.GetClosestIndex(Input.mousePosition);
    //    if (board.CheckEmpty(currentCall, boardLoc))
    //    {
    //        board.FillBoardSpaces(currentCall, boardLoc);
    //        call.Selected = false;
    //    }
    //    currentCall = null;
    //}
    // Place currentCall's shape in board if valid
    //else if (currentCall != null && board.checkEmpty(currentCall, incomingCallBoard.GetClosestIndex(Input.mousePosition)))
    //{
    //    // Placing currentCall's Shape in Board
    //    board.fillBoardSpaces(currentCall, board.GetClosestIndex(Input.mousePosition));

    //    // set current call to null so that we can assign the next generated call
    //    currentCall = null;
    //}
}
