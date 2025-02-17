using System;

[System.Serializable]
public class SaveState
{
    [NonSerialized] private const int HatsCount = 16;
    public int HighScore { set; get; }
    public bool FirstTime { set; get; }
    public bool Debugger { set; get; }
    public bool FirstHighScore { set; get; }
    public int Fish { set; get; }
    public int CurrentHat { set; get; }
    public ushort[] UnlockedHats { set; get; }
    public DateTime LastSave { set; get; }

    public SaveState()
    {
        FirstTime = true;
        Debugger = true;
        FirstHighScore = false;
        HighScore = 0;
        Fish = 0;
        CurrentHat = 0;
        UnlockedHats = new ushort[HatsCount];
        UnlockedHats[0] = 1;
        LastSave = DateTime.Now;
    }
}
