using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] goals = GameObject.FindGameObjectsWithTag("Goals");
        int playerOne = 0;
        int playerTwo = 0;

        foreach (GameObject goal in goals)
        {
            int player = Mathf.RoundToInt(Random.Range(1, 3));

            if (player == 1)
            {

                if (playerOne >= 6) { 
                    player = 2;
                    playerTwo++;
                } else { 
                    playerOne++;
                }
            }
            else
            {
                if (playerTwo >= 6)
                {
                    player = 1;
                    playerOne++;
                }
                else { 
                    playerTwo++;
                }
            }

           
            goal.GetComponent<GoalManager>().player = player;
            goal.GetComponent<GoalManager>().setColor();
        }

        Debug.Log("Player 1 : " + playerOne + ", Player 2 : " + playerTwo);
        // assigne 6 zones à chaque joueur

        // place la balle a 90 et 100 dans les y et 0 a 30 dans les X

    }






	
	// Update is called once per frame
	void Update () {
	
	}
}
