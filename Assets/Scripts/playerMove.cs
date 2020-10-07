using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    private CharacterController playerControl;
    public GameObject playerCamera;
    public float playerSpeed;

    private Vector3 move;


    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        CameraMove();
    }

    private void PlayerMove()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerControl.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    private void CameraMove()
    {
        playerCamera.transform.position += (move * Time.deltaTime * playerSpeed);
    }
}
