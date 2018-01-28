﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallScript : MonoBehaviour
{
    /// <summary>
    /// Variables:
    /// 
    ///     shape: designates shape of the call plug
    ///     pointValue: generated by Player script
    ///     
    ///     callTimePassed: time passed since the call was successfully taken
    ///     callTime: predesignated time for the call to complete; generated by Player script
    ///     
    ///     callExpireTimePassed: amount of time the call has been ignored for
    ///     callExpireTime: Maximum amount of time the call is allowed to be ignored before disappearing
    ///     
    ///     callTaken: switch which shows whether the call is currently being taken
    ///     selected: true if currently being selected by the player
    /// 
    ///     incomingCallPos: position on the switchboard where the call comes in
    ///     
    /// </summary>

    private GameObject shape;
    private int pointValue;

    private float callTimePassed;
    private float callTime;

    private float callExpireTimePassed;
    private float callExpireTime;

    private bool callTaken;
    private bool selected;

    private float colorIntervalTime;
    private float colorIntervalTimePassed;
    private int colorInterval;

    private Vector2 incomingCallPos;

    public Player player;
    public GameObject centerBlock;
    public GameObject[] blocks;
    public Vector2[] points;
    public float xScale;
    public float yScale;
    public Color color;



    //Properties
    public GameObject Shape
    {
        get { return shape; }
        set { shape = value; }
    }

    public float CallTimePassed
    {
        get { return callTimePassed; }
        set { callTimePassed = value; }
    }

    public float CallTime
    {
        get { return callTime; }
        set { callTime = value; }
    }

    public float CallExpireTime
    {
        get { return callExpireTime; }
        set { callExpireTime = value; }
    }
    public float CallExpireTimePassed
    {
        get { return callExpireTimePassed; }
        set { callExpireTimePassed = value; }
    }

    public float ColorIntervalTime
    {
        get { return colorIntervalTime; }
        set { colorIntervalTime = value; }
    }
    public int PointValue
    {
        get { return pointValue; }
        set { pointValue = value; }
    }

    public bool CallTaken
    {
        get { return callTaken; }
        set { callTaken = value; }
    }
    public bool Selected
    {
        get { return selected; }
        set { selected = value; }
    }

	// Use this for initialization
	void Start ()
    {
        callTimePassed = 0;
        callExpireTimePassed = 0;
        colorInterval = 0;

        // Switch to false once testing is done
        SetVisible(true);
        for (int i = 0; i < blocks.Length; i++)
        {
            centerBlock.GetComponent<SpriteRenderer>().color = color;
            blocks[i].GetComponent<SpriteRenderer>().color = color;
        }

        centerBlock.transform.position = transform.position;

        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].transform.position = new Vector2(centerBlock.transform.position.x + (points[i].x * xScale), centerBlock.transform.position.y + (points[i].y * yScale));
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (selected)
        {
            Vector3 mouse = Input.mousePosition;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 0));
            centerBlock.transform.position = transform.position;

            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].transform.position = new Vector2(centerBlock.transform.position.x + (points[i].x * xScale), centerBlock.transform.position.y + (points[i].y * yScale));
            }
        }
        //SetBlockPositions();
        centerBlock.transform.position = new Vector3(centerBlock.transform.position.x, centerBlock.transform.position.y, 0);

        if (callTaken)
        {
            CallTimePassed += Time.deltaTime;

            // If the call was successfully finished, call disappears and updates score
            if (CallTimePassed == CallTime)
            {
                player.ChangeScore(pointValue);
                Destroy(gameObject);
            }
        }
        else
        {
            // Plays initial call tone and adds green indicator
            // Should probably be in start instead
            if (colorIntervalTimePassed == 0 && colorInterval == 0)
            {

            }

            CallExpireTimePassed += Time.deltaTime;
            colorIntervalTimePassed += Time.deltaTime;

            if(colorIntervalTimePassed == ColorIntervalTime)
            {
                colorIntervalTimePassed = 0;
                colorInterval++;

                //Plays a warning tone and changes color to yellow
                if (colorInterval == 1)
                {

                }

                //Plays a danger tone and changes color to red
                if (colorInterval == 2)
                {

                }

            }

            //If time for the call to be taken expires, player loses a life and call disappears
            if (CallExpireTimePassed == CallExpireTime)
            {
                player.lives--;
            }
        }



	}

    public void SetVisible(bool isVisible)
    {
        centerBlock.GetComponent<SpriteRenderer>().enabled = isVisible;
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<SpriteRenderer>().enabled = isVisible;
        }
    }

    //private void SetBlockPositions()
    //{
        

        
    //}
}
