using UnityEngine;
using System.Collections;

public class GoalManager : MonoBehaviour {

    public int player;
	// Use this for initialization
	void Start () {
        

        
	
	}
	
    public void setColor() {
        foreach (SpriteRenderer borders in GetComponentsInChildren<SpriteRenderer>())
        {
            if (player == 1)
                borders.material.color = Color.blue;
            else
                borders.material.color = Color.red;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
