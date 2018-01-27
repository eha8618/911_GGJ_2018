using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour {

    // variables for the board class
    protected GameObject[,] board;
    protected bool[,] boolBoard;

    // Use this for initialization
    void Start ()
    {
        // reset board to be blank when spawned
		board = new GameObject[12, 12];
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // function to be called when board spaces are trying to be taken by a call piece
    // need to change the gameobject to an actual call object
    void fillBoardSpaces(GameObject call)
    {
        // Get the shape from the call object
        ShapeScript shape = call.GetComponent<CallScript>().Shape.GetComponent<ShapeScript>();
        GameObject centerBlock = shape.centerBlock;
        
        for (int i = 0; i < shape.points.Length; i++)
        {
            int x = (int)(centerBlock.transform.position.x + shape.points[i].x);
            int y = (int)(centerBlock.transform.position.y + shape.points[i].y);
            board[x, y] = shape.blocks[i];
            boolBoard[x, y] = true;
        }
    }

    // function to be called when a call is finished and piece is removed
    void emptyBoardSpaces(GameObject call)
    {
        // Get the shape from the call object
        ShapeScript shape = call.GetComponent<CallScript>().Shape.GetComponent<ShapeScript>();
        GameObject centerBlock = shape.centerBlock;
        
        for (int i = 0; i < shape.points.Length; i++)
        {
            int x = (int)(centerBlock.transform.position.x + shape.points[i].x);
            int y = (int)(centerBlock.transform.position.y + shape.points[i].y);
            board[x, y] = null;
            boolBoard[x, y] = false;
        }
    }

    bool checkEmpty(GameObject call)
    {
        // Get the shape from the call object
        ShapeScript shape = call.GetComponent<CallScript>().Shape.GetComponent<ShapeScript>();
        GameObject centerBlock = shape.centerBlock;

        for (int i = 0; i < shape.points.Length; i++)
        {
            int x = (int)(centerBlock.transform.position.x + shape.points[i].x);
            int y = (int)(centerBlock.transform.position.y + shape.points[i].y);
            if (boolBoard[x, y])
            {
                return false;
            }
        }
        return true;
    }


}
