using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateHandler : MonoBehaviour
{
    public Canvas headsUpDisplay;
    public Canvas pauseMenu;




    public Canvas gameOverMenu;
    public Text finalScore;
    
    
    


    public void PauseGame()
    {
        Time.timeScale = 0;
        SwitchCanvas(pauseMenu);
        FindObjectOfType<PlayerController>().enabled = false;
        FindObjectOfType<CustomerAssistance>().enabled = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        SwitchCanvas(headsUpDisplay);
        FindObjectOfType<PlayerController>().enabled = true;
        FindObjectOfType<CustomerAssistance>().enabled = true;
    }


    public void EndGame()
    {
        Time.timeScale = 0;
        SwitchCanvas(gameOverMenu);
        FindObjectOfType<PlayerController>().enabled = false;
        FindObjectOfType<CustomerAssistance>().enabled = false;

        PopulateWinScreen();
    }

    
    
    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (headsUpDisplay.gameObject.activeSelf == true)
            {
                PauseGame();
            }
            else if(pauseMenu.gameObject.activeSelf == true)
            {
                ResumeGame();
            }
        }
    }
    

    void SwitchCanvas(Canvas c)
    {
        headsUpDisplay.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(false);
        c.gameObject.SetActive(true);
    }


    public void PopulateWinScreen()
    {
        finalScore.text = GetComponent<ScoreHandler>().score.ToString();
    }
}
