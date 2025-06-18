using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefab;

    public int[] weight;
    public float counter = 1;
    void Start()
    {
        //StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0 && GameObject.FindGameObjectsWithTag("Gegner").Length < 5)
        {
            Instantiate(enemyPrefab[0], new Vector3(10, 6, 0), Quaternion.identity);
            counter = 1;
        }

    }

    /*IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
    }*/
}
