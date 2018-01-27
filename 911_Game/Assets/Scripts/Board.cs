using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    // variables for the board class
    public string message;
    public Camera mainCam;
    public float initialX;
    public float initialY;
    public float xScale;
    public float yScale;
    public int xLength;
    public int yLength;
    
    protected GameObject[,] board;
    protected GameObject[,] callBoard;
    protected bool[,] boolBoard;

    // Use this for initialization
    void Start ()
    {
        // reset board to be blank when spawned
		board = new GameObject[xLength, yLength];
        //for (int i = 0; i < xLength; i++)
        //{
        //    for (int j = 0; j < yLength; j++)
        //    {
                
        //    }
        //}
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // function to be called when board spaces are trying to be taken by a call piece
    // need to change the gameobject to an actual call object
    public void fillBoardSpaces(GameObject call, Vector2 start)
    {
        // Get the shape from the call object
        CallScript script = call.GetComponent<CallScript>();
        GameObject centerBlock = script.centerBlock;
        callBoard[(int)(centerBlock.transform.position.x), (int)(centerBlock.transform.position.y)] = call;

        for (int i = 0; i < script.points.Length; i++)
        {
            int x = (int)(centerBlock.transform.position.x + script.points[i].x);
            int y = (int)(centerBlock.transform.position.y + script.points[i].y);
            board[x, y] = script.blocks[i];
            boolBoard[x, y] = true;
        }
    }

    // function to be called when a call is finished and piece is removed
    public void emptyBoardSpaces(GameObject call)
    {
        // Get the shape from the call object
        CallScript script = call.GetComponent<CallScript>();
        GameObject centerBlock = script.centerBlock;
        callBoard[(int)(centerBlock.transform.position.x), (int)(centerBlock.transform.position.y)] = null;
        
        for (int i = 0; i < script.points.Length; i++)
        {
            int x = (int)(centerBlock.transform.position.x + script.points[i].x);
            int y = (int)(centerBlock.transform.position.y + script.points[i].y);
            board[x, y] = null;
            boolBoard[x, y] = false;
        }
    }

    public bool checkEmpty(GameObject call, Vector2 start)
    {
        // Get the shape from the call object
        CallScript script = call.GetComponent<CallScript>();
        GameObject centerBlock = script.centerBlock;
        centerBlock.transform.position = new Vector3(start.x, start.y, 0);

        for (int i = 0; i < script.points.Length; i++)
        {
            int x = (int)(centerBlock.transform.position.x + script.points[i].x);
            int y = (int)(centerBlock.transform.position.y + script.points[i].y);
            if (boolBoard[x, y])
            {
                return false;
            }
        }
        return true;
    }

    public Vector2 GetClosestIndex(Vector2 mousePosition)
    {
        mousePosition = mainCam.ScreenToWorldPoint(mousePosition);
        Vector2 closest = new Vector2();
        if (mousePosition.x + xScale < initialX || initialX + xScale < mousePosition.x || mousePosition.y + yScale < initialY || initialY + yScale < mousePosition.y)
        {
            closest = new Vector2(1000000, 1000000);
        }
        else
        {
            for (int i = 0; i < xLength; i++)
            {
                if (xScale * i <= mousePosition.x && mousePosition.x <= (xScale * (i + 1)))
                {
                    closest.x = i;
                }
            }
            for (int i = 0; i < yLength; i++)
            {
                if (yScale * i <= mousePosition.y && mousePosition.y <= (yScale * (i + 1)))
                {
                    closest.y = i;
                }
            }
        }
        //else
        //{
        //    closest = new Vector2(1000000, 1000000);
        //}
        return closest;
    }

    public GameObject GetShape(Vector2 index)
    {
        return callBoard[(int)index.x, (int)index.y];
    }


}
