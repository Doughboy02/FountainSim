using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Camera MainCamera;
    public Camera TopDownCamera;

    public int MoveSnap;
    public float MoveSpeed;

    private bool ToggleCam = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(ToggleCam)
        {
            MoveMainCam();
        }
        else
        {
            MoveTopDownCam();

            RaycastHit hit = new RaycastHit();
            Ray ray = TopDownCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.transform.gameObject;
                Behaviour halo = (Behaviour)clickedObject.GetComponent("Halo");

                if (Input.GetMouseButtonDown(1) && clickedObject.tag == "LayoutMarker")
                {
                    print("Editing : " + clickedObject.name);
                }
            }
        }
    }

    public void SwitchCam(bool b)
    {
        ToggleCam = b;
    }

    private void MoveTopDownCam()
    {
        int snap;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            snap = MoveSnap;
        }
        else
        {
            snap = 1;
        }

        if(Input.GetKeyDown(KeyCode.D)) TopDownCamera.transform.position += Vector3.right * snap;
        if (Input.GetKeyDown(KeyCode.A)) TopDownCamera.transform.position += Vector3.left * snap;
        if (Input.GetKeyDown(KeyCode.W)) TopDownCamera.transform.position += Vector3.forward * snap;
        if (Input.GetKeyDown(KeyCode.S)) TopDownCamera.transform.position += Vector3.back * snap;
    }

    private void MoveMainCam()
    {
        if (Input.GetKey(KeyCode.W)) MainCamera.transform.position += MainCamera.transform.forward * Time.deltaTime * MoveSpeed;
        if (Input.GetKey(KeyCode.A)) MainCamera.transform.position -= MainCamera.transform.right * Time.deltaTime * MoveSpeed;
        if (Input.GetKey(KeyCode.S)) MainCamera.transform.position -= MainCamera.transform.forward * Time.deltaTime * MoveSpeed;
        if (Input.GetKey(KeyCode.D)) MainCamera.transform.position += MainCamera.transform.right * Time.deltaTime * MoveSpeed;
    }
}
