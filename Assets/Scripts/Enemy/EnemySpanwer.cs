using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpanwer : MonoBehaviour
{
    public float SpawnDuration = 1;
    public int MaxSpawn = 20;
    public float Radius = 2;
    public List<GameObject> Prefabs = new List<GameObject>();
    public List<float> SpawnWeight = new List<float>();
    public List<GameObject> SpawnedEnemies = new List<GameObject>();
    float lastSpawnTime = 0;
    float nextSpawnDuration = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i < SpawnedEnemies.Count; i++)
        {
            if (!SpawnedEnemies[i])
                SpawnedEnemies.RemoveAt(i--);
        }
        if (SpawnedEnemies.Count > MaxSpawn)
            return;
        if(Time.time- lastSpawnTime > nextSpawnDuration)
        {
            lastSpawnTime = Time.time;
            nextSpawnDuration = SpawnDuration * (0.5f + Random.value);
            var totalWeight = SpawnWeight.Sum();
            for(var i=0;i<Prefabs.Count;i++)
            {
                var prob = SpawnWeight[i] / totalWeight;
                if(Random.value<prob)
                {
                    var enemy = Instantiate(Prefabs[i], transform.position + (Radius * Random.insideUnitCircle).ToVec3(0), Quaternion.Euler(0, 0, Random.value * 360));
                    SpawnedEnemies.Add(enemy);
                    return;
                }
                totalWeight -= SpawnWeight[i];
            }
        }
    }
}