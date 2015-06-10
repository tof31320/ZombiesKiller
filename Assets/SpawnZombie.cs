using UnityEngine;
using System.Collections;

public class SpawnZombie : MonoBehaviour {

    public GameObject zombiePrefab;

    public Transform player;

    public bool spawning = true;

    public float spawnInterval = 5f;

	// Update is called once per frame
	void Start () {
        StartCoroutine("SpawnANewZombie");
	}

    IEnumerator SpawnANewZombie()
    {
        while(spawning){
            GameObject zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity) as GameObject;            

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
