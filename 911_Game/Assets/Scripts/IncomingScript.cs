using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingScript : MonoBehaviour {

    public int difficulty;

    private float expireTime;

    public float ExpireTime
    {
        get { return expireTime; }
        set { expireTime = value; }
    }

    private void Start()
    {
        expireTime = 0;
    }

    private void Update()
    {
        expireTime += Time.deltaTime;
    }

}
