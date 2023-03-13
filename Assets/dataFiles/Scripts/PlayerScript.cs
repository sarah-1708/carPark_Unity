using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField]
     private float cRotation = 35f, speed = 2f;

    [SerializeField]
    private GameObject avtg, avtd, arrd, arrg;

    private bool canMoove=true;

    private BoxCollider box;

    public void Awake()
    {
    box: GetComponent<BoxCollider>();

    }
    // Update is called once per frame
    void Update() {

        if (!canMoove)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftAlt))
        {
            Vector3 dir = Vector3.zero;

            if (Input.GetKey(KeyCode.Space))
            {
                dir = Vector3.forward;
                avtg.transform.Rotate(Vector3.right * 200 * Time.deltaTime);
                avtd.transform.Rotate(Vector3.right * 200 * Time.deltaTime);
                arrg.transform.Rotate(Vector3.right * 200 * Time.deltaTime);
                arrd.transform.Rotate(Vector3.right * 200 * Time.deltaTime);
            }
            else
            {
                dir = -Vector3.forward;
                avtg.transform.Rotate(Vector3.right * -200 * Time.deltaTime);
                avtd.transform.Rotate(Vector3.right * -200 * Time.deltaTime);
                arrg.transform.Rotate(Vector3.right * -200 * Time.deltaTime);
                arrd.transform.Rotate(Vector3.right * -200 * Time.deltaTime);
            }
            transform.Translate(dir * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * cRotation * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
    }
        
        void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.tag == "obstacles")
            {
                canMoove = false;
                Debug.Log("Game Over !");
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (box.bounds.min.x > other.bounds.min.x && box.bounds.max.x < other.bounds.max.x
                && box.bounds.min.y > other.bounds.min.y && box.bounds.max.y < other.bounds.max.y
                && box.bounds.min.z > other.bounds.min.z && box.bounds.max.z < other.bounds.max.z)
            {
                GameObject.Find("parking").GetComponent<ParkingScript>().SetTextureGreen();
            }
            else
            {
                GameObject.Find("parking").GetComponent<ParkingScript>().SetTextureWhite();
            }
        }
       
        
	}

