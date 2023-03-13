using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingScript : MonoBehaviour {

    [SerializeField]
    Texture white, green;

	
	public void SetTextureWhite() {
        GetComponent<Renderer>().material.mainTexture = white;
	}

    public void SetTextureGreen()
    {
        GetComponent<Renderer>().material.mainTexture = green;
    }

    private void Start()
    {
        SetTextureGreen();
    }
}
