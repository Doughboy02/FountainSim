using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutManager : MonoBehaviour {

    public Button LineShape;
    public Button GridShape;
    public Button CircleShape;
    public Button ArcShape;
    public Button CreateLayout;

    public InputField RowsInput;
    public InputField ColumnsInput;
    public InputField RowSpacingInput;
    public InputField ColumnSpacingInput;

    public Text CurrentShape;

    public GameObject StartMarker;
    public GameObject FountainParent;
    public List<GameObject> FountainList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        CurrentShape.text = "Line";
        CreateLayout.onClick.AddListener(delegate { DrawLine(); });
        SetVisibility(false, false, true, true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeShape(string name)
    {
        CurrentShape.text = name;

        switch(name)
        {
            case "Line":
                CreateLayout.onClick.AddListener(delegate { DrawLine(); });
                SetVisibility(false, false, true, true);
                break;

            case "Grid":
                CreateLayout.onClick.AddListener(delegate { DrawGrid(); });
                SetVisibility(true, true, true, true);
                break;

            case "Circle":
                CreateLayout.onClick.AddListener(delegate { DrawCircle(); });
                SetVisibility(false, false, true, true);
                break;

            case "Arc":
                CreateLayout.onClick.AddListener(delegate { DrawArc(); });
                break;
        }

        
    }

    public void DrawLine()
    {
        print("Draw Line");
        ClearFountainList();
        for(int i=0; i < int.Parse(ColumnsInput.text); i++)
        {
            GameObject newFountain = Instantiate(FountainParent);
            newFountain.transform.position = new Vector3(StartMarker.transform.position.x + i * float.Parse(ColumnSpacingInput.text), 0, StartMarker.transform.position.z);
            FountainList.Add(newFountain);
        }
    }

    public void DrawGrid()
    {
        print("Draw Grid");
        ClearFountainList();
        for (int i=0; i < int.Parse(RowsInput.text); i++)
        {
            for (int j = 0; j < int.Parse(ColumnsInput.text); j++)
            {
                GameObject newFountain = Instantiate(FountainParent);
                newFountain.transform.position = new Vector3(StartMarker.transform.position.x + j * float.Parse(ColumnSpacingInput.text), 0, StartMarker.transform.position.z + i * float.Parse(RowSpacingInput.text));
                FountainList.Add(newFountain);
            }
        }
    }

    public void DrawCircle()
    {
        print("Draw Circle");
        ClearFountainList();
        for (int i = 1; i <= int.Parse(ColumnsInput.text); i++)
        {
            GameObject newFountain = Instantiate(FountainParent);
            newFountain.transform.position = new Vector3(StartMarker.transform.parent.position.x + Mathf.Cos(Mathf.PI * 2 / int.Parse(ColumnsInput.text)*i) * float.Parse(ColumnSpacingInput.text), 0, StartMarker.transform.parent.position.z + Mathf.Sin(Mathf.PI * 2 / int.Parse(ColumnsInput.text)*i) * float.Parse(ColumnSpacingInput.text));
            FountainList.Add(newFountain);
        }
    }

    public void DrawArc()
    {
        print("Draw Arc");
    }

    public void ClearFountainList()
    {
        foreach (GameObject fountain in FountainList)
            Destroy(fountain);
        FountainList.Clear();
    }

    private void SetVisibility(bool rows, bool rowSpacing, bool col, bool colSpacing)
    {
        RowsInput.gameObject.SetActive(rows);
        RowSpacingInput.gameObject.SetActive(rowSpacing);
        ColumnsInput.gameObject.SetActive(col);
        ColumnSpacingInput.gameObject.SetActive(colSpacing);
    }
}
