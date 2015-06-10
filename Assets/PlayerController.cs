using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Ray _ray;
    private RaycastHit hit;

    public Transform sphere;

    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;

    public float shootForce = 10f;
    public Transform shootingPoint; 
    public GameObject bulletPrefab;

    public bool infinitAmmo = false;
    public int healh = 100;
    public int bulletsInChargeur = 5;
    public int nbChargeurs = 12;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out hit, 1000f, 1 << LayerMask.NameToLayer("Ground"))){
            LookAt(new Vector3(hit.point.x, hit.point.y, hit.point.z));
            //print("LookAt..");
        }*/
       
        transform.Rotate(transform.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);

        transform.Translate(transform.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed, Space.World);

        if(Input.GetMouseButtonDown(0)){
            Shoot();

        }else if(Input.GetMouseButtonDown(1)){
            Reload();
        }
	}

    void LookAt(Vector3 position)
    {
        Vector3 direction = (position-  transform.position).normalized;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, transform.up);
        //transform.position = position
        //transform.LookAt(sphere);
        //sphere.transform.position = position;
    }

    public void Shoot()
    {
        if (bulletsInChargeur > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);

            if (!infinitAmmo)
            {
                bulletsInChargeur--;
            }

            Destroy(bullet, 5f);
        }
    }

    public void Reload()
    {
        if(nbChargeurs > 0){
            if(!infinitAmmo){
                nbChargeurs--;
            }
            bulletsInChargeur = 5;
        }
    }

    public void Bite(ZombieController zombie)
    {
        healh -= zombie.biteDamage;
        if(healh <= 0f){
            Die();
        }
    }

    public void Die()
    {
        // Game Over !
    }
}
