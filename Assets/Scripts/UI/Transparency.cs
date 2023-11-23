using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Transparency : MonoBehaviour
{
    // Start is called before the first frame update
    private Color colorBase;
    public Image image;
    public string scene;
    public bool fade;
    public bool newScene;

    void Start()
    {
    
        colorBase = image.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            print("Transparenta");
            colorBase.a -= 0.005f;
            image.color = colorBase;

            if (colorBase.a <= 0)
            {
                fade = false;
            }
        }
        else if(!fade && newScene)
        {
            print("desTransparenta");
            colorBase.a += 0.005f;
            image.color = colorBase;
            if (image.color.a >= 1 )
            {
                ChangeScene();
            }
        }    
    }

    private void ChangeScene()
    {
     
            SceneManager.LoadScene(scene);
      
    }
}
