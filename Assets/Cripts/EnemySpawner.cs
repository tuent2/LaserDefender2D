using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigS;
    [SerializeField] float TimeBetweenWaves = 0f;    
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;
    
    void Start()
    {
        StartCoroutine( SpawnEnemyWaves());   
    }

    public WaveConfigSO GetCurrentWave(){
        return currentWave;
    }
    IEnumerator SpawnEnemyWaves (){
        do {
            foreach (WaveConfigSO wave in waveConfigS){
            currentWave = wave;
            for(int i = 0 ; i < currentWave.GetEnemyCount() ; i++){
            Instantiate(currentWave.GetEnemyPrefab(i)
            ,currentWave.GetStartedWaypoint().position,
            Quaternion.identity,
            transform);
            yield return new WaitForSeconds(currentWave.getRandomSpawnsTime());
        }
        yield return new WaitForSeconds (TimeBetweenWaves);
        }
        }
        while (isLooping == true);
    }
}
