using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//A SIMPLE AND QUICK SOLUTION FOR AI PATHFINDING USING A* LOGIC
//DOESN'T WORK WITH LONG DISTANCES
public class SimpleAStarPath : MonoBehaviour
{
    [SerializeField] ShipTargetMover mover;
    Tilemap sea;
    PlayerShipInput target;
    [SerializeField] List<Vector2> path = new List<Vector2>();

    private void Awake()
    {
        //target = player;
        target = FindObjectOfType<PlayerShipInput>();
        sea = GameObject.FindGameObjectWithTag("Sea").GetComponent<Tilemap>();
        

        InvokeRepeating("LookForPlayer", 0f, 0.25f);
        

    }

    IEnumerator FormPathCoroutine(Vector2 startPos, Vector2 destPos)
    {
        if(target)
        {
            path = new List<Vector2>();
            Vector2 firstPos = GetNearestTileFromPosition(ConvertTilesToWorldPosition(GetAdjacentTiles(startPos)), destPos);
            path.Add(firstPos);

            float distanceFromTarget = Vector2.Distance(path[path.Count - 1], destPos);


            while (distanceFromTarget > 1.5f)
            {
                Vector2 nextPos = GetNearestTileFromPosition(ConvertTilesToWorldPosition(GetAdjacentTiles(path[path.Count - 1])), destPos);
                path.Add(nextPos);
                distanceFromTarget = Vector2.Distance(path[path.Count - 1], destPos);
                yield return new WaitForEndOfFrame();
            }

            path.Add(destPos);
            if (mover.path.Count == 0)
            {
                mover.DefinePath(path);
            }
            else if (mover.path[0] != path[0])
            {
                mover.DefinePath(path);
            }
        }
    }

    void LookForPlayer()
    {
        StopAllCoroutines();
        if (target)
        {   
            StartCoroutine(FormPathCoroutine(transform.position, target.transform.position));
        }

    }

    List<Vector2> ConvertTilesToWorldPosition(List<Vector3Int> tilesPos)
    {
        List<Vector2> worldPos = new List<Vector2>();
        foreach(Vector3Int tile in tilesPos)
        {
            worldPos.Add(sea.CellToWorld(tile));
        }

        return worldPos;
    }

    Vector2 GetNearestTileFromPosition(List<Vector2> tiles, Vector2 referencePos)
    {
        float bestDistance = Mathf.Infinity;
        Vector2 bestTile = Vector2.zero;
        foreach(Vector2 tile in tiles)
        {
            if(Vector2.Distance(referencePos, tile) < bestDistance)
            {
                bestDistance = Vector2.Distance(referencePos, tile);
                bestTile = tile;
            }
        }

        return bestTile;
    }


    public List<Vector3Int> GetAdjacentTiles(Vector3 position)
    {
        List<Vector3Int> adjacentTiles = new List<Vector3Int>();
        Vector3Int center = sea.WorldToCell(position);
        Tile centerTile = sea.GetTile<Tile>(center);
        if(centerTile)
        {
            for(int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    Vector3Int tempPosition = center;
                    tempPosition.x += x;
                    tempPosition.y += y;

                    if(center != tempPosition)
                    {
                        if(sea.GetTile(tempPosition))
                        adjacentTiles.Add(tempPosition);
                    }
                        

                }
            }
        }

        return adjacentTiles;

    }
}
