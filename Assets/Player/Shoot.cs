using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform camera;

    Animator animator;
    Vector3 cameraOriginalPos;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        cameraOriginalPos = camera.localPosition;
    }

    void Update()
    {
        Vector3 targetPos = Input.GetMouseButton(0) ? cameraOriginalPos + new Vector3(0, 0, 0.3f) : cameraOriginalPos;
        camera.transform.localPosition = Vector3.Lerp(
            camera.transform.localPosition,
            targetPos,
            Time.deltaTime * 5f
        );

        animator.SetBool("Shooting", Input.GetMouseButton(0));
        if (Input.GetMouseButtonDown(1))
            animator.SetTrigger("Shoot");
    }
}
