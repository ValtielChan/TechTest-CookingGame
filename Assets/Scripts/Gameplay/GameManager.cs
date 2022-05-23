using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Attached Health status
    /// </summary>
    [SerializeField]
    private HealthStatus playerHealth;

    /// <summary>
    /// Reference to the Spawn Manager
    /// </summary>
    [SerializeField]
    private SpawnManager spawnManager;

    /// <summary>
    /// Reference to the Tutorial
    /// </summary>
    [SerializeField]
    private Tutorial tutorial;

    /// <summary>
    /// Reference to idle canvas
    /// </summary>
    [SerializeField]
    private GameObject idleCanvas;

    /// <summary>
    /// Reference to in game canvas
    /// </summary>
    [SerializeField]
    private GameObject ingameCanvas;

    /// <summary>
    /// Reference to tears effect
    /// </summary>
    [SerializeField]
    private TearsEffect tearsEffect;

    /// <summary>
    /// Debug bool to play the tutorial everytime
    /// </summary>
    [SerializeField]
    private bool debugForceTutorial;

    /// <summary>
    /// Has the game started
    /// </summary>
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorial.OnTutorialEnd += StopGame;

        if (debugForceTutorial)
        {
            PlayerPrefs.SetInt("firstTime", 0);
        }
    }

    /// <summary>
    /// Start the game
    /// </summary>
    public void StartGame()
    {
        if (!gameStarted)
        {
            // Play the tutorial of it's the first time
            if (!PlayerPrefs.HasKey("firstTime") || PlayerPrefs.GetInt("firstTime") == 0)
            {
                tutorial.StartTutorial();
                PlayerPrefs.SetInt("firstTime", 1);
            }
            else
            {
                // Start spawning enemy and stop if the player dies
                playerHealth.OnDie += StopGame;
                spawnManager.StartSpawning();
                ingameCanvas.SetActive(true);
            }

            gameStarted = true;
            idleCanvas.SetActive(false);
            
        }
    }

    /// <summary>
    /// Stop the game
    /// </summary>
    private void StopGame()
    {
        spawnManager.StopSpawning();
        playerHealth.Heal(playerHealth.MaxHealth); // Full healing for the next game
        tearsEffect.Wipe(); // Stop tears effect
        gameStarted = false;

        // Make all enemies disappear
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(go);
        }

        idleCanvas.SetActive(true);
        ingameCanvas.SetActive(false);
    }
}
