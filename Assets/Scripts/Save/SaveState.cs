using System;

[System.Serializable]
public class SaveState
{
    [NonSerialized] private const int HatsCount = 16;
    public int HighScore { set; get; }
    public int Fish { set; get; }
    public int CurrentHat { set; get; }
    public ushort[] UnlockedHats { set; get; }
    public DateTime LastSave { set; get; }

    public SaveState()
    {
        HighScore = 0;
        Fish = 100;
        CurrentHat = 0;
        UnlockedHats = new ushort[HatsCount];
        UnlockedHats[0] = 1;
        LastSave = DateTime.Now;
    }
}
