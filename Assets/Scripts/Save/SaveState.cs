using System;

[System.Serializable]
public class SaveState
{
    public int HighScore { set; get; }
    public int Fish { set; get; }
    public DateTime LastSave { set; get; }

    public SaveState()
    {
        HighScore = 0;
        Fish = 0;
        LastSave = DateTime.Now;
    }
}
