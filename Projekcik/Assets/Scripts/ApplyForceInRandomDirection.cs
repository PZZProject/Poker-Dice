using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ApplyForceInRandomDirection : MonoBehaviour {
    public float forceAmount = 10.0f;
    public ForceMode forcemode;
    public string buttonName = "Fire1";
    public float toruqueAmount = 10.0f;
    private Vector3 v;
    private System.Random rnd = new System.Random();
    private float num;

	// Update is called once per frame
	/*void Update () {
        if (Input.GetButtonDown(buttonName))
        {
            num = rnd.Next(3, 5);
            v.Set(0, num, 0);
            GetComponent<Rigidbody>().AddForce(v * forceAmount, forcemode);
            GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.insideUnitSphere * toruqueAmount, forcemode);
            
            
            /*GetComponent<Rigidbody>().AddForce(UnityEngine.Random.insideUnitSphere * forceAmount, forcemode);
            GetComponent<Rigidbody>().AddForce(UnityEngine.Random.insideUnitSphere * forceAmount, forcemode);
            GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.insideUnitSphere * toruqueAmount, forcemode);
        }
        if (GetComponent<Rigidbody>().transform.position.y > 3 && GetComponent<Rigidbody>().IsSleeping())
        {
            Debug.LogError("wieksze od 3");
        }
        if(GetComponent<Rigidbody>().transform.rotation.x % 90 != 0 || GetComponent<Rigidbody>().transform.rotation.z % 90 != 0)
        {

        }
    }*/
    public void Shoot()
    {
        num = rnd.Next(3, 5);
        v.Set(0, num, 0);
        GetComponent<Rigidbody>().AddForce(v * forceAmount, forcemode);
        GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.insideUnitSphere * toruqueAmount, forcemode);
    }

}
