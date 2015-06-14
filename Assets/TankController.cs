using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
    
    public Rigidbody rb;

    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;
    public float shootForce = 10f;
    
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Transform tourelle;

    public float life = 1f;    
    public bool dead = false;

    public ParticleSystem psShoot;
    private RaycastHit _hit;

    public Color startColor = Color.white;
    private Color _color = Color.white;
    public Color color
    {
        get { return _color; }
        set
        {
            _color = value;

            MeshRenderer[] renderer = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].material.color = _color;
            }
        }
    }

	// Use this for initialization
	void Awake () {        
        rb = GetComponent<Rigidbody>();
        tourelle = transform.FindChild("Tourelle");
        color = startColor;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(life <= 0f && !dead){
            DestroyTank();
        }
	}

    public void LookAt(Vector3 position)
    {
        Vector3 direction = (position - tourelle.position).normalized;
        int angle = (int)(Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90f);

        Quaternion rotation = Quaternion.AngleAxis(angle, tourelle.up);
        tourelle.rotation = Quaternion.Lerp(tourelle.rotation, Quaternion.Euler(0f, rotation.eulerAngles.y, 0f), 0.1f);
    }

    public void Shoot()
    {
        psShoot.Emit(10);

        GameObject bullet = GameObject.Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(tourelle.right * shootForce, ForceMode.Impulse);
        Destroy(bullet, 5f);
    }

    public void DestroyTank()
    {
        dead = true;

        color = Color.black;

        Destroy(gameObject, 10f);
    }

    public void OnCollisionWithBullet(BulletModel bullet, Vector3 hitpoint)
    {
        // Recul de l'impact
        rb.AddForce((transform.position - bullet.transform.position).normalized * 10f, ForceMode.Impulse);

        if(!dead){
            life = Mathf.Clamp(life - bullet.damageValue, 0f, 1f);
        }
    }

    public void OnCollisionWithTank(TankController other)
    {

    }
}
