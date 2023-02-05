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
    
    public void Setup()
    {
        gameObject.SetActive(true);

        slider.maxValue = (tile_Counter.finalFungusCount += tile_Counter.finalGrassCount);
        slider.value = tile_Counter.finalGrassCount;

        if (tile_Counter.finalFungusCount > tile_Counter.finalGrassCount)
        {
            PlayerWins.text = "FUNGI WINS";
        }
        if (tile_Counter.finalFungusCount < tile_Counter.finalGrassCount)
        {
            PlayerWins.text = "SPROUT WINS";
        }
        else
        {
            PlayerWins.text = "ITS A TIE";
        }       
    }

    public void RePlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
