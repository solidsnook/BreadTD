using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameManager GM;
    
    public GameObject breadBasic, breadSpeedy, breadHoovy, Spawner;

    public int breadBasicCount, breadSpeedyCount, breadHoovyCount;

    public float basicSpawnDelay, speedySpawnDelay, hoovySpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawn()
    {
        Debug.Log("SpawnRoutineStarted");
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        //spawn basic breads
        for (int i = 0; i < breadBasicCount; i++)
        {
            SpawnBread(breadBasic);
            yield return new WaitForSeconds(basicSpawnDelay);
        }

        //spawn speedy breads
        for (int i = 0; i < breadSpeedyCount; i++)
        {
            SpawnBread(breadSpeedy);
            yield return new WaitForSeconds(speedySpawnDelay);
        }

        //spawn hoovy breads
        for (int i = 0; i < breadHoovyCount; i++)
        {
            SpawnBread(breadHoovy);
            yield return new WaitForSeconds(hoovySpawnDelay);
        }

        GM.FinishWave();
    }

    void SpawnBread(GameObject breadSpawned)
    {
        Spawner.GetComponent<Spawn>().SpawnBreadOfType(breadSpawned);
        //GM.AliveBreads.Add(breadSpawned);
    }
}
