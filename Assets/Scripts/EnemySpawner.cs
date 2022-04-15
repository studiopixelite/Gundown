using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        // Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5);
        Instantiate(enemy, transform.position, Quaternion.identity);
       
    }
}
