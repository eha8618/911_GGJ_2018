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
    private float timeInterval;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        lives = 3;
        currentCall = null;
        //PopulateIncomingCall(1);
        timeInterval = 0f;
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
                        Vector2 boardLoc = hit.collider.gameObject.GetComponent<JackScript>().BoardLocation;
                        if (currentCall != null && board.Fits(currentCall, boardLoc))
                        {
                            currentCall.GetComponent<CallScript>().Selected = false;
                            PlaceCall(currentCall.GetComponent<CallScript>(), boardLoc);
                            currentCall = null;
                        }
                        break;

                    case "Incoming":

                        // Get a call from the incoming board
                        if (currentCall == null)
                        {
                            GameObject callJack = incomingCallBoard.GetCall(hit.collider.gameObject.GetComponent<JackScript>().BoardLocation);
                            if (callJack != null && callJack.GetComponent<IncomingScript>() != null)
                            {
                                float expireTime = callJack.GetComponent<IncomingScript>().ExpireTime;
                                currentCall = GenerateRandomCall(callJack.GetComponent<IncomingScript>().difficulty);
                                currentCall.GetComponent<CallScript>().CallExpireTimePassed = expireTime;
                                Destroy(callJack);
                            }
                            if (currentCall != null)
                            {
                                currentCall.GetComponent<CallScript>().Selected = true;
                            }
                        }
                        break;
                }
            }
        }





        // UI Handling
        text.text = "Lives: " + lives + "\n" + "Score: " + score;

        // Handle level difficulty
        timeInterval += Time.deltaTime;
        if (timeInterval > 2.55f)
        {
            timeInterval -= 2.55f;
            PopulateIncomingCall(Random.Range(1, 3));
        }
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
                AddInfo(callToReturn);
                return callToReturn;

            case 2:
                callToReturn = Instantiate(moderateCalls[Random.Range(0, moderateCalls.Length - 1)]);
                AddInfo(callToReturn);
                return callToReturn;

            case 3:
                callToReturn = Instantiate(hardCalls[Random.Range(0, hardCalls.Length - 1)]);
                AddInfo(callToReturn);
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

    void AddInfo(GameObject call)
    {
        call.GetComponent<CallScript>().player = this;
    }

    void PopulateIncomingCall(int difficulty)
    {
        Vector2 incomingBoardLoc = new Vector2(Random.Range(0, incomingCallBoard.xLength), Random.Range(0, incomingCallBoard.yLength));
        while (incomingCallBoard.HasEmpty() && incomingCallBoard.GetCall(incomingBoardLoc) != null)
        {
            incomingBoardLoc = new Vector2(Random.Range(0, incomingCallBoard.xLength), Random.Range(0, incomingCallBoard.yLength));
        }
        incomingCallBoard.CallBoard[(int)incomingBoardLoc.x, (int)incomingBoardLoc.y] = GenerateIncomingCall(difficulty);
        incomingCallBoard.CallBoard[(int)incomingBoardLoc.x, (int)incomingBoardLoc.y].transform.position = new Vector3(incomingCallBoard.transform.position.x + (incomingCallBoard.xScale * (int)incomingBoardLoc.x), incomingCallBoard.transform.position.y + (incomingCallBoard.yScale * (int)incomingBoardLoc.y), 0);
    }

    // Puts the call in the board and changes the transform appropriately
    void PlaceCall(CallScript call, Vector2 start)
    {
        call.centerBlock.transform.position = board.BoardPositionToWorldPosition(start);
        for (int i = 0; i < call.blocks.Length; i++)
        {
            Vector2 spot = start + call.points[i];
            board.CallBoard[(int)spot.x, (int)spot.y] = call.blocks[i];
            call.blocks[i].transform.position = board.BoardPositionToWorldPosition(spot);
        }
    }

}
