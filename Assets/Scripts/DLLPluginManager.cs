using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DLLPluginManager : MonoBehaviour
{

    const string DLL_NAME = "TimeLoggerDLL";

    [DllImport(DLL_NAME)]
    private static extern void ResetLogger();

    [DllImport(DLL_NAME)]
    private static extern void SaveCheckpointTime(float RTBC);

    [DllImport(DLL_NAME)]
    private static extern float GetTotalTime();

    [DllImport(DLL_NAME)]
    private static extern float GetCheckpointTime(int index);

    [DllImport(DLL_NAME)]
    private static extern int GetNumCheckpoints();

    float previousTime = 0.0f;

    public void ResetLoggerTest()
    {
        ResetLogger();
    }

    public void SaveTimeTest(float time)
    {
        SaveCheckpointTime(time);
    }

    public float TotalTimeTest()
    {
        return GetTotalTime();
    }

    public float CheckpointTimeTest(int index)
    {
        if(index >= GetNumCheckpoints())
        {
            return -1.0f;
        }
        else
            return GetCheckpointTime(index);
    }

    public int GetNumCheckpointsTest()
    {
        return GetNumCheckpoints();
    }



    // Start is called before the first frame update
    void Start()
    {
        previousTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - previousTime;
            previousTime = currentTime;

            SaveTimeTest(checkpointTime);
        }

        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                Debug.Log(CheckpointTimeTest(i));
            }
            else
            {
                Debug.Log(-1.0f);
            }

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(TotalTimeTest());
        }
    }

    void OnDestroy()
    {
        ResetLoggerTest();
    }
}
