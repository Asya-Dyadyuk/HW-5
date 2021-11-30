using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    bool gameHasEnded = false;

    public float restarDelay = 1f;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            gameOverScreen.Setup("Game Over, You lose.");
        }
    }

    public void setGameHasEnded()
    {
        gameHasEnded = true;
    }

    public void CompleteLevel()
    {
        Debug.Log("Level Won!");
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverScreen.Setup("Game Over, You Win");
        }
    }

    void Restart()
    {
        // SceneManager
    }

}
