using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Return_Menu : MonoBehaviour
{
    private Text text;
    public Tile_Counter tile_Counter;
    public Slider slider;

    public void Start()
    {
        slider.maxValue = (tile_Counter.finalFungusCount + tile_Counter.finalGrassCount);
        slider.value = tile_Counter.finalGrassCount;
        if (tile_Counter.finalFungusCount > tile_Counter.finalGrassCount)
        {
            text.text = "FUNGI WINS";
        }
        if (tile_Counter.finalFungusCount < tile_Counter.finalGrassCount)
        {
            text.text = "SPROUT WINS";
        }
        else
        {
            text.text = "ITS A TIE";
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
