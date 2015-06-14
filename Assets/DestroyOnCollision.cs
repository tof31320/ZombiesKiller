using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

    public GameObject explosionPrefab;

    public void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player")){

            Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
