using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeScript : MonoBehaviour
{
    public GameObject centerBlock;
    public GameObject[] blocks;
    public Vector2[] points;
    public float xScale;
    public float yScale;
    public Color color;

	// Use this for initialization
	void Start ()
    {
        SetBlockPositions();
        for (int i = 0; i < blocks.Length; i++)
        {
            //centerBlock.GetComponent<SpriteRenderer>().color = color;
            //blocks[i].GetComponent<SpriteRenderer>().color = color;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetBlockPositions();
	}

    public void SetVisible(bool isVisible)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<SpriteRenderer>().enabled = isVisible;
        }
    }

    private void SetBlockPositions()
    {
        centerBlock.transform.position = transform.position;
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].transform.position = new Vector2(centerBlock.transform.position.x + (points[i].x * xScale), centerBlock.transform.position.y + (points[i].y * yScale));
        }
    }
}
