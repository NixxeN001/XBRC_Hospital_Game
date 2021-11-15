using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
	public bool Ocupied = false;
	public GameObject Ocupant;

	float Treating;


	public void Sending(GameObject ocupant)
	{
		
		Ocupant = ocupant;

		Treating = Ocupant.GetComponent<Patient>().treatmentTime;

	}


	private void Update()
	{
		if (Ocupant != null)
		{
			float dist = Vector3.Distance(Ocupant.transform.position, transform.position);

			if ((!Ocupied) && (dist <= 3.1))
			{


				Ocupant.transform.position = gameObject.transform.Find("PatPos").position;
				Ocupied = true;

				Ocupant.GetComponent<Patient>().Treated = true;

			}
		}

		if (Ocupied)
		{
			Vector3 eulerRotation = new Vector3(-90, 0, transform.eulerAngles.y);

			Ocupant.transform.rotation = Quaternion.Euler(eulerRotation);


			

			if (Treating > 0)
			{
				Treating -= Time.deltaTime;

				//Debug.Log(Treating);
			}
			else
			{
				Ocupied = false;
				Ocupant.transform.position = gameObject.transform.Find("drop").position;


				Vector3 eulerRotation2 = new Vector3(0, 0, 0);

				Ocupant.transform.rotation = Quaternion.Euler(eulerRotation2);

				Ocupant.GetComponent<Motor>().Move(GameObject.Find("exit").transform.position);
				Ocupant.GetComponent<Patient>().Pay();
				Ocupant = null;
			}

		}
		
		




	}
}
