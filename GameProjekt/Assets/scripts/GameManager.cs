using UnityEngine;
using System.Collections;
using Assets.scripts;
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

    public PinePicker pick;

    // Use this for initialization
    void Start ()
    {
        assignGoals();
        updateScore();
        currentPhase = phases.ROUNDSTART;

        // place la balle a 90 et 100 dans les y et 0 a 30 dans les X

    }

    private GameObject createBall()
    {
        // TODO create the ball in the borders
        // y entre 90 et 100 => 95
        // x 0 a 60

        float xValue = Random.Range(1f, 60f);
        GameObject ball = Instantiate(Resources.Load("Ball"), new Vector3(xValue, 95f), Quaternion.identity) as GameObject;
        // THIS SHOULD BE SET TO 1 WHEN GOING TO ACTION PHASE
        ball.GetComponent<Rigidbody2D>().gravityScale = 0 ;
        return ball;
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
    GameObject _currentBall;
	void Update () {

        if (currentPhase == phases.ROUNDSTART)
        {
            _currentBall = createBall();
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

        if (currentPhase == phases.ACTION && _currentBall != null)
        {
            _currentBall.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        if (_currentBall == null)
        {
            currentPhase = phases.ROUNDSTART;
        }

        updateScore();
	}
    
    public void updateScore()
    {
        scoreText.text = "Player 1: " + Player1Points + " | Player 2: " + Player2Points;
    }

}
