using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 7f;

    // Update is called once per frame
    void Update()
    {   

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(-vertical, 0f, horizontal).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if(controller.transform.position.x >= 19.5 && vertical < 0) {
                direction = new Vector3(0f, 0f, horizontal).normalized;
            }

            controller.Move(direction * speed * Time.deltaTime);
        }


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookAt);
        }


    }
}
