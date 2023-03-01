using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _sleepTime;

    private WaitForSeconds _delayTime;
    private int _randomPosition;

    public void Start()
    {
        _delayTime = new WaitForSeconds(_sleepTime);
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            _randomPosition = Random.Range(0, _spawnPoints.Length);
            Instantiate(_prefab, _spawnPoints[_randomPosition].transform.position, Quaternion.identity);
            
            yield return _delayTime;
        }
    }
}
