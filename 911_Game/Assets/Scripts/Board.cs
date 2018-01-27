using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour {

    // variables for the board class
    public float initialX;
    public float initialY;
    public float xScale;
    public float yScale;
    public int xLength;
    public int yLength;
    public Sprite jack;
    
    protected GameObject[,] board;
    protected bool[,] boolBoard;

    // Use this for initialization
    public void Start ()
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
    public void fillBoardSpaces(GameObject call)
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
    public void emptyBoardSpaces(GameObject call)
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

    public bool checkEmpty(GameObject call)
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

    public Vector2 GetClosestIndex(Vector2 mousePosition)
    {
        Vector2 closest = new Vector2();
        if (!(mousePosition.x < transform.position.x - xScale) && !(mousePosition.x < transform.position.x + (xScale * (xLength + 1))) && !(mousePosition.y < transform.position.y - yScale) && !(mousePosition.y < transform.position.y + (yScale * (yLength + 1))))
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
        else
        {
            closest = new Vector2(1000000, 1000000);
        }
        return closest;
    }


}
