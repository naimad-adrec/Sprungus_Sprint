using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Powerup_Randomization : MonoBehaviour
{
    [SerializeField] public float minWait;
    [SerializeField] public float maxWait;
    [SerializeField] Tilemap groundTilemap;
    [SerializeField] Tilemap rockTilemap;
    [SerializeField] private Tile rock;
    [SerializeField] private int numRocks = 10;
    //dimensions of the grid
    private int leftx = -11;
    private int rightx = +10;
    private int downy = -8;
    private int upy = +7;

    private bool isSpawning;
    private bool spawned = false;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    [SerializeField] private GameObject Pitfall;
    [SerializeField] private GameObject Fertilizer;
    [SerializeField] private GameObject Water_Drop;


    // This script will simply instantiate the Prefab when the game starts.
    //void Start()
    //{
    //    // Instantiate at position (0, 0, 0) and zero rotation.
    //    Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    //}

    void Awake()
    {
        isSpawning = false;
        Debug.Log("Starting");
        for (int i = 0; i < numRocks; i++) //spawns 10 rocks at random locations
        {


            int xCoord = Random.Range(leftx, rightx);
            int yCoord = Random.Range(downy, upy);
            spawned = false;

            while (spawned is false)
            {
                Vector3Int m_Position = new Vector3Int(xCoord, yCoord, 0);
                TileBase tileProperties = groundTilemap.GetTile(m_Position);


                rockTilemap.SetTile(m_Position, rock);

                if ((tileProperties.name == "Tiles_3") || (tileProperties.name == "Tiles_29") || (tileProperties.name == "Tiles_4") || (tileProperties.name == "Tiles_5") ||
                        (tileProperties.name == "Tiles_6") || (tileProperties.name == "Tiles_7") || (tileProperties.name == "Tiles_13") || (tileProperties.name == "Tiles_14") ||
                        (tileProperties.name == "Tiles_15") || (tileProperties.name == "Tiles_16") || (tileProperties.name == "Tiles_22") || (tileProperties.name == "Tiles_23") ||
                        (tileProperties.name == "Tiles_24") || (tileProperties.name == "Tiles_25") || (tileProperties.name == "Tiles_30") || (tileProperties.name == "Tiles_31") ||
                        (tileProperties.name == "Tiles_32") || (tileProperties.name == "Tiles_33"))
                {
                    //spawn the rock
                    rockTilemap.SetTile(m_Position, rock);
                    Debug.Log("Placing Rock");
                    spawned = true;
                }
            }
        }


    }
    //void start()
    //{
    //    Debug.Log("Starting");
    //    for (int i = 0; i < numRocks; i++) //spawns 10 rocks at random locations
    //    {
            

    //        int xCoord = Random.Range(leftx, rightx);
    //        int yCoord = Random.Range(downy, upy);
    //        spawned = false;
            
    //        while (spawned is false)
    //        {
    //            Vector3Int m_Position = new Vector3Int(xCoord, yCoord, 0);
    //            TileBase tileProperties = groundTilemap.GetTile(m_Position);
                

    //            rockTilemap.SetTile(m_Position, rock);

    //            if ((tileProperties.name == "Tiles_3") || (tileProperties.name == "Tiles_29") || (tileProperties.name == "Tiles_4") || (tileProperties.name == "Tiles_5") ||
    //                    (tileProperties.name == "Tiles_6") || (tileProperties.name == "Tiles_7") || (tileProperties.name == "Tiles_13") || (tileProperties.name == "Tiles_14") ||
    //                    (tileProperties.name == "Tiles_15") || (tileProperties.name == "Tiles_16") || (tileProperties.name == "Tiles_22") || (tileProperties.name == "Tiles_23") ||
    //                    (tileProperties.name == "Tiles_24") || (tileProperties.name == "Tiles_25") || (tileProperties.name == "Tiles_30") || (tileProperties.name == "Tiles_31") ||
    //                    (tileProperties.name == "Tiles_32") || (tileProperties.name == "Tiles_33"))
    //            {
    //                //spawn the rock
    //                rockTilemap.SetTile(m_Position, rock);
    //                Debug.Log("Placing Rock");
    //                spawned = true;
    //            }
    //        }
    //    }
    //}

    void Update()
    {
        if (!isSpawning)
        {
            float timer = Random.Range(minWait, maxWait);
            Invoke("SpawnObject", timer);
            isSpawning = true;
        }
    }

    void SpawnObject()
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
            if ((tileProperties.name == "Tiles_3") || (tileProperties.name == "Tiles_29") || (tileProperties.name == "Tiles_4") || (tileProperties.name == "Tiles_5") ||
                    (tileProperties.name == "Tiles_6") || (tileProperties.name == "Tiles_7") || (tileProperties.name == "Tiles_13") || (tileProperties.name == "Tiles_14") ||
                    (tileProperties.name == "Tiles_15") || (tileProperties.name == "Tiles_16") || (tileProperties.name == "Tiles_22") || (tileProperties.name == "Tiles_23") ||
                    (tileProperties.name == "Tiles_24") || (tileProperties.name == "Tiles_25") || (tileProperties.name == "Tiles_30") || (tileProperties.name == "Tiles_31") ||
                    (tileProperties.name == "Tiles_32") || (tileProperties.name == "Tiles_33"))
            {
                //spawn the powerup
                choice = Random.Range(0, 3);
                if(choice == 0)
                {
                    Instantiate(Pitfall, m_Position, Quaternion.identity);
                }
                else if(choice == 1)
                {
                    Instantiate(Fertilizer, m_Position, Quaternion.identity);
                }
                else if(choice == 2)
                {
                    Instantiate(Water_Drop, m_Position, Quaternion.identity);
                }
                //Instantiate(Pitfall, m_Position, Quaternion.identity);
                spawned = true;
            }
        }

        



        //for (int x = leftx; x <= rightx; x++)
        //{
        //    for (int y = downy; y <= upy; y++)
        //    {
        //        Vector3Int m_Position = new Vector3Int(x, y, 0);
        //        TileBase tileProperties = groundTilemap.GetTile(m_Position);
        //        if (tileProperties.name == "Tiles_3")
        //        {
        //            grassCount += 1;
        //        }
        //        else if (tileProperties.name == "Tiles_29")
        //        {
        //            fungusCount += 1;
        //        }
        //        else
        //        {
        //            dirtCount += 1;
        //        }
        //    }
        //}



        isSpawning = false; //end of function
    }



    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
