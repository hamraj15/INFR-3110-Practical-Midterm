using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagement : MonoBehaviour
{

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(3);
        other.GetComponent<DLLPluginManager>().CheckpointHit();
        other.GetComponent<DLLPluginManager>().TotalTimeDone();
        other.GetComponent<DLLPluginManager>().SetCheckpointToText();
        other.GetComponent<DLLPluginManager>().SetFinalTimeToText();
    }

    public void LoadEnd()
    {
        SceneManager.LoadScene(3);
    }
}
