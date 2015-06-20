using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject ui;
    public RectTransform bloodPanel;
    public RectTransform goPanel;
    public RectTransform gameOverPanel;
    public PlayerTankController playerController;

    private static GameController _instance;

    public bool gameOver = false;

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

        gameOverPanel = ui.transform.FindChild("GameOverPanel").GetComponent<RectTransform>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTankController>();
	}

    public void Update()
    {        
        if(Input.GetKey(KeyCode.Escape)){
            Quitter();
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

    public void Rejouer()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void GameOver()
    {
        gameOver = true;

        gameOverPanel.gameObject.SetActive(true);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
