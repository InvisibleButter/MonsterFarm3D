using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private List<Cell> _cells;
    
    void Start()
    {
        InitGrid(10, 4);
    }

    private void InitGrid(int width, int height)
    {
        _cells = new List<Cell>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                _cells.Add(new Cell(5, 5, x, y));
            }
        }

        foreach (Cell cell in _cells)
        {
            Debug.Log(cell.ToString());
        }

        VisualizeGrid(width, height);
    }

    private void VisualizeGrid(int w, int h)
    {
        Debug.DrawLine(new Vector3(0, 0, h) * 5, new Vector3(w, 0, h) * 5, Color.white, 100f);
        Debug.DrawLine(new Vector3(w, 0, 0) * 5, new Vector3(w, 0, h) * 5, Color.white, 100f);
        foreach (Cell cell in _cells)
        {
            cell.Draw90();
        }
    }
}
