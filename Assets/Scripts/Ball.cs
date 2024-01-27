using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string ball_id;
    public Material ball_material;
    public GameObject gameMngr;
    public GameObject ball;
    
    //constructor
    /*public Ball (string id_in, Material material_in)
    {
        ball_id = id_in;
        ball_material = material_in;
    }*/

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = ball_material;
        gameMngr = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO: decide if balls should disappear on collision with death ball
        /*if (collision.gameObject.GetComponent<Ball>().ball_id.Equals("death")) //destroy ball if collides with death ball
        {
            Destroy(gameObject);
            return;
        }*/

        if ((collision.gameObject.GetComponent<Ball>().ball_id.Equals(gameMngr.GetComponent<GameMngr>().humor1)
            || collision.gameObject.GetComponent<Ball>().ball_id.Equals(gameMngr.GetComponent<GameMngr>().humor2))
            && (gameObject.GetComponent<Ball>().ball_id.Equals(gameMngr.GetComponent<GameMngr>().humor1)
            || gameObject.GetComponent<Ball>().ball_id.Equals(gameMngr.GetComponent<GameMngr>().humor2))) { //if match is made

            gameMngr.GetComponent<GameMngr>().ChangeCombos();   //change correct combination
        }

        else    //if incorrect match is made
        {
            Vector3 pos = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            GameObject deathBall = Instantiate(ball, pos, Quaternion.identity);
            deathBall.GetComponent<Ball>().ball_id = "death";
            //TODO: load death ball material from assets
            //deathBall.GetComponent<Ball>().ball_material = 
            GameObject newBall = Instantiate(ball, new Vector3(0, 1.2f, 0), Quaternion.identity);
            int newHumor = Random.Range(0, 4);
            newBall.GetComponent<Ball>().ball_id = gameMngr.GetComponent<GameMngr>().humors[newHumor];
            //TODO: load new ball material from assets
            //newBall.GetComponent<Ball>().ball_material = 
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Hole")) //not sure if we need this tbh, the only triggers in the scene are the holes
        {
            if (ball_id.Equals("death"))
            {
                //TODO: die!1!1! mwahaha
            }
            else
            {
                //TODO: decide how much score should decrease when opponent scores
                gameMngr.GetComponent<GameMngr>().UpdateScore(10);
            }
        }
    }
}
