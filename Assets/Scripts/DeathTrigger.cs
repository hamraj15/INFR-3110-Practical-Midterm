using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<playerManager>().respawnPlayer();
    }
}
