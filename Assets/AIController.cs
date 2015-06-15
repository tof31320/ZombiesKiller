﻿using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    public NavMeshAgent agent;
    public TankController tank;
    public Transform player;

	// Use this for initialization
	void Start () {
        tank = GetComponent<TankController>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = tank.moveSpeed;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (!tank.dead)
        {
            /*if(Time.time - lastShootTime > 0.5f){
                Shoot();
                lastShootTime = Time.time;
            }*/

            agent.SetDestination(player.position);
            //transform.LookAt(player);

            tank.LookAt(player.position);
        }
	}
    
    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
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
        rb.AddForce((transform.position - bullet.transform.position).normalized * 10f, ForceMode.Impulse);

        if (!dead)
        {
            life -= hitDamage;

            if (life < 0f)
            {
                life = 0f;
                Die();
            }
        }
    }*/

    /*public void Die()
    {
        dead = true;
        //_animator.SetBool("dead", true);
        //GetComponent<CapsuleCollider>().enabled = false;
        

        //rb.AddForce(transform.up * 12f, ForceMode.Impulse);
        //rb.velocity = Vector3.zero;
        agent.speed = 0f;
        Destroy(gameObject, 10f);
    }*/

    /*public void BitePlayer(PlayerController player)
    {
        if (player == null)
        {
            return;
        }

        //player.Bite(this);        
    }*/
}