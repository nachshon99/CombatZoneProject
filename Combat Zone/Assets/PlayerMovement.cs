using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Look Left&Right
    float speed;
    float mouseX;
    float speedPlayer;

    //Look Up&Down
    float mouseY;
    public Transform Mycamera;
    float cameraRotationX;

    // Start is called before the first frame update
    void Start()
    {
        speed = 250;
        speedPlayer = 0.01f;
        cameraRotationX = Mycamera.localRotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Look Left&Right
        mouseX = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);

        //Loox Up&&Down

        mouseY = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        cameraRotationX -= mouseY;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -70, 70);
        Mycamera.localRotation = Quaternion.Euler(cameraRotationX, 0, 0);

        //movePlayer
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speedPlayer);
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speedPlayer);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speedPlayer, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speedPlayer, 0, 0);
        }
        //Bend
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
        }
        //Run
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, speedPlayer * 3);
        }


    }
}
