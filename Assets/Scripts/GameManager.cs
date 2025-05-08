using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemieCount = 10;
    
    [SerializeField] private TextMeshProUGUI enemieUI;    
    [SerializeField] private TextMeshProUGUI playerHealthUI;
    [SerializeField] private GameObject perdiste;
    [SerializeField] private GameObject ganaste;
    [SerializeField] private GameObject panel;
    [SerializeField] private PlayerHealth playerHealth;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        enemieUI.text = "Enemies Left: " + enemieCount;
        
    }


    private void Update()
    {
        playerHealthUI.text = "Lifes: " + playerHealth.Health.ToString();

        if(playerHealth.Health <= 0)
        {
            YouLose();
        }

        if(enemieCount <= 0 )
        {
            YouWin();
        }
    }



    private void YouLose()
    {
        panel.SetActive(true);
        perdiste.SetActive(true);
        
    }

    private void YouWin()
    {
        panel.SetActive(true);
        ganaste.SetActive(true);
    }

    public void ResetGame()
    {
        panel.SetActive(false);
        perdiste.SetActive(false);
        ganaste.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void UpdateEnemieCounter()
    {

        enemieUI.text = "Enemies Left: " + enemieCount;
    }

    //Metodo para ganar


    //Metodo para perder

    //Metodo para UI


}
