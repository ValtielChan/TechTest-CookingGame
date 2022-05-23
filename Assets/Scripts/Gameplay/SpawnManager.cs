using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /// <summary>
    /// List of active spawn zones int the scene
    /// </summary>
    [SerializeField]
    List<SpawnZone> spawnZones;

    /// <summary>
    /// Time spended spawning by this zone
    /// </summary>
    [SerializeField]
    float zoneTime;

    /// <summary>
    /// Current zone index in the list
    /// </summary>
    private int currentZone = 0;

    /// <summary>
    /// Timer to wait for the next zone
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForNextZone()
    {
        yield return new WaitForSeconds(zoneTime);
        SwitchZone();
    }

    /// <summary>
    /// Switch from one zone to another
    /// </summary>
    private void SwitchZone()
    {
        spawnZones[currentZone].StopSpawn();

        currentZone++;

        if(currentZone >= spawnZones.Count)
        {
            currentZone = 0;
        }

        spawnZones[currentZone].StartSpawn();

        StartCoroutine(WaitForNextZone());
    }

    /// <summary>
    /// Start spawning in the first zone
    /// </summary>
    public void StartSpawning()
    {
        SwitchZone();
    }

    /// <summary>
    /// Stop every spawning
    /// </summary>
    public void StopSpawning()
    {
        StopAllCoroutines();
        currentZone = 0;

        foreach (SpawnZone sz in spawnZones)
        {
            sz.StopSpawn();
        }
    }
}
