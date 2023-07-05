using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawnManager : MonoBehaviour
{
    private float range = 10.0f;
    [SerializeField] private GameObject humanGameObject;
    [SerializeField] private GameObject policeman;
    private int numberOfPeople;
    private int numberOfPolice;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        numberOfPeople = LevelData.numberOfPeople;
        numberOfPolice = LevelData.numberOfPolice;
        SpawnHumans(numberOfPeople, humanGameObject);
        SpawnHumans(numberOfPolice, policeman);
    }

    private void SpawnHumans(int numberOfPeople, GameObject human)
    {
        for(int i = 0; i<= numberOfPeople; i++)
        {
            float radius = 5f;
            Instantiate(human, new Vector3(RandomNavMeshLocation(radius).x, 0, RandomNavMeshLocation(radius).z), Quaternion.identity);
        }
    }

    private Vector3 RandomNavMeshLocation(float radius)
    {
        Vector3 randomPoint = Random.insideUnitSphere * radius;
        UnityEngine.AI.NavMeshHit hit;
        if(UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            return randomPoint;
        }
        else
        {
            return RandomNavMeshLocation(radius);
        }
    }
}
