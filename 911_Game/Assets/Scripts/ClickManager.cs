using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
                        Debug.Log(hit.collider.tag);
                        Debug.Log(hit.collider.gameObject.GetComponent<JackScript>().BoardLocation);
                        break;

                    case "Incoming":
                        Debug.Log(hit.collider.tag);
                        Debug.Log(hit.collider.gameObject.GetComponent<JackScript>().BoardLocation);
                        break;
                }
            }
        }
    }
}
