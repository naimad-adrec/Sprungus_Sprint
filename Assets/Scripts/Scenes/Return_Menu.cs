using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Return_Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerWins;
    public Tile_Counter tile_Counter;
    [SerializeField] Slider slider;

    [SerializeField] Canvas resultCanvas;
    [SerializeField] Canvas gameCanvas;

    private void Start()
    {
        gameCanvas.enabled = true;
        resultCanvas.enabled = false;
    }

    public void changeCanvas()
    {
        gameCanvas.enabled = false;
        resultCanvas.enabled = true;

        slider.maxValue = (tile_Counter.finalFungusCount + tile_Counter.finalGrassCount);
        slider.value = tile_Counter.finalGrassCount;

        if (tile_Counter.finalFungusCount > tile_Counter.finalGrassCount)
        {
            PlayerWins.text = "FUNGUS WINS!";
        }
        else if (tile_Counter.finalFungusCount < tile_Counter.finalGrassCount)
        {
            PlayerWins.text = "SPROUT WINS";
        }
        else if (tile_Counter.finalFungusCount == tile_Counter.finalGrassCount)
        {
            PlayerWins.text = "ITS A TIE";
        }
        Debug.Log(tile_Counter.finalFungusCount);
        Debug.Log(tile_Counter.finalGrassCount);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
