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
        check2DObjectClicked();
	}

    void check2DObjectClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), new Vector2(0, 0), 0);

            if (hitInfo)
            {
                Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else
            {
                Debug.Log("Failed");
            }
        }
    }
}
