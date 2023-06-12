using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class UI_control : MonoBehaviour
{
    public TMP_Text timer_text;
    public GameObject defeatUI;
    public GameObject victoryUI;

    public bool timerRunning = false;
    public bool GameOver = false;
    public bool Victory = false;



    private float timeElapsed = 0;
   


    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
        defeatUI.SetActive(false);
        victoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning)
        {
            timeElapsed += Time.deltaTime;
        }

        //Conversión de unidades.
        float minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = Mathf.FloorToInt(timeElapsed % 60);
        float milis = (timeElapsed % 1) * 1000;

        timer_text.text = "Time: " + string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milis);
    }

    public void GameOverUI()
    {
        timerRunning = false;
        GameOver = true;

        defeatUI.SetActive(true);
    }

    public void VictoryUI()
    {
        timerRunning = false;
        Victory = true;

        victoryUI.SetActive(true);
    }

    public void ResetGame()
    {
        //Cargamos la escena actual para reiniciar el juego. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        //Salimos del juego.
        Application.Quit();
    }
}
