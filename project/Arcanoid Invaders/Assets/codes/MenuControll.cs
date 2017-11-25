using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour {

	public GameObject DarkPan;
    public GameObject DeathPan;
    public GameObject WinPan;
    public GameObject Pbutton;

	public void OnBPlay()
	{
		DarkPan.SetActive(false);
		Pbutton.SetActive (true);
		Time.timeScale = 1f;
	}
	void Start()
	{
		Pbutton.SetActive (true);
        DarkPan.SetActive(false);
        DeathPan.SetActive(false);
        WinPan.SetActive(false);
        Time.timeScale = 1f;
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
    public void Dead()
    {
        DeathPan.SetActive(true);
        Time.timeScale = 0f;
        Pbutton.SetActive(false);
    }
    public void Win()
    {
        WinPan.SetActive(true);
        Time.timeScale = 0f;
        Pbutton.SetActive(false);
        Destroy(gameObject);
    }

}
