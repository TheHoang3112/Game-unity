using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(EnemyShipRoutine());
        StartCoroutine(PowerUpRoutine());
        
    }
    IEnumerator EnemyShipRoutine()
    {
        while (true)
        {
            Instantiate(_enemyShipPrefab, new Vector3(Random.Range(-6f, 6f), 4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
    
    IEnumerator PowerUpRoutine()
    {
        while (true)
        {
            int RandomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[RandomPowerUp], new Vector3(Random.Range(-6f, 6f), 4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
