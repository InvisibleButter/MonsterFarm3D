using UnityEngine;

[ExecuteInEditMode]
public class GridManager : MonoBehaviour
{
    private Cell[,] _cells;
    public Vector2 MapSize;
    public int CellSize;

    public static GridManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        { 
            Instance = this;
        }
    }

    void Start()
    {
        InitGrid((int)MapSize.x, (int)MapSize.y);
    }

    private void InitGrid(int width, int height)
    {
        _cells = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                _cells[x,y] = new Cell(CellSize, CellSize, x, y);
            }
        }

        foreach (Cell cell in _cells)
        {
            Debug.Log(cell.ToString());
        }

        VisualizeGrid();
    }

    private void VisualizeGrid()
    {
        Debug.DrawLine(new Vector3(0, 0, (int)MapSize.y) * CellSize, new Vector3((int)MapSize.x, 0, (int)MapSize.y) * CellSize, Color.white, 100f);
        Debug.DrawLine(new Vector3((int)MapSize.x, 0, 0) * CellSize, new Vector3((int)MapSize.x, 0, (int)MapSize.y) * CellSize, Color.white, 100f);
        foreach (Cell cell in _cells)
        {
            cell.Draw90();
        }
    }

    private void GetXY(Vector3 worldPos, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPos.x / CellSize);
        y = Mathf.FloorToInt(worldPos.z / CellSize);
    }

    public void SetDebugVal(Vector3 worldPos, int val)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        SetDebugVal(x, y, val);
    }

    private void SetDebugVal(int x, int y, int debugVal)
    {
        if(x >= 0 && x < (int)MapSize.x && y >=0 && y < (int)MapSize.y)
        {
            _cells[x, y].DebugVal = debugVal;
            Debug.Log(_cells[x, y].ToString());
        }
    }

    public void GetDebugVal(int x, int y)
    {
        if (x >= 0 && x < (int)MapSize.x && y >= 0 && y < (int)MapSize.y)
        {
            Debug.Log("val: " + _cells[x, y].ToString());
        }
    }
    private void GetDebugVal(Vector3 worldPos)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        GetDebugVal(x, y);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                SetDebugVal(hit.point, 1);
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 worldPos;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GetDebugVal(hit.point);
            }
        }
    }
}
