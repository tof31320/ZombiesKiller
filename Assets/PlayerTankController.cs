using UnityEngine;
using System.Collections;

public class PlayerTankController : TankController {

    private Ray _ray;
    private RaycastHit hit;
    
	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out hit, 1000f, 1 << LayerMask.NameToLayer("Ground")))
        {
            LookAt(new Vector3(hit.point.x, hit.point.y, hit.point.z));
        }

        transform.Rotate(transform.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        transform.Translate(transform.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed, Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }    

    /*
    public void Bite(AIController zombie)
    {
        GameController.instance.OnPlayerHit();

        // recul de la morsure
        rb.AddForce((transform.position - zombie.transform.position).normalized * 25f, ForceMode.Impulse);

        healh -= zombie.biteDamage;
        if(healh <= 0f){
            Die();
        }
    }*/

    /*
    public void Die()
    {
        // Game Over !
    }*/
}
