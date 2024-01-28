using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string ball_id;
    public AudioSource ballSource;
    public AudioClip clink;
    public Material ball_material;
    public GameObject gameMngr;
    public bool isHit = false;
    
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

    private void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0) && isHit)
        {
            isHit = false;
        }
        if (!isHit)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO: decide if balls should disappear on collision with death ball
        /*if (collision.gameObject.GetComponent<Ball>().ball_id.Equals("death")) //destroy ball if collides with death ball
        {
            Destroy(gameObject);
            return;
        }*/
        if (collision.gameObject.tag.Equals("Ball") && isHit)
        {
            if (collision.gameObject.GetComponent<Ball>().ball_id.Equals("death")
                        || gameObject.GetComponent<Ball>().ball_id.Equals("death")) //if death ball is hit
            {
                ballSource.PlayOneShot(clink);
                collision.gameObject.GetComponent<Ball>().isHit = true;
                Vector3 force = new Vector3((collision.gameObject.transform.position.x - gameObject.transform.position.x),
                    (collision.gameObject.transform.position.y - gameObject.transform.position.y),
                    (collision.gameObject.transform.position.z - gameObject.transform.position.z)).normalized;
                collision.gameObject.GetComponent<Rigidbody>().velocity = force;
                return;
            }

            if ((collision.gameObject.GetComponent<Ball>().ball_id.Equals(gameMngr.GetComponent<GameMngr>().humor1)
                        || collision.gameObject.GetComponent<Ball>().ball_id.Equals(gameMngr.GetComponent<GameMngr>().humor2))
                        && (gameObject.GetComponent<Ball>().ball_id.Equals(gameMngr.GetComponent<GameMngr>().humor1)
                        || gameObject.GetComponent<Ball>().ball_id.Equals(gameMngr.GetComponent<GameMngr>().humor2)))
            { //if match is made
                ballSource.PlayOneShot(clink);

                collision.gameObject.GetComponent<Ball>().isHit = true;
                Vector3 force = new Vector3((collision.gameObject.transform.position.x - gameObject.transform.position.x),
                    (collision.gameObject.transform.position.y - gameObject.transform.position.y),
                    (collision.gameObject.transform.position.z - gameObject.transform.position.z)).normalized;
                collision.gameObject.GetComponent<Rigidbody>().velocity = force;
            }

            else   //if incorrect match is made
            {
                //Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.collider);
                Vector3 pos = collision.gameObject.transform.position;
                Destroy(collision.gameObject);
                gameMngr.GetComponent<GameMngr>().SpawnBall("death", pos);

                int newHumor = Random.Range(0, 4);
                string id = gameMngr.GetComponent<GameMngr>().humors[newHumor];
                gameMngr.GetComponent<GameMngr>().SpawnBall(id, new Vector3(Random.Range(-0.4f, 0.4f), 1.16f, Random.Range(-0.4f, 0.4f)));
                Destroy(gameObject);
                return;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Hole")) //not sure if we need this tbh, the only triggers in the scene are the holes
        {
            if (ball_id.Equals("death"))
            {
                //TODO: die!1!1! mwahaha
                gameMngr.GetComponent<GameMngr>().DeathBall();
                Destroy(gameObject);
            }
            else
            {
                //TODO: decide how much score should decrease when opponent scores
                gameMngr.GetComponent<GameMngr>().UpdateScore(10);
                gameMngr.GetComponent<GameMngr>().SpawnBall(ball_id, new Vector3(Random.Range(-0.4f, 0.4f), 1.16f, Random.Range(-0.4f, 0.4f)));
                Destroy(gameObject);
            }
        }
    }
}
