using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera playerCamera;
    public float range = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 origin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(origin, playerCamera.transform.forward, out hit, range))
            {
                if (hit.transform.gameObject.tag.Equals("Ball"))
                {
                    Vector3 force = new Vector3((hit.transform.position.x - origin.x), (hit.transform.position.y - origin.y), (hit.transform.position.z - origin.z)).normalized;
                    hit.transform.gameObject.GetComponent<Rigidbody>().velocity = force;
                    hit.transform.gameObject.GetComponent<Ball>().isHit = true;
                }
            }
        }
    }
}
