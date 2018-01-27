using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    // variables for the board class
    protected GameObject[,] board;

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
        // need to get the shape from the call object


        // temp names for stub loop to flip bools for each space(block) in the board
        //foreach(Vector2 piece in shape.pieces)
        //{
        //    board[(int)space[0], (int)space[1]].filled = true;
        //}
    }

    // function to be called when a call is finished and piece is removed
    void emptyBoardSpaces(GameObject call)
    {
        // need to get the shape from the call object


        // temp names for stub loop to flip bools for each space(block) in the board
        //foreach(Vector2 piece in shape.pieces)
        //{
        //    board[(int)space[0], (int)space[1]].filled = true;
        //}
    }
}
