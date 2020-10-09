using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<playerManager>().setPlayerSpawn(this.transform.position);
        other.GetComponent<DLLPluginManager>().CheckpointHit();
        gameObject.SetActive(false);
    }
}
