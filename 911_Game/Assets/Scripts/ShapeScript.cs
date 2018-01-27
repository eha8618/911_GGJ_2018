using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeScript : MonoBehaviour
{
    public GameObject centerBlock;
    public GameObject[] blocks;
    public Vector2[] points;

	// Use this for initialization
	void Start ()
    {
        centerBlock.transform.position = transform.position;
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].transform.position = new Vector2(centerBlock.transform.position.x + points[i].x, centerBlock.transform.position.y + points[i].y);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < points.Length; i++)
        {

        }
	}

    public void SetVisible(bool isVisible)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<SpriteRenderer>().enabled = isVisible;
        }
    }
}
