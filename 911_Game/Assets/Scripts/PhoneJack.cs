using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneJack : MonoBehaviour {

    public Board myBoard;
    public Vector2 index;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void check2DObjectClicked(Vector2 mousePosition)
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(mousePosition).x, Camera.main.ScreenToWorldPoint(mousePosition).y), new Vector2(0, 0), 0);

        if (hitInfo)
        {
            Debug.Log(index);
            myBoard.Closest = index;
        }
    }
}
