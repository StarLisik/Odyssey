using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveHighScoreScript : MonoBehaviour
{
    public static SaveHighScoreScript instance;
    static string playerDataName = "Save.dd";
    public static string playerDataPath;

    static string WriteData()
    {
        playerDataPath = Application.streamingAssetsPath + '/' + "Saves" + '/' + playerDataName;
        using (StreamReader read = new StreamReader(playerDataPath))
        {
            if (read.ReadToEnd() == "")
            {
                read.Close();
                StreamWriter save = new StreamWriter(playerDataPath);
                save.Write(0);
                save.Flush();
                save.Close();
            }
        }
        return playerDataPath;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = (this);
        WriteData();
    }
  
}
