using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cheeseCounterText, wastedCounterText, mouseCounterText;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject[] spawners;
    [SerializeField] GameObject instructionUI;
    public int cheeseCounter, wasteCounter, mouseCounter;
    public bool gameOver = false;
    public AudioClip mouseEntry, cheeseEntry, punch;
    [HideInInspector] public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        cheeseCounter = 0;
        wasteCounter = 0;
        mouseCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cheeseCounterText.text = "Cheese Processed: " + cheeseCounter;
        wastedCounterText.text = "Cheese Wasted: " + wasteCounter;
        mouseCounterText.text = "Mice Sent Away: " + mouseCounter;

        if (gameOver)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(true);
        }

        instructionUI.SetActive(false);

        cheeseCounterText.gameObject.SetActive(true);
        wastedCounterText.gameObject.SetActive(true);
        mouseCounterText.gameObject.SetActive(true);
    }
}
