using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevel : MonoBehaviour
{
    public Tilemap Floor;
    public TilemapCollider2D tc2d;

    public TileBase wallTile;
    public TileBase floorTile;
    //public GameObject startTile;
    //public GameObject goalTile;

    public readonly int Length = 6; // each quad is 6 x 11 whole tiles
    public readonly int Width = 11;
    private List<int> xSpots;
    private List<int> ySpots;

    private List<Vector3> startingSpots; // the floorTiles which were the start or end of sequences (always on the border of the game board)
    public List<Vector3> floorTiles;

    public GameObject Player;
    public GameObject Enemy;

    void LevelLayout(int level)
    {
        tc2d = GetComponent<TilemapCollider2D>(); ////

        xSpots = new List<int>();
        ySpots = new List<int>();
        startingSpots = new List<Vector3>();
        floorTiles = new List<Vector3>();
        for (int x = -Width; x < Width; x++) // think about a graph w/ 4 quadrants
        {
            for (int y = -Length; y < Length; y++)
            {
                // make each tile a wall to start
                Floor.SetTile(new Vector3Int(x, y, 0), wallTile);
                Floor.SetColliderType(new Vector3Int(x, y, 0), Tile.ColliderType.Sprite); //
            }
        }
        for (int i = 0; i < level; i++)
        {
            if (i % 2 == 0)
            {
                //Debug.Log("Even");  
                int yCor;
                do { yCor = Random.Range(-Length, Length); } while (ySpots.Contains(yCor)); // ensure that this coordinate hasn't yet been a starting spot
                Floor.SetTile(new Vector3Int(-Width, yCor, 0), floorTile);
                Floor.SetColliderType(new Vector3Int(-Width, yCor, 0), Tile.ColliderType.None); //
                floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(-Width, yCor, 0))); ////
                startingSpots.Add(Floor.GetCellCenterWorld(new Vector3Int(-Width, yCor, 0)));
                ySpots.Add(yCor);
                for (int xCor = -Width; xCor < Width - 1; xCor++)
                {
                    int next = Random.Range(0, 2);
                    if (next == 0 && yCor < Length && yCor > -Length)
                    {
                        int upOrDown = Random.Range(0, 2);
                        if (upOrDown == 0)
                        {
                            while (upOrDown == 0 && yCor > -Length + 1)
                            {
                                Floor.SetTile(new Vector3Int(xCor, --yCor, 0), floorTile); // tile down
                                Floor.SetColliderType(new Vector3Int(xCor, yCor, 0), Tile.ColliderType.None); //
                                floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, yCor, 0))); ////
                                upOrDown = Random.Range(0, 2);
                            }
                        }
                        else
                        {
                            while (upOrDown == 1 && yCor < Length - 1)
                            {
                                Floor.SetTile(new Vector3Int(xCor, ++yCor, 0), floorTile); // tile up
                                Floor.SetColliderType(new Vector3Int(xCor, yCor, 0), Tile.ColliderType.None); //
                                floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, yCor, 0))); ////
                                upOrDown = Random.Range(0, 2);
                            }
                        }
                        Floor.SetColliderType(new Vector3Int(xCor, yCor, 0), Tile.ColliderType.None); //
                        floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, yCor, 0))); ////
                    }
                    Floor.SetTile(new Vector3Int(xCor + 1, yCor, 0), floorTile);
                    Floor.SetColliderType(new Vector3Int(xCor + 1, yCor, 0), Tile.ColliderType.None); //
                    floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor + 1, yCor, 0))); ////
                    if (xCor + 1 == Width - 1)
                    {
                        startingSpots.Add(Floor.GetCellCenterWorld(new Vector3Int(Width - 1, yCor, 0))); // the last tile placed for this sequence
                    }
                }
            }
            else
            {
                //Debug.Log("Odd");
                int xCor;
                do { xCor = Random.Range(-Width, Width); } while (xSpots.Contains(xCor)); // ensure that this coordinate hasn't yet been a starting spot
                Floor.SetTile(new Vector3Int(xCor, -Length, 0), floorTile);
                Floor.SetColliderType(new Vector3Int(xCor, -Length, 0), Tile.ColliderType.None); //
                floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, -Length, 0))); ////
                startingSpots.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, -Length, 0)));
                xSpots.Add(xCor);
                for (int yCor = -Length; yCor < Length - 1; yCor++)
                {
                    int next = Random.Range(0, 2);
                    if (next == 0 && xCor < Width && xCor > -Width)
                    {
                        int rightOrLeft = Random.Range(0, 2);
                        if (rightOrLeft == 0)
                        {
                            while (rightOrLeft == 0 && xCor > -Width + 1)
                            {
                                Floor.SetTile(new Vector3Int(--xCor, yCor, 0), floorTile); // tile left
                                Floor.SetColliderType(new Vector3Int(xCor, yCor, 0), Tile.ColliderType.None); //
                                floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, yCor, 0))); ////
                                rightOrLeft = Random.Range(0, 2);
                            }
                        }
                        else
                        {
                            while (rightOrLeft == 1 && xCor < Width - 1)
                            {
                                Floor.SetTile(new Vector3Int(++xCor, yCor, 0), floorTile); // tile right
                                Floor.SetColliderType(new Vector3Int(xCor, yCor, 0), Tile.ColliderType.None); //
                                floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, yCor, 0))); ////
                                rightOrLeft = Random.Range(0, 2);
                            }
                        }
                        Floor.SetColliderType(new Vector3Int(xCor, yCor, 0), Tile.ColliderType.None); //
                        floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, yCor, 0))); ////
                    }
                    Floor.SetTile(new Vector3Int(xCor, yCor + 1, 0), floorTile);
                    Floor.SetColliderType(new Vector3Int(xCor, yCor + 1, 0), Tile.ColliderType.None); //
                    floorTiles.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, yCor + 1, 0))); ////
                    if (yCor + 1 == Length - 1)
                    {
                        startingSpots.Add(Floor.GetCellCenterWorld(new Vector3Int(xCor, Length - 1, 0))); // the last tile placed for this sequence
                    }
                }
            }
        }
    }

    public void SetupScene(int level)
    {
        LevelLayout(level); // generate wall and floor tile

        SpawnPlayer(); // find a spot to spawn the player

        SpawnEnemy(); // find a spot to spawn the enemy       
    }

    public void SpawnPlayer()
    {
        int index = Random.Range(0, startingSpots.Count);
        Vector3 spawn = startingSpots[index];
        startingSpots.Remove(startingSpots[index]); // remove from list (don't want player and enemy spawning on top of each other!)

        Player.transform.position = spawn; // starting location of the player object
    }

    public void SpawnEnemy()
    {
        int index = Random.Range(0, startingSpots.Count); // remove from list (don't want player and enemy spawning on top of each other!)
        Vector3 spawn = startingSpots[index];
        startingSpots.Remove(startingSpots[index]); // starting location of the enemy object

        Enemy.transform.position = spawn;
    }
}
