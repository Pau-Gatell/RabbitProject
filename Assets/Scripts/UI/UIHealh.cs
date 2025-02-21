using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image[] cherry;

    void Start()
    {

    }

    void Update()
    {

    }

    public void UpdateHealth(int lives)
    {
        for (int i = 0; i < cherry.Length; i++)
        {
            if (i < (lives))
                cherry[i].color = Color.white;
            else
                cherry[i].color = Color.black;
        }
    }
}

