using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public GameObject SelectedUnit;
    public GameObject SelectedBed;

    public Transform destination;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SelectedBed = null;
            SelectedUnit = null;

        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FindObjectOfType<AudioManager>().PlaySound("ClickSound");
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
				if ((hit.transform.gameObject.tag == "Patient")&&(hit.transform.gameObject.GetComponent<Patient>().treated==false))
				{
                    SelectedBed = null;

                    SelectedUnit = hit.transform.gameObject;

                    //Debug.Log(SelectedUnit.name);
                }

				if (SelectedUnit != null)
				{

                    //////
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        RaycastHit hit2;
                        Ray ray2 = camera.ScreenPointToRay(Input.mousePosition);

                        if (Physics.Raycast(ray2, out hit2))
                        {
                            if ((hit2.transform.gameObject.tag == "BED"))
                            {
                               
                                SelectedBed = hit2.transform.gameObject;

                              
                               // Debug.Log(SelectedBed.name);
                            }

                            if ((SelectedBed != null) && (SelectedBed.GetComponent<Bed>().Ocupied == false))
                            {
								if (SelectedUnit.GetComponent<Patient>().treated != true)
								{
                                    SelectedUnit.GetComponent<Motor>().Move(SelectedBed.transform.position);

                                    SelectedBed.GetComponent<Bed>().Sending(SelectedUnit);

                                    SelectedBed = null;
                                    SelectedUnit.GetComponent<Patient>().treated = true;
                                    SelectedUnit = null;
                                }
                                

                               
                                SelectedUnit = null;
                            }

                            

                        }

                    }


                    /////

                }
               
            }



        }
    }
}
