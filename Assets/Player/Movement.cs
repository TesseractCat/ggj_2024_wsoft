using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 5.0f;

    bool onGround = true;
    
    void FixedUpdate()
    {
        Vector3 movementDir = Vector3.ClampMagnitude(transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"), 1.0f);
        GetComponent<Rigidbody>().velocity = new Vector3((movementDir * speed).x, GetComponent<Rigidbody>().velocity.y, (movementDir * speed).z);
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position + movementDir * 0.4f, Vector3.down, out hit, 0.4f)) {
            transform.position = (new Vector3(transform.position.x, hit.point.y, transform.position.z));
            //transform.position = hit.point;
        }*/
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange); 
        }
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f)) {
        //    if (hit.distance < 0.05f)
        //        transform.position = new Vector3(transform.position.x, hit.point.y + 0.4f, transform.position.z);
        //}
    }
}
