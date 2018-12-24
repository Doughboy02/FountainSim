using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FountainManager : MonoBehaviour {

    public List<GameObject> FountainList;
    public Camera camera;

    public GameObject PropertiesPanel;
    public Slider HeightSlider;
    public Slider RedSlider;
    public Slider GreenSlider;
    public Slider BlueSlider;
    public InputField Delay;


    [SerializeField]
    private List<float> testTime = new List<float>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit = new RaycastHit();
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            GameObject clickedObject = hit.transform.gameObject;


            if (Input.GetMouseButtonDown(0) && clickedObject.GetComponent<Fountain>() != null)
            {
                Debug.Log("Fountain!");
                Behaviour halo = (Behaviour)clickedObject.GetComponent("Halo");

                if (FountainList.Contains(clickedObject))
                {
                    FountainList.Remove(clickedObject);
                    halo.enabled = false;
                }

                if (Input.GetKey(KeyCode.LeftControl) && !FountainList.Contains(clickedObject))
                {
                    FountainList.Add(clickedObject);
                    return;
                }

                foreach (GameObject fountain in FountainList)
                {
                    halo = (Behaviour)fountain.GetComponent("Halo");
                    halo.enabled = false;
                }

                FountainList.Clear();
                FountainList.Add(clickedObject);
                halo.enabled = true;
                PropertiesPanel.SetActive(true);
            }
            else if(Input.GetMouseButtonDown(0) && clickedObject.GetComponent<Fountain>() == null)
            {
                foreach (GameObject fountain in FountainList)
                {
                    Behaviour halo = (Behaviour)fountain.GetComponent("Halo");
                    halo.enabled = false;
                }
                FountainList.Clear();
            }
        }
    }

    public void DeactivatePanel()
    {
        PropertiesPanel.SetActive(false);
        FountainList = null;
    }

    public void EditFountainColor()
    {
        if (FountainList != null)
        {
            foreach (GameObject fountain in FountainList)
            {
                fountain.GetComponent<Fountain>().ChangeColor(RedSlider.value, GreenSlider.value, BlueSlider.value);
            }
        }
    }

    public void EditFountainHeight()
    {
        if (FountainList != null)
        {
            foreach (GameObject fountain in FountainList)
            {
                fountain.GetComponent<Fountain>().AdjustHeight(HeightSlider.value);
            }
        }
    }

    public void SetDelays()
    {
        if (FountainList != null && FountainList.Count > 0)
        {
            FountainList[0].GetComponent<Fountain>().delay = 0;
            for (int i=1; i<FountainList.Count; i++)
            {
                FountainList[i].GetComponent<Fountain>().delay = FountainList[i-1].GetComponent<Fountain>().delay + float.Parse(Delay.text);
            }
        }
    }
}
