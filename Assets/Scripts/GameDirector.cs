using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject generator;

    float time = 60.0f;
    private int point = 0;

    public void GetApple()
    {
        point += 100;
    }
    public void GetBomb()
    {
        point /= 2;
    }
    void Start()
    {
        generator = GameObject.Find("ItemGenerator");
        pointText = GameObject.Find("Point");
        timerText = GameObject.Find("Time");
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            time = 0;
            generator.GetComponent<ItemGenerator>().SetParameter(100000.0f, 0, 0);
        }
        else if (0 <= time && time < 5)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
        }
        else if (5 <= time && time < 12)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 6);
        }
        else if (12 <= time && time < 23)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
        }
        else if (23 <= time && time < 30)
        {
            generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }

        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString() + "Point";

        if (time <= 0)
            SceneManager.LoadScene("EndScene");
    }
}
