using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        EnemySpawnManager.GetInstance().SpawnEnemy();
    }
}
