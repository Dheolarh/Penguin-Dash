using UnityEngine;

public class Chunks : MonoBehaviour
{
    public float chunkLength;
    
    public ShowChunk(){
        gameObject.SetActive(true);
        return this;
    }
    
    public HideChunk(){
        gameObject.SetActive(false);
        return this;
    }
}
