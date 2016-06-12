using UnityEngine;
using System.Collections;
using Assets.scripts;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

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
    public Text player1Score;
    public Text player2Score;
    public PinePicker pick;

    // Use this for initialization
    void Start ()
    {
        assignGoals();
        updateScore();
        currentPhase = phases.ROUNDSTART;

        // place la balle a 90 et 100 dans les y et 0 a 30 dans les X

    }

    private HashSet<GameObject> createBall()
    {
        int randomBallValue = Random.Range(1, 8) % 3;
        HashSet<GameObject> balls = new HashSet<GameObject>();
        for (int i = 0; i < randomBallValue; i++) { 
            float xValue = Random.Range(1f, 59f);
            GameObject ball;
            ball = Instantiate(Resources.Load("Ball"), new Vector3(xValue, 95f), Quaternion.identity) as GameObject;
            // THIS SHOULD BE SET TO 1 WHEN GOING TO ACTION PHASE
            ball.GetComponent<Rigidbody2D>().gravityScale = 0 ;
            ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            balls.Add(ball);
        }
        return balls;

    }

    // assigne 6 zones à chaque joueur
    private static void assignGoals()
    {
        GameObject[] goals = GameObject.FindGameObjectsWithTag("Goals");
        int playerOne = 0;
        int playerTwo = 0;

        foreach (GameObject goal in goals)
        {
            int player = Random.Range(1, 3);

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
            goal.GetComponentInChildren<GoalManager>().player = player;
            goal.GetComponentInChildren<GoalManager>().setColor();
        }
    }
    
    void CreatePine(int player)
    {
        GameObject pine = Instantiate(Resources.Load("Pine"), Vector3.zero, Quaternion.identity) as GameObject;

        if (player == 1) pine.GetComponent<SpriteRenderer>().color = Color.blue;
        else pine.GetComponent<SpriteRenderer>().color = Color.red;

        pick.Pine = pine.transform;
    }

    // Update is called once per frame
    int _pinePLaced;
    public static HashSet<GameObject> _currentBalls;
	void Update () {

        if (currentPhase == phases.ROUNDSTART)
        {
            _currentBalls = createBall();
            _pinePLaced = 0;
            currentPhase = phases.PLACING;
        }

        if (currentPhase == phases.PLACING)
        {
            if (pick.Pine == null && _pinePLaced >= 4) currentPhase = phases.ACTION;
            else if (pick.Pine == null)
            {
                CreatePine(_pinePLaced%2);
                _pinePLaced++;
            }
        }

        if (currentPhase == phases.ACTION && _currentBalls.Count > 0)
        {
            foreach(GameObject ball in _currentBalls) { 
                ball.GetComponent<Rigidbody2D>().gravityScale = 1;
                ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
        }

        if (_currentBalls.Count == 0)
        {
            currentPhase = phases.ROUNDSTART;
        }

        updateScore();
	}
    
    public void updateScore()
    {
        player1Score.text = "Player 1: " + Player1Points;
        player1Score.color = Color.blue;
        player2Score.text = "Player 2: " + Player2Points;
        player2Score.color = Color.red;
    }

}
