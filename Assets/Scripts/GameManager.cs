using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool gameHasCleared = false;

    public GameObject gameOverUI;
    public GameObject gameClearUI;

    void Update()
    {
        if(Input.anyKeyDown && (gameHasEnded || gameHasCleared))
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
    

    public void ClearGame()
    {
        if(gameHasCleared == false)
        {
            gameHasCleared = true;
            Debug.Log("GAME Clear");
            GameClear();
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);

    }

    public void GameClear()
    {
        gameClearUI.SetActive(true);
    }

    public void Restart()
    {
        if (gameHasCleared)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
