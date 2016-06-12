using UnityEngine;
using System.Collections;

public class PineState : MonoBehaviour {

    // Use this for initialization
    public int breakPoints = 5;
    int test;
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        breakPoints--;
        Debug.Log("POINTS LEFT: " + breakPoints);
        if (breakPoints == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
