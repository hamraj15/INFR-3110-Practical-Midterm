using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public GameObject player;
    public float playerSpeed;
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();  
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.transform.position += Vector3.forward * Time.deltaTime * playerSpeed;  
        }
    }

    private void CameraMove()
    {

    }
}


