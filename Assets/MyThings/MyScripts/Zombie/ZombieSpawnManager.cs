using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZombieSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    public static ZombieSpawnManager instance { get; private set; }
    public event EventHandler<EventArgs> OnHumanDeath;

    private void Awake()
    {
        instance = this;
    }

    public void KillHuman(Human humanToTransform)
    {
        if(humanToTransform != null)
        {
            Vector3 spawnPos = humanToTransform.transform.position;
            humanToTransform.anim.Play("Standing React Death Backward");
            OnHumanDeath?.Invoke(this, EventArgs.Empty);
            StartCoroutine(WaitBeforeSpawning(spawnPos, humanToTransform));

        }
    }

    private IEnumerator WaitBeforeSpawning(Vector3 spawnPos, Human humanToTransform)
    {
        if(humanToTransform != null)
        {
            yield return new WaitForSeconds(3.0f);
            if (humanToTransform != null && humanToTransform.canBeTurnedIntoAZombie)
            {   
                SpawnZombie(spawnPos);
            }
            if (humanToTransform != humanToTransform.humanCharacter != null)
            {
                Destroy(humanToTransform.gameObject);
            }

        }

    }
    private void SpawnZombie(Vector3 spawnPosition)
    {
        Instantiate(zombie, spawnPosition, Quaternion.identity);

    }
}
