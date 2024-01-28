using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public string controller;
    public Transform playerCamera;
    public Transform broomTip;
    public float range = 10f;
    public bool canShoot;
    public bool hasShot;

    Animator animator;
    Vector3 cameraOriginalPos;
    void Start()
    {
        hasShot = false;
        canShoot = false;
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

        if (canShoot && Input.GetButtonDown($"Shoot {controller}"))
        {
            animator.SetTrigger("Shoot");

            Vector3 origin = broomTip.position;
            RaycastHit hit;
            if (Physics.Raycast(origin, broomTip.transform.forward, out hit, range))
            {
                if (hit.transform.gameObject.tag.Equals("Ball"))
                {
                    hasShot = true;
                    Vector3 force = new Vector3((hit.transform.position.x - origin.x), (hit.transform.position.y - origin.y), (hit.transform.position.z - origin.z)).normalized;
                    hit.transform.gameObject.GetComponent<Rigidbody>().velocity = force;
                    hit.transform.gameObject.GetComponent<Ball>().isHit = true;
                }
            }
        }
    }
}
