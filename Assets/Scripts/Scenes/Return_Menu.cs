using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Return_Menu : MonoBehaviour
{
    public Text winnerText;
    public Slider sproutAmount;

    public void SetUp(int winner)
    {
        gameObject.SetActive(true);
        winnerText.text = winner.ToString() + " WINS";
    }
    public void SliderWinner(int sproutA)
    {
        gameObject.SetActive(true);
        sproutAmount.value = sproutA;
    }
    public void RePlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("TitleUIscene");
    }
}
