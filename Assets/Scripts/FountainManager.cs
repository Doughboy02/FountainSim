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

            if(Input.GetMouseButtonDown(0) && clickedObject.GetComponent<Fountain>() != null && !FountainList.Contains(clickedObject))
            {
                Debug.Log("Fountain!");
                Behaviour halo = (Behaviour)clickedObject.GetComponent("Halo");
                halo.enabled = true;
                FountainList.Add(clickedObject);
                PropertiesPanel.SetActive(true);
            }
            else if (Input.GetMouseButtonDown(0) && FountainList.Contains(clickedObject))
            {
                FountainList.Remove(clickedObject);
                Behaviour halo = (Behaviour)clickedObject.GetComponent("Halo");
                halo.enabled = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //FountainList.Clear();
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
}
