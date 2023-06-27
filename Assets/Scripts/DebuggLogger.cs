using UnityEngine;
using System.IO;

public class DebuggLogger : MonoBehaviour
{
    //maintaining a log file in case of bugs
    string fileName = "";

    void OnEnable() {
        Application.logMessageReceived += Log;
    }

    void OnDisable() {
        Application.logMessageReceived -= Log;
    }

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.persistentDataPath + "/Logfile.text";
        Debug.Log(Application.persistentDataPath);
    }

    public void Log(string logString, string stackTrace, LogType type) {

        TextWriter tw = new StreamWriter(fileName, true);
        tw.WriteLine("["+System.DateTime.Now+"] " + logString);
        tw.Close();

    }
}
