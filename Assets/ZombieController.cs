using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

    public float life = 1f;
    public float hitDamage = 0.5f;

    public NavMeshAgent agent;
    public Rigidbody rb;
    public Transform player;

    public GameObject impactPrefab;

    public float lastBiteTime = 0f;
    public float bitingTimeInterval = 2f;
    public int biteDamage = 5;

    public bool dead = false;

    private Animator _animator;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(1f, 6f);
        biteDamage = Random.Range(5, 20);
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!dead){
            agent.SetDestination(player.position);
            //transform.LookAt(player);
        }
	}

    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Bullet")){
            // Hit
            Hit(collision.gameObject, collision.transform.position);
        }
        else if (collision.gameObject.CompareTag("Player")
        && !dead)
        {
            BitePlayer(collision.gameObject.GetComponent<PlayerController>());
        }
    }

    public void Hit(GameObject bullet, Vector3 hitPoint)
    {
        // TODO Recul de l'impact        
        if(!dead){
            life -= hitDamage;

            if(life < 0f){
                life = 0f;
                Die();
            }    
        }
        Destroy(bullet);
    }

    public void Die()
    {
        dead = true;
        //_animator.SetBool("dead", true);
        //GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<MeshRenderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        agent.speed = 0f;
        Destroy(gameObject, 10f);
    }

    public void BitePlayer(PlayerController player)
    {
        if(player == null){
            return;
        }
        if(Time.time - lastBiteTime > bitingTimeInterval){

            player.Bite(this);

            lastBiteTime = Time.time;
        }
    }
}
