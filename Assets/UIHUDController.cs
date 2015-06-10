using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHUDController : MonoBehaviour {

    public Color goodHealthColor = Color.green;
    public Color warningHealthColor = new Color(1f, 0.3f, 0.3f, 1f);
    public Color alertHealthColor = Color.red;

    public Text txtHealth;
    public Text txtAmmo;

    public PlayerController playerController;
	
	// Update is called once per frame
	void Update () {
        txtHealth.text = playerController.healh + "%";
        if(playerController.healh < 50f){
            txtHealth.color = warningHealthColor;
        }else if(playerController.healh < 10f){
            txtHealth.color = alertHealthColor;
        }
        else
        {
            txtHealth.color = goodHealthColor;
        }

        txtAmmo.text = playerController.bulletsInChargeur + " / " + playerController.nbChargeurs;
        if (playerController.bulletsInChargeur == 0
        || playerController.nbChargeurs < 2)
        {
            txtAmmo.color = alertHealthColor;
        }
        else
        {
            txtAmmo.color = Color.white;
        }
	}
}
