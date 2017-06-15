using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player {

    public Vector2 gridPosition = Vector2.zero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TurnUpdate()
    {
        if(Vector3.Distance(moveDestination, transform.position) > 0.1f)
        {
            transform.position += (moveDestination - transform.position)
                .normalized * moveSpeed * Time.deltaTime;

            if(Vector3.Distance(moveDestination, transform.position)<= 0.1f)
            {
                transform.position = moveDestination;
                GameManager.instance.nextTurn();
            }
        }
        else
        {
            moveDestination = new Vector3(0 - Mathf.Floor(GameManager.instance.mapSize / 2),
                1.5f, -9 + Mathf.Floor(GameManager.instance.mapSize / 2));
        }

        base.TurnUpdate();
    }


    void OnMouseEnter()
    {
        transform.GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log("my position is(" + gridPosition.x + "," + gridPosition.y + ")");
    }

    void OnMouseExit()
    {
        transform.GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseDown()
    {
        GameManager.instance.moveCurrentPlayer(this);
    }
}
