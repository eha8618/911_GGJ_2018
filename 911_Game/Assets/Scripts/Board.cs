using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    // variables for the board class

    // this is the gameobject that will be the building block of the board (phoneJack for now)
    public GameObject boardPiece;

    public int xLength;
    public int yLength;
    // The x distance between each block
    public float xScale;
    // The y distance between each block
    public float yScale;
    
    // 2D array for jacks
    protected GameObject[,] board;
    // 2D array for call blocks
    protected GameObject[,] callBoard;

    public GameObject[,] CallBoard
    {
        get { return callBoard; }
        set { callBoard = value; }
    }


    // Use this for initialization
    void Start ()
    {
        // reset board to be blank when spawned
		board = new GameObject[xLength, yLength];

        for (int i = 0; i < xLength; i++)
        {
            for (int j = 0; j < yLength; j++)
            {
                board[i, j] = Instantiate(boardPiece, new Vector3(transform.position.x + (i * xScale), transform.position.y + (j * yScale), 0), Quaternion.identity);
                board[i, j].GetComponent<JackScript>().BoardLocation = new Vector2(i, j);
            }
        }

        callBoard = new GameObject[xLength, yLength];
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Returns a Vector3 based on the board position (Vector2) parameter
    public Vector3 BoardPositionToWorldPosition(Vector2 boardPosition)
    {
        return new Vector3(transform.position.x + (boardPosition.x * xScale), transform.position.y + (boardPosition.y * yScale), 0);
    }

    // Returns a Call Object based on the given Vector2 and removes it from the board
    public GameObject GetCall(Vector2 boardLoc)
    {
        GameObject call = null;
        if ((int)boardLoc.x >= 0 && (int)boardLoc.x < xLength && (int)boardLoc.y >= 0 && (int)boardLoc.y < yLength)
        {
            call = callBoard[(int)boardLoc.x, (int)boardLoc.y];
        }
        return call;
    }

    // Checks to see if there is at least one empty space in the board
    public bool HasEmpty()
    {
        for (int i = 0; i < callBoard.GetLength(0); i++)
        {
            for (int j = 0; j < callBoard.GetLength(1); j++)
            {
                if (callBoard[i, j] == null)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool Fits(GameObject call, Vector2 start)
    {
        int x = (int)start.x;
        int y = (int)start.y;
        if (callBoard[x, y] != null)
        {
            return false;
        }

        for (int i = 0; i < call.GetComponent<CallScript>().blocks.Length; i++)
        {
            if (callBoard[x + (int)call.GetComponent<CallScript>().points[i].x, y + (int)call.GetComponent<CallScript>().points[i].y] != null)
            {
                return false;
            }
        }

        return true;
    }

}
