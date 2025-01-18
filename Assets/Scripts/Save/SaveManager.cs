using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager: MonoBehaviour
{
    public static SaveManager Instance { get {return instance; }}
    private static SaveManager instance;

    private const string SaveFile = "data.pd";
    public SaveState saveData;
    private BinaryFormatter formatter;

    public Action<SaveState> OnLoad;
    public Action<SaveState> OnSave;

    private void Awake()
    {
        instance = this;
        formatter = new BinaryFormatter();
        Load();
    }

    public void Load()
    {
        try
        {
            FileStream saveDataFile = new FileStream(Application.persistentDataPath + SaveFile, FileMode.Open, FileAccess.Read);
            saveData = (SaveState)formatter.Deserialize(saveDataFile);
            saveDataFile.Close();
            OnLoad?.Invoke(saveData);
        }
        catch
        {
            Debug.Log("Save Data not found, Create new save file");
            Save();
        }
    }

    public  void Save()
    {
        if (saveData == null) saveData = new SaveState();
        saveData.LastSave = DateTime.Now;
        FileStream saveDataFile = new FileStream(Application.persistentDataPath + SaveFile, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(saveDataFile, saveData);
        saveDataFile.Close();
        OnSave?.Invoke(saveData); 
    }
}
