using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    private int _width;
    private int _height;
    private int _x, _y;

    public int GetX => _x;
    public int GetY => _y;

    public Cell (int width, int height, int x, int y)
    {
        _width = width;
        _height = height;
        _x = x;
        _y = y;
    }

    public override string ToString()
    {
        return "X: " + _x + " Y: " + _y;
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * _width, 0,  y * _height);
    }

    public void Draw90()
    {
        Debug.DrawLine(GetWorldPosition(_x, _y), GetWorldPosition(_x, _y + 1), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(_x, _y), GetWorldPosition(_x + 1, _y), Color.white, 100f);
    }
}
