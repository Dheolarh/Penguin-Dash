using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    // Gameplay
    private float chunkSpawnZPos;
    private Queue<Chunks> activeChunks = new Queue<Chunks>();
    private List<Chunks> chunkPool = new List<Chunks>();
    
    // Configurations
    [SerializeField] private float firstChunkSpawnPos;
    [SerializeField] private int chunkOnScreen = 5;
    [SerializeField] private float despawnDistance = 5.0f;

    [SerializeField] private List<GameObject> chunkPrefab;
    [SerializeField] private Transform cameraSpace;

    #region TO DELETE $$
    void Awake()
    {
        ResetWorld();
    }
    #endregion

    void Start()
    {
        if (chunkPrefab.Count == 0)
        {
            Debug.LogError("Empty Chunk list");
            return;
        }

        if (!cameraSpace)
        {
            if (Camera.main != null) cameraSpace = Camera.main.transform;
            Debug.Log("Successfully Assigned camera position to main camera position");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScanPosition();
    }

    void ScanPosition()
    {
        float cameraZPos = cameraSpace.position.z;
        Chunks lastChunk = activeChunks.Peek(); //Peek returns the last element in a Queue
        if (cameraZPos >= lastChunk.transform.position.z + lastChunk.chunkLength + despawnDistance)
        {
            SpawnNewChunk();
            DeleteLastChunk();
        }
    }

    void SpawnNewChunk()
    {
        int randomIndex = Random.Range(0, chunkPrefab.Count);
        
        // Find inactive chunk in the pool
        Chunks newchunk = chunkPool.Find(chunkElement => !chunkElement.gameObject.activeSelf && chunkElement.name == chunkPrefab[randomIndex].name + "(Clone)");

        if (!newchunk)
        {
            GameObject createChunk = Instantiate(chunkPrefab[randomIndex], transform);
            newchunk = createChunk.GetComponent<Chunks>();
        }

        newchunk.transform.position = new Vector3(0, 0, chunkSpawnZPos);
        chunkSpawnZPos += newchunk.chunkLength;
        
        activeChunks.Enqueue(newchunk);
        newchunk.ShowChunk();
    }

    void DeleteLastChunk()
    {
        Chunks oldChunk = activeChunks.Dequeue();
        oldChunk.HideChunk();
        chunkPool.Add(oldChunk);
    }

    void ResetWorld()
    { 
         chunkSpawnZPos = firstChunkSpawnPos;

         for (int i = activeChunks.Count; i != 0; i--)
             DeleteLastChunk();
         for (int i = 0; i < chunkOnScreen; i++)
             SpawnNewChunk();
    }
}
