using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {
    [SerializeField]
    Lodis.Event OnClick;
	// Use this for initialization
	void Start () {
		
	}
	public void changeColor()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            OnClick.Raise();
        }
	}
}
