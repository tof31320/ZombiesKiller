using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject ui;
    public RectTransform bloodPanel;
    public RectTransform goPanel;
    public PlayerTankController playerController;

    private static GameController _instance;

    public static GameController instance {
        get {
            if(_instance == null){
                _instance = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();                    
            }
            return _instance;
        }
    }

	// Use this for initialization
	void Start () {
        ui.SetActive(true);

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTankController>();
	}

    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }

        /*if(playerController.healh <= 0){
            GameOver();
        }*/
    }

    public void OnPlayerHit()
    {
        Animator animator = bloodPanel.GetComponent<Animator>();
        animator.Play("Impact");
        
        print("Impact");
    }

    public void GameOver()
    {
        
    }
}
