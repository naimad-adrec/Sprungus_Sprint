using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Tile_Counter : MonoBehaviour
{
    [SerializeField] Tilemap groundTilemap;
    private int grassCount = 0;
    public int finalGrassCount;
    private int fungusCount = 0;
    public int finalFungusCount;
    private int dirtCount = 0;
    private int finalDirtCount;

    [SerializeField] private int leftx = -15; //matches the dimensions of the grid
    [SerializeField] private int rightx = +14;
    [SerializeField] private int downy = -8;
    [SerializeField] private int upy = +7;

    private List<int> TileCount()
    {
        //for area 16 x 30 check what tile is in each unit
        for (int x = leftx; x <= rightx; x++)
        {
            for (int y = downy; y <= upy; y++)
            {
                Vector3Int m_Position = new Vector3Int(x, y, 0);
                TileBase tileProperties = groundTilemap.GetTile(m_Position);
                Debug.Log("Before error?");
                Debug.Log(tileProperties);
                if (tileProperties.name == "Tiles_3" || tileProperties.name == "Tiles_12")
                {
                    grassCount += 1;
                }
                else if (tileProperties.name == "Tiles_29" || tileProperties.name == "Tiles_21")
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
    }
}
