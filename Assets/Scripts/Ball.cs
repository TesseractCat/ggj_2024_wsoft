using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string ball_id;
    public Material ball_material;
    public GameObject gameMngr;
    
    //constructor
    public Ball (string id_in, Material material_in)
    {
        ball_id = id_in;
        ball_material = material_in;
    }

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = ball_material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>().ball_id.Equals("death")) //destroy ball if collides with death ball
        {
            Destroy(gameObject);
            return;
        }


    }
}
