using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

    public GameObject explosionPrefab;

    public void OnCollisionEnter(Collision collision)
    {        
        GameObject explosion = Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity) as GameObject;
        Destroy(explosion, 2f);
        Destroy(gameObject);
    }
}
