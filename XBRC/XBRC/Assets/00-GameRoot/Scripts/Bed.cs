using System.Collections;
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
                float inverseTreament = Treating / Ocupant.GetComponent<Patient>().treatmentTime;
                Ocupant.GetComponent<Patient>().playerhealth.fillAmount = inverseTreament;
                //Debug.Log("Treament time is: " + inverseTreament);


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
                StartCoroutine(OnlyCall());
            }

        }
    }

    IEnumerator OnlyCall()
    {
        string coh1 = "NPC_Cough1";
        string coh2 = "NPC_Cough2";
        bool firstswitch = true;

        if (firstswitch)
        {
            FindObjectOfType<AudioManager>().PlaySound(coh1);
            firstswitch = false;
        }
        else if(!firstswitch)
        {
            FindObjectOfType<AudioManager>().PlaySound(coh2);
        }

        yield return new WaitForSeconds(3);
    }

}
