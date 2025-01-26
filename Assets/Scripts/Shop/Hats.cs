using UnityEngine;

[CreateAssetMenu(fileName = "Hats")]
public class Hats : ScriptableObject
{
    public string HatName;
    public Sprite Thumbnail;
    public int HatPrice;
    public GameObject Hat;
}
