using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    [Serializable]
    class SaveData
    {
        public int MaxScore;
    }
    [SerializeField] MovePlayer MovePlayer;
    [HideInInspector] public int ScoreLoad;
    public void Save()
    {
        BinaryFormatter Bf = new BinaryFormatter();
        FileStream FileSave = File.Create(Application.persistentDataPath + "TestGame.dat");
        SaveData data = new SaveData();
        data.MaxScore = MovePlayer.Score;
        Bf.Serialize(FileSave, data);
        FileSave.Close();
        Debug.Log("SaveData");
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "TestGame.dat"))
        {
            BinaryFormatter Bf = new BinaryFormatter();
            FileStream File = System.IO.File.Open(Application.persistentDataPath + "TestGame.dat", FileMode.Open);
            SaveData data = (SaveData)Bf.Deserialize(File);
            File.Close();
            MovePlayer.Score = data.MaxScore;
            ScoreLoad = data.MaxScore;
            Debug.Log("LoadData");
        }
        else
        {
            Debug.Log("NotSaveData");
            MovePlayer.Score = 0;
            ScoreLoad = 0;
        }
    }
}
