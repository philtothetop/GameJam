using UnityEngine;
using System.Collections;

public class PineState : MonoBehaviour {

    // Use this for initialization
    public int breakPoints = 5;
    int test;

    // Update is called once per frame
    float time;
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        breakPoints--;
        if (breakPoints == 0)
        {
            Destroy(gameObject);
        }
        time = Time.unscaledTime;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (time != 0 && Time.unscaledTime - 2 > time) Destroy(gameObject);
    }

    void OnCollisionExit(Collision2D coll)
    {
        time = 0;
    }
}
