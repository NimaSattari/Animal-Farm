using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range( 0.1f , 120f)]
    [SerializeField] float secondsBetweemSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spwnedEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spwnedEnemies.text = score.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            score++;
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            spwnedEnemies.text = score.ToString();
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweemSpawns);
        }
    }
}
