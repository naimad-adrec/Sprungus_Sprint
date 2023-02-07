using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Power_Up_Randomizer : MonoBehaviour
{
    [SerializeField] public float minWait;
    [SerializeField] public float maxWait;

    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap rockTilemap;
    [SerializeField] private Tile rock;

    [SerializeField] private int numRocks = 10;

    //dimensions of the grid
    private int leftx = -10;
    private int rightx = 10;
    private int downy = -7;
    private int upy = 7;

    private int xCoord;
    private int yCoord;

    private bool isSpawning;
    private bool spawned;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    [SerializeField] private GameObject Pitfall;
    [SerializeField] private GameObject Fertilizer;
    [SerializeField] private GameObject Water_Drop;
    [SerializeField] private GameObject Apple;
    [SerializeField] private GameObject Bee;

    private void Start()
    {
        for (int i = 0; i < numRocks; i++) //spawns 10 rocks at random locations
        {
            xCoord = Random.Range(-10, 10);
            yCoord = Random.Range(-7, 7);
                Vector3Int m_Position = new Vector3Int(xCoord, yCoord, 0);
                TileBase tileProperties = groundTilemap.GetTile(m_Position);
            rockTilemap.SetTile(m_Position, rock);
            if ((tileProperties.name == "Tiles_4") || (tileProperties.name == "Tiles_5") ||
                (tileProperties.name == "Tiles_6") || (tileProperties.name == "Tiles_13") || (tileProperties.name == "Tiles_14") ||
                (tileProperties.name == "Tiles_15") || (tileProperties.name == "Tiles_22") || (tileProperties.name == "Tiles_23") ||
                (tileProperties.name == "Tiles_24") || (tileProperties.name == "Tiles_30") || (tileProperties.name == "Tiles_31") ||
                (tileProperties.name == "Tiles_32"))
            {
                    //spawn the rock
                rockTilemap.SetTile(m_Position, rock);
            }
        }
    }

    private void Update()
    {
        if (!isSpawning)
        {
            float timer = Random.Range(minWait, maxWait);
            Invoke("SpawnObject", timer);
            isSpawning = true;
        }
    }

    private void SpawnObject()
    {
        // Code to spanw your Prefab here

        int xCoord = Random.Range(leftx, rightx);
        int yCoord = Random.Range(downy, upy);
        int choice;
        spawned = false;
        while (spawned == false)
        {
            Vector3Int m_Position = new Vector3Int(xCoord, yCoord, 0);
            TileBase tileProperties = groundTilemap.GetTile(m_Position);

                //spawn the powerup
                choice = Random.Range(0, 5);
                if (choice == 0)
                {
                    Instantiate(Pitfall, m_Position, Quaternion.identity);
                }
                else if (choice == 1)
                {
                    Instantiate(Fertilizer, m_Position, Quaternion.identity);
                }
                else if (choice == 2)
                {
                    Instantiate(Water_Drop, m_Position, Quaternion.identity);
                }
                else if (choice == 3)
                {
                    Instantiate(Bee, m_Position, Quaternion.identity);
                }
                else if (choice == 4)
                {
                    Instantiate(Apple, m_Position, Quaternion.identity);
                }
                spawned = true;
        }

        isSpawning = false; //end of function
    }
}