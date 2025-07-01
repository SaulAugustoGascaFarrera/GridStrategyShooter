using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    public static GridSystemVisual Instance { get; private set; }

    [SerializeField] private Transform gridSystemVisualPrefab;

    private GridSystemVisualSingle[,] gridSystemVisualSingleArray;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!gridSystemVisualPrefab) return;

        gridSystemVisualSingleArray = new GridSystemVisualSingle[LevelGrid.Instance.GetWidth(),LevelGrid.Instance.GetHeight()];

        for(int x=0;x<LevelGrid.Instance.GetWidth();x++)
        {
            for(int z=0;z<LevelGrid.Instance.GetHeight();z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);

                Transform visualTransform = Instantiate(gridSystemVisualPrefab,LevelGrid.Instance.GetWorldPosition(gridPosition),Quaternion.identity);

                gridSystemVisualSingleArray[x,z] = visualTransform.GetComponent<GridSystemVisualSingle>();

               
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGridVisual();
    }

    public void HideAllVisualGridPosition()
    {
        for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
            {
                gridSystemVisualSingleArray[x,z].Hide();
            }
        }
    }

    public void ShowVisualGridPosition(List<GridPosition> gridPositionList)
    {
        foreach(GridPosition gridPosition in gridPositionList)
        {
            gridSystemVisualSingleArray[gridPosition.x,gridPosition.z].Show();
        }
    }

    private void UpdateGridVisual()
    {
        HideAllVisualGridPosition();
        ShowVisualGridPosition(UnitActionSystem.Instance.GetSelectedUnit().GetMoveAction().GetValidActionAtGridPosition());
    }
}
