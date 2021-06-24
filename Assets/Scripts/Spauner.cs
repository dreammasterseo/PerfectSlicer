using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spauner : MonoBehaviour
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _spawnDelay;


    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        while(true)
        {
           int foodNamber = Random.Range(0, _templates.Length);
           Instantiate(_templates[foodNamber], transform.position, Quaternion.identity);
           yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
