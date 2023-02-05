using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Tile_Counter : MonoBehaviour
{
    [SerializeField] Tilemap groundTilemap;
    private int grassCount = 0;
    public int finalGrassCount;
    private int fungusCount = 0;
    public int finalFungusCount;
    private int dirtCount = 0;
    private int finalDirtCount;

    private List<int> TileCount()
    {
        //for area 16 x 30 check what tile is in each unit
        for (int x = -15; x < 15; x++)
        {
            for (int y = -8; y < 8; y++)
            {
                Vector3Int m_Position = new Vector3Int(x, y, 0);
                TileBase tileProperties = groundTilemap.GetTile(m_Position);
                if (tileProperties.name == "Tiles_3")
                {
                    grassCount += 1;
                }
                else if (tileProperties.name == "Tiles_29")
                {
                    fungusCount += 1;
                }
                else
                {
                    dirtCount += 1;
                }
            }
        }
        List<int> counts = new List<int>
        {
            grassCount,
            fungusCount,
            dirtCount
        };
        return counts;
    }

    public void GameOver()
    {
        List<int> overallCount = TileCount();
        finalGrassCount = overallCount[0];
        finalFungusCount = overallCount[1];
        finalDirtCount = overallCount[2];
        SwitchScene();

    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(2);
    }
}
