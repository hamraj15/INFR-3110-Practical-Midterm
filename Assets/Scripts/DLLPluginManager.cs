using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class DLLPluginManager : MonoBehaviour
{

    public float timeDone;
    public List<Text> checkpointTimes;
    public Text finalTime;


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

    public void ResetLoggerTime()
    {
        ResetLogger();
    }

    public void SaveTime(float time)
    {
        SaveCheckpointTime(time);
    }

    public void TotalTimeDone()
    {
        timeDone = GetTotalTime();
    }

    public float ReturnTime()
    {
        return timeDone;
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

    void onDestroy()
    {
        ResetLoggerTime();
    }

    public void CheckpointHit()
    {
        float currentTime = Time.time;
        float checkpointTime = currentTime - previousTime;
        previousTime = currentTime;

        SaveTime(checkpointTime);
    }

    public void SetCheckpointToText()
    {
        for (int i = 0; i < GetNumCheckpointsTest(); i++)
        {
            checkpointTimes[i].text = CheckpointTimeTest(i).ToString();
        }
    }

    public void SetFinalTimeToText()
    {
        finalTime.text = timeDone.ToString();
    }

}
