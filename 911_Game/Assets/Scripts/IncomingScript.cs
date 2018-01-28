using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingScript : MonoBehaviour {

    public int difficulty;
    public GameObject player;

    private float expireTime;

    public float ExpireTime
    {
        get { return expireTime; }
        set { expireTime = value; }
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        expireTime = 0;
    }

    private void Update()
    {
        expireTime += Time.deltaTime;

        if (expireTime >= 10.0f)
        {
            player.GetComponent<Player>().lives--;

            Destroy(gameObject);
        }
    }

}
