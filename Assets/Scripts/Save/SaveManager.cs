using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager: MonoBehaviour
{
    public static SaveManager Instance { get {return instance; }}
    private static SaveManager instance;

    private const string SaveFile = "data.pd";
    public SaveState saveProperties;
    private BinaryFormatter formatter;

    public Action<SaveState> OnLoad;
    public Action<SaveState> OnSave;

    private void Awake()
    {
        Load();
        instance = this;
        formatter = new BinaryFormatter();
    }

    public void Load()
    {
        try
        {
            FileStream saveData = new FileStream(Application.persistentDataPath + SaveFile, FileMode.Open, FileAccess.Read);
            saveProperties = (SaveState)formatter.Deserialize(saveData);
            saveData.Close();
            OnLoad?.Invoke(saveProperties);
        }
        catch
        {
            Debug.Log("Save Data not found, Create new save file");
            Save();
        }
    }

    public  void Save()
    {
        if (saveProperties == null) saveProperties = new SaveState();
        saveProperties.LastSave = DateTime.Now;
        FileStream saveData = new FileStream(Application.persistentDataPath + SaveFile, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(saveData, saveProperties);
        saveData.Close();
        OnSave?.Invoke(saveProperties); 
    }
}
