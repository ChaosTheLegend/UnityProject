using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupControll : MonoBehaviour {

    public GameObject shield;
    public GameObject shieldbar;
    public Slider shieldslider;
    public GameObject sizebar;
    public Slider sizeslider;
    public GameObject helpers;
    public Transform plane;
    float helperspeed;
    public float[] delay;
    float[] timer;

    private void Start()
    {
        shield.SetActive(false);
        shieldbar.SetActive(false);
        sizebar.SetActive(false);
        timer = new float[5];
        helpers.SetActive(false);
    }
    public void Powerup(int id)
    {
        if (id == 1)
        {
            shield.SetActive(true);
            shieldbar.SetActive(true);
            timer[id] = delay[id];
        }
        if (id == 2)
        {
            sizebar.SetActive(true);
            timer[id] = delay[id];
            helpers.SetActive(true);
        }
        if (id == 3)
        {
            GetComponent<GM>().lives++;
        }
        if (id == 4)
        {
            GetComponent<GM>().balls++;
        }
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < timer.Length; i++)
        {
            if (timer[i] > 0)
            {
                timer[i] -= Time.deltaTime;
                if (i == 2)
                {
                    if (helpers.transform.position.y < plane.position.y)
                    {
                        helpers.transform.position = new Vector3(helpers.transform.position.x, helpers.transform.position.y+0.1f, helpers.transform.position.z);
                    }
                    if (helpers.transform.position.y > plane.position.y)
                    {
                        helpers.transform.position = new Vector3(helpers.transform.position.x, plane.position.y, helpers.transform.position.z);
                    }
                }
            }
            if (timer[i] <= 0)
            {
                if (i == 1)
                {
                    shield.SetActive(false);
                    shieldbar.SetActive(false);
                }
                if (i == 2)
                {
                    sizebar.SetActive(false);
                    if (helpers.transform.position.y < 10f && helpers.transform.position.y >= plane.position.y)
                    {
                        helperspeed += 0.01f;
                        helpers.transform.position = new Vector3(helpers.transform.position.x, helpers.transform.position.y + helperspeed, helpers.transform.position.z);
                    }
                    if (helpers.transform.position.y >= 10f)
                    {
                        helpers.transform.position = new Vector3(helpers.transform.position.x, plane.position.y-1f , helpers.transform.position.z);
                        helperspeed = 0f;
                        helpers.SetActive(false);
                    }
                }
            }
            shieldslider.value = 100 / delay[1] * timer[1];
            sizeslider.value = 100 / delay[2] * timer[2];
        }
    }
}
