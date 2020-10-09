using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapPlane : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
