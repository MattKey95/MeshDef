using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float sensitivity = 2;
    public float sprintSpeed = 1;
    public GameObject cam;
    

    CharacterController player;
    float moveFB;
    float moveLR;

    float rotX;
    float rotY;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var tempSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
            tempSpeed = sprintSpeed;

        moveFB = Input.GetAxis("Vertical") * tempSpeed;
        moveLR = Input.GetAxis("Horizontal") * tempSpeed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(0, rotX, 0);
        cam.transform.Rotate(-rotY, 0, 0);

        var movement = new Vector3(moveLR, 0, moveFB);
        movement = transform.rotation * movement;

        player.Move(movement * Time.deltaTime);
    }

    public void Move(Vector3 vector)
    {
        player.Move(vector);
    }
}
