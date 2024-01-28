using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMngr : MonoBehaviour
{
    public GameObject ball_prefab;

    // humors that are allowed to collide
    public string humor1;
    public string humor2;

    public List<string> humors = new List<string>
    {
        "yellow", "black", "red", "blue"
    };

    public List<GameObject> lights;

    int player1score;
    int player2score;

    int turn; // turn = 0 when player1 turn, turn = 1 when player2 turn

    bool turnTaken; // true = player has hit the ball and can no longer use the cue, false = player can use the cue

    GameObject[] balls;

    public List<Material> materials;

    [Header("Players")]
    public GameObject player1;
    public GameObject player2;

    [Header("UI Elements")]
    public TextMeshProUGUI turnText;
    public Slider player1slider;
    public Slider player2slider;

    void Start()
    {
        ChangeCombos();
        player1score = 100;
        player2score = 100;
        turn = 0;
        UpdateUI();
        turnTaken = false;
        //spawn two balls of each humor initially
        for (int i = 0; i < 2; i++)
        {
            SpawnBall("yellow", new Vector3(Random.Range(-0.5f, 0.5f), 1.16f, Random.Range(-0.5f, 0.5f)));
        }
        for (int i = 0; i < 2; i++)
        {
            SpawnBall("black", new Vector3(Random.Range(-0.5f, 0.5f), 1.16f, Random.Range(-0.5f, 0.5f)));
        }
        for (int i = 0; i < 2; i++)
        {
            SpawnBall("red", new Vector3(Random.Range(-0.5f, 0.5f), 1.16f, Random.Range(-0.5f, 0.5f)));
        }
        for (int i = 0; i < 2; i++)
        {
            SpawnBall("blue", new Vector3(Random.Range(-0.5f, 0.5f), 1.16f, Random.Range(-0.5f, 0.5f)));
        }
    }

    void Update()
    {
        if (turn == 0)
        {
            if (player1.GetComponent<Shoot>().hasShot)
            {
                turnTaken = true;
                player1.GetComponent<Shoot>().canShoot = false;
            }
            else
            {
                turnTaken = false;
                player1.GetComponent<Shoot>().canShoot = true;
            }
            player2.GetComponent<Shoot>().canShoot = false;
        }
        if (turn == 1)
        {
            if (player2.GetComponent<Shoot>().hasShot)
            {
                turnTaken = true;
                player2.GetComponent<Shoot>().canShoot = false;
            }
            else
            {
                turnTaken = false;
                player2.GetComponent<Shoot>().canShoot = true;
            }
            player1.GetComponent<Shoot>().canShoot = false;
        }
        if (turnTaken)
        {
            CheckBalls();
        }
    }

    public void ChangeCombos()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].SetActive(false);
        }

        int combo1 = Random.Range(0, 4);

        List<int> numsLeft = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            if (i != combo1)
            {
                numsLeft.Add(i);
            }
        }

        int combo2 = numsLeft[Random.Range(0, 3)];

        humor1 = humors[combo1];
        humor2 = humors[combo2];

        lights[combo1].SetActive(true);
        lights[combo2].SetActive(true);
    }

    public void SpawnBall(string id, Vector3 pos)
    {
        GameObject ball = Instantiate(ball_prefab, pos, Quaternion.identity);
        ball.GetComponent<Ball>().ball_id = id;
        switch (id)
        {
            case "yellow":
                ball.GetComponent<Ball>().ball_material = materials[0];
                break;
            case "black":
                ball.GetComponent<Ball>().ball_material = materials[1];
                break;
            case "red":
                ball.GetComponent<Ball>().ball_material = materials[2];
                break;
            case "blue":
                ball.GetComponent<Ball>().ball_material = materials[3];
                break;
            case "death":
                ball.GetComponent<Ball>().ball_material = materials[4];
                break;
        }
    }

    public void UpdateScore(int modifier)
    {
        if (turn == 0)
        {
            player2score -= modifier;   // if player1 scores decrease player2 score
        }
        else if (turn == 1)
        {
            player1score -= modifier;   // if player2 scores decrease player1 score
        }
        player1slider.value = player1score;
        player2slider.value = player2score;
    }

    void UpdateUI()
    {
        if (turn == 0)
        {
            turnText.text = "Player 1's Turn";
        }
        else
        {
            turnText.text = "Player 2's Turn";
        }
    }

    public void CheckBalls()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i].GetComponent<Ball>().isHit)    //if any of the balls in the scene are in motion then return
            {
                return;
            }
        }
        turnTaken = false;  //next player has yet to hit a ball
        player1.GetComponent<Shoot>().hasShot = false;
        player2.GetComponent<Shoot>().hasShot = false;
        if (turn == 0)  //turn transfers to opponent
        {
            turn = 1;
        }
        else if (turn == 1)
        {
            turn = 0;
        }
        UpdateUI();
    }
}
