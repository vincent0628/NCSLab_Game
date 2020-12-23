using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public GameObject gameOverUI;

    void Update()
    {
        if(Input.anyKeyDown && gameHasEnded)
            Restart();
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            GameOver();
        }
    }
    
    public void GameOver()
    {
        gameOverUI.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
