using UnityEngine;
using System.Collections;

public class GoalManager : MonoBehaviour {

    public int player;
	// Use this for initialization
	
    public void setColor() {

        if (player == 1)
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.blue;
        else
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
        
    }

	// Update is called once per frame

}
