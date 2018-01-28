using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    // variables for the board class

    // this is the gameobject that will be the building block of the board (phoneJack for now)
    public GameObject boardPiece;

    public int xLength;
    public int yLength;
    
    protected GameObject[,] board;


    // Use this for initialization
    void Start ()
    {
        // reset board to be blank when spawned
		board = new GameObject[xLength, yLength];

        for (int i = 0; i < xLength; i++)
        {
            for (int j = 0; j < yLength; j++)
            {
                board[i, j] = (GameObject)Instantiate(boardPiece, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}






    //protected Vector2 closest;

    //public Vector2 Closest
    //{
    //    get { return closest; }
    //    set { closest = value; }
    //}

    //closest = new Vector2(1000000, 1000000);
    //for (int i = 0; i < jacks.Length; i++)
    //{
    //    jacks[i].gameObject.transform.position = new Vector3(transform.position.x + (jacks[i].index.x * xJackScale), transform.position.y + (jacks[i].index.y * yJackScale));
    //}
    // function to be called when board spaces are trying to be taken by a call piece
    // need to change the gameobject to an actual call object
    //public void FillBoardSpaces(GameObject call, Vector2 start)
    //{
    //    // Get the shape from the call object
    //    CallScript script = call.GetComponent<CallScript>();
    //    GameObject centerBlock = script.centerBlock;
    //    board[(int)(start.x), (int)(start.y)] = call;

    //    // Snap centerBlock to position

    //    board[(int)start.x, (int)start.y] = centerBlock;
    //    int listIndex = (((int)(start.y)) * 2) + (int)(start.x);
    //    PhoneJack jack = jacks[listIndex].GetComponent<PhoneJack>();
    //    centerBlock.transform.position = new Vector3(jack.transform.position.x, jack.transform.position.y, 0);

    //    for (int i = 0; i < script.points.Length; i++)
    //    {
    //        int x = (int)(centerBlock.transform.position.x + script.points[i].x);
    //        Debug.Log(x);
    //        int y = (int)(centerBlock.transform.position.y + script.points[i].y);
    //        Debug.Log(y);
    //        board[x, y] = script.blocks[i];
    //        boolBoard[x, y] = true;
    //    }
    //}

    //// function to be called when a call is finished and piece is removed
    //public void EmptyBoardSpaces(GameObject call)
    //{
    //    int indexI = -1;
    //    int indexJ = -1;
    //    for (int i = 0; i < callBoard.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < callBoard.GetLength(1); j++)
    //        {
    //            if (callBoard[i, j] == call)
    //            {
    //                indexI = i;
    //                indexJ = j;
    //            }
    //        }
    //    }
    //    if (indexI == -1 || indexJ == -1)
    //    {
    //        return;
    //    }

    //    CallScript script = call.GetComponent<CallScript>();
    //    GameObject centerBlock = script.centerBlock;
    //    callBoard[indexI, indexJ] = null;

    //    for (int i = 0; i < script.points.Length; i++)
    //    {
    //        int x = (int)(centerBlock.transform.position.x + script.points[i].x);
    //        int y = (int)(centerBlock.transform.position.y + script.points[i].y);
    //        board[x, y] = null;
    //        boolBoard[x, y] = false;
    //    }
    //}

    //public bool CheckEmpty(GameObject call, Vector2 start)
    //{
    //    // Get the shape from the call object
    //    CallScript script = call.GetComponent<CallScript>();
    //    GameObject centerBlock = script.centerBlock;
    //    centerBlock.transform.position = new Vector3(start.x, start.y, 0);

    //    for (int i = 0; i < script.points.Length; i++)
    //    {
    //        int x = (int)(centerBlock.transform.position.x + script.points[i].x);
    //        int y = (int)(centerBlock.transform.position.y + script.points[i].y);
    //        if (boolBoard[x, y])
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    //public Vector2 GetClosestIndex(Vector2 mousePosition)
    //{
    //    closest = new Vector2(1000000, 1000000);

    //    foreach (PhoneJack jack in jacks)
    //    {
    //        jack.check2DObjectClicked(mousePosition);
    //    }

    //    return closest;
    //}

    //public GameObject GetShape(Vector2 index)
    //{
    //    return callBoard[(int)index.x, (int)index.y];
    //}


}
