﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    /*
     * PHASE 1: START ROUND
     * PHASE 2: PLACE YOUR PINS
     * PHASE 3: RESULTS
     */

    enum phases { ROUNDSTART, PLACING, ACTION }
    phases currentPhase;
    public static int Player1Points;
    public static int Player2Points;
    public Text scoreText;

    // Use this for initialization
    void Start ()
    {
        assignGoals();
        updateScore();
        currentPhase = phases.ROUNDSTART;
        createBall();

        currentPhase = phases.PLACING;


        // place la balle a 90 et 100 dans les y et 0 a 30 dans les X

    }

    private void createBall()
    {
        // TODO create the ball in the borders
        // y entre 90 et 100 => 95
        // x 0 a 60

        float xValue = Random.Range(1f, 60f);
        GameObject ball = Instantiate(Resources.Load("Ball"), new Vector3(xValue, 95f), Quaternion.identity) as GameObject;
        // THIS SHOULD BE SET TO 1 WHEN GOING TO ACTION PHASE
        //ball.GetComponent<Rigidbody2D>().gravityScale = 0 ;

    }

    // assigne 6 zones à chaque joueur
    private static void assignGoals()
    {
        GameObject[] goals = GameObject.FindGameObjectsWithTag("Goals");
        int playerOne = 0;
        int playerTwo = 0;

        foreach (GameObject goal in goals)
        {
            int player = Mathf.RoundToInt(Random.Range(1, 3));

            if (player == 1)
            {
                if (playerOne >= 6)
                {
                    player = 2;
                    playerTwo++;
                }
                else
                {
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
                else
                {
                    playerTwo++;
                }
            }
            goal.GetComponent<GoalManager>().player = player;
            goal.GetComponent<GoalManager>().setColor();
        }
        Debug.Log("Player 1 : " + playerOne + ", Player 2 : " + playerTwo);
    }

    public void updateScore()
    {
        scoreText.text = "Player 1: " + Player1Points + " | Player 2: " + Player2Points;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos;
        
        if (currentPhase == phases.PLACING && Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition;
            Debug.Log("MOUSE CLICK AT: " + mousePos.ToString());
        }
        updateScore();
	}

    

}
