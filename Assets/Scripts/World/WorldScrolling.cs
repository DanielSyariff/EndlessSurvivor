using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField] Vector2Int playerTilePosition;
    Vector2Int onTileGridPosition;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terrainTiles;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    private void Update()
    {
        playerTilePosition.x =  (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPosition.x = CalculatePositionOnAxis(onTileGridPosition.x, true);
            onTileGridPosition.y = CalculatePositionOnAxis(onTileGridPosition.y, false);
            UpdateTilesOnScreen();
        }
    }


    public void UpdateTilesOnScreen()
    {
        for (int pov_x = 0; pov_x < fieldOfVisionWidth; pov_x++)
        {
            for (int pov_y = 0; pov_y < fieldOfVisionHeight; pov_y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + pov_y, true);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(playerTilePosition.x + pov_x, playerTilePosition.y + pov_y);
            }
        }
    }

    public Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }
    public int CalculatePositionOnAxis(float currenValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currenValue >= 0)
            {
                currenValue = currenValue % terrainTileHorizontalCount;
            }
            else
            {
                currenValue = terrainTileHorizontalCount - 1 + currenValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currenValue >= 0)
            {
                currenValue = currenValue % terrainTileVerticalCount;
            }
            else
            {
                currenValue = terrainTileVerticalCount - 1 + currenValue % terrainTileVerticalCount;
            }
        }

        return (int)currenValue;

        //if (onTileGridPosition.x >= 0)
        //{
        //    onTileGridPosition.x = playerTilePosition.x % terrainTileHorizontalCount;
        //}
        //else
        //{
        //    onTileGridPosition.x = terrainTileHorizontalCount - 1 + playerTilePosition.x % terrainTileHorizontalCount;
        //}

        //if (onTileGridPosition.y >= 0)
        //{
        //    onTileGridPosition.y = playerTilePosition.y % terrainTileVerticalCount;
        //}
        //else
        //{
        //    onTileGridPosition.y = terrainTileVerticalCount - 1 + playerTilePosition.y % terrainTileVerticalCount;
        //}

        
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
