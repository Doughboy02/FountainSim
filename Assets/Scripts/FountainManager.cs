using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FountainManager : MonoBehaviour {

    public GameObject currentFountain;
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

            if(clickedObject.GetComponent<Fountain>() != null && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Fountain!");
                currentFountain = clickedObject;
                PropertiesPanel.SetActive(true);
            }
        }
	}

    public void DeactivatePanel()
    {
        PropertiesPanel.SetActive(false);
        currentFountain = null;
    }

    public void EditFountainColor()
    {
        if(currentFountain != null) currentFountain.GetComponent<Fountain>().ChangeColor(RedSlider.value, GreenSlider.value, BlueSlider.value);
    }

    public void EditFountainHeight()
    {
        if (currentFountain != null) currentFountain.GetComponent<Fountain>().AdjustHeight(HeightSlider.value);
    }
}
