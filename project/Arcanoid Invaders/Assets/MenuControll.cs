using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour {

	public GameObject DarkPan;
	public GameObject Pbutton;

	public void OnBPlay()
	{
		DarkPan.SetActive(false);
		Pbutton.SetActive (true);
		Time.timeScale = 1f;
	}
	void Start()
	{
		Pbutton.SetActive (false);
		Time.timeScale = 0f;
	}
	void Update()
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			pouse ();

		}
	}
	public void pouse()
	{
		DarkPan.SetActive(true);
		Time.timeScale = 0f;
		Pbutton.SetActive (false);
	}

}
