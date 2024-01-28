using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public string controller;
    public Transform playerCamera;
    public float range = 10f;

    Animator animator;
    Vector3 cameraOriginalPos;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        cameraOriginalPos = playerCamera.localPosition;
    }

    void Update()
    {
        Vector3 targetPos = Input.GetButton($"Bend {controller}") ? cameraOriginalPos + new Vector3(0, 0, 0.3f) : cameraOriginalPos;
        playerCamera.transform.localPosition = Vector3.Lerp(
            playerCamera.transform.localPosition,
            targetPos,
            Time.deltaTime * 5f
        );

        animator.SetBool("Shooting", Input.GetButton($"Bend {controller}"));
        // if (Input.GetButtonDown("Shoot P1")) {
        //     animator.SetTrigger("Shoot");

        //     Vector3 origin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        //     RaycastHit hit;
        //     if (Physics.Raycast(origin, playerCamera.transform.forward, out hit, range))
        //     {
        //         if (hit.transform.gameObject.tag.Equals("Ball"))
        //         {
        //             Vector3 force = new Vector3((hit.transform.position.x - origin.x), (hit.transform.position.y - origin.y), (hit.transform.position.z - origin.z)).normalized;
        //             hit.transform.gameObject.GetComponent<Rigidbody>().velocity = force;
        //             hit.transform.gameObject.GetComponent<Ball>().isHit = true;
        //         }
        //     }
        // }
    }
}
