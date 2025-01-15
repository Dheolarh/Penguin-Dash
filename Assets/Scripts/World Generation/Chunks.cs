using UnityEngine;

public class Chunks : MonoBehaviour
{
    public float chunkLength;
    
    public Chunks ShowChunk(){
        gameObject.transform.BroadcastMessage("FishInChunk", SendMessageOptions.DontRequireReceiver);
        gameObject.SetActive(true);
        return this;
    }
    
    public Chunks HideChunk(){
        gameObject.SetActive(false);
        return this;
    }
}
