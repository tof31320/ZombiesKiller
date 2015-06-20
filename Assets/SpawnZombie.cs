using UnityEngine;
using System.Collections;

public class SpawnZombie : MonoBehaviour {

    public GameObject zombiePrefab;

    public Transform player;

    public bool spawning = true;

    public float spawnInterval = 5f;

    public int nbZombiesToSpawn = 10;
    private int _nbZombiesSpawn = 0;

	// Update is called once per frame
	void Start () {
        StartCoroutine("SpawnANewZombie");
	}

    IEnumerator SpawnANewZombie()
    {
        while(_nbZombiesSpawn < nbZombiesToSpawn){
            GameObject zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity) as GameObject;

            _nbZombiesSpawn++;            

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
