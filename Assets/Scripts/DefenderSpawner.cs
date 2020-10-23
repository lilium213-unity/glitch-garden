using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        if(defender != null)
            SpawnDefender(GetSquareClicked());
    }

    private void SpawnDefender(Vector3 position)
    {
        Defender newDefender = Instantiate(defender, position, Quaternion.identity);
    }

    private Vector3 SnapToGrid(Vector2 position)
    {
        Vector3 pointOnGrid = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), Mathf.RoundToInt(position.y));
        return pointOnGrid;
    }

    private Vector3 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    public void SetDefender(Defender defender)
    {
        this.defender = defender;
    }
}
