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

    public InputField X1Input;
    public InputField Y1Input;
    public InputField X2Input;
    public InputField Y2Input;
    public InputField DeviceAmountInput;
    public InputField HeightInput;
    public InputField WidthInput;
    public InputField AngleInput;
    public InputField RowsInput;
    public InputField ColumnsInput;
    public InputField RowSpacingInput;
    public InputField ColumnSpacingInput;
    public InputField RadiusSpacingInput;

    public Text CurrentShape;

    public Transform CamOrigin;
    public GameObject FountainParent;
    public List<GameObject> FountainList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        CurrentShape.text = "Line";
        CreateLayout.onClick.AddListener(delegate { DrawLine(); });
        SetVisibility(true, true, true, true, true, false, false, false, false, false, false, false, false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeShape(string name)
    {
        CurrentShape.text = name;
        CreateLayout.onClick.RemoveAllListeners();

        switch(name)
        {
            case "Line":
                CreateLayout.onClick.AddListener(delegate { DrawLine(); });
                SetVisibility(true, true, true, true, true, false, false, false, false, false, false, false, false);
                break;

            case "Grid":
                CreateLayout.onClick.AddListener(delegate { DrawGrid(); });
                SetVisibility(true, true, false, false, false, false, false, false, true, true, true, true, false);
                break;

            case "Circle":
                CreateLayout.onClick.AddListener(delegate { DrawCircle(); });
                SetVisibility(true, true, false, false, true, false, false, true, false, false, false, false, true);
                break;

            case "Arc":
                CreateLayout.onClick.AddListener(delegate { DrawArc(); });
                SetVisibility(true, true, false, false, true, true, true, true, false, false, false, false, false);
                break;
        }

        
    }

    public void DrawLine()
    {
        print("Draw Line");
        ClearFountainList();
        //float Xslope = (float.Parse(X2Input.text) - float.Parse(X1Input.text)) / int.Parse(DeviceAmountInput.text);
        //float Zslope = (float.Parse(Y2Input.text) - float.Parse(Y1Input.text)) / int.Parse(DeviceAmountInput.text);
        float Xslope = (float.Parse(X2Input.text)) / (int.Parse(DeviceAmountInput.text)-1);
        float Zslope = (float.Parse(Y2Input.text)) / (int.Parse(DeviceAmountInput.text)-1);
        //float slope = (float.Parse(Y2Input.text) - float.Parse(Y1Input.text)) / (float.Parse(X2Input.text) - float.Parse(X1Input.text));

        for (int i=0; i < int.Parse(DeviceAmountInput.text); i++)
        {
            GameObject newFountain = Instantiate(FountainParent);
            newFountain.transform.position = new Vector3(CamOrigin.position.x + float.Parse(X1Input.text) + i * Xslope, 0, CamOrigin.position.z + float.Parse(Y1Input.text) + i * Zslope);
            //newFountain.transform.position = new Vector3(CamOrigin.transform.position.x + float.Parse(X1Input.text) + i * slope/ int.Parse(DeviceAmountInput.text), 0, CamOrigin.transform.position.z + float.Parse(Y1Input.text) + i * slope/int.Parse(DeviceAmountInput.text));
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
                newFountain.transform.position = new Vector3(CamOrigin.position.x + float.Parse(X1Input.text) + j * float.Parse(ColumnSpacingInput.text), 0, CamOrigin.position.z + float.Parse(Y1Input.text) + i * float.Parse(RowSpacingInput.text));
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
            //newFountain.transform.position = new Vector3(StartMarker.transform.parent.position.x + Mathf.Cos(Mathf.PI * 2 / int.Parse(ColumnsInput.text)*i) * float.Parse(ColumnSpacingInput.text), 0, StartMarker.transform.parent.position.z + Mathf.Sin(Mathf.PI * 2 / int.Parse(ColumnsInput.text)*i) * float.Parse(ColumnSpacingInput.text));
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

    private void SetVisibility(bool x1, bool y1, bool x2, bool y2, bool deviceAmount, bool height, bool width, bool angle, bool rows, bool rowSpacing, bool col, bool colSpacing, bool radiusSpacing)
    {
        X1Input.gameObject.SetActive(x1);
        Y1Input.gameObject.SetActive(y1);
        X2Input.gameObject.SetActive(x2);
        Y2Input.gameObject.SetActive(y2);
        DeviceAmountInput.gameObject.SetActive(deviceAmount);
        HeightInput.gameObject.SetActive(height);
        WidthInput.gameObject.SetActive(width);
        AngleInput.gameObject.SetActive(angle);
        RowsInput.gameObject.SetActive(rows);
        RowSpacingInput.gameObject.SetActive(rowSpacing);
        ColumnsInput.gameObject.SetActive(col);
        ColumnSpacingInput.gameObject.SetActive(colSpacing);
        RadiusSpacingInput.gameObject.SetActive(radiusSpacing);
    }
}
