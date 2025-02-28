using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Utilizar los diferentes sprites
// Cuando pierda una vida, el sprite se oscurezca

public class UIHealth : MonoBehaviour
{
    public Image[] carrot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Restar una vida
    public void UpdateHealth(int lives)
    {
        for (int i = 0; i < carrot.Length; i++)
        {
            if (i < (lives))
                carrot[i].color = Color.white;
            else
                carrot[i].color = Color.black;
        }
    }
}
