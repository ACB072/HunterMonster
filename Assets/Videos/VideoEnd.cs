using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoEnd : MonoBehaviour
{
    // Start is called before the first frame update
    private Color colorBase;
    public GameObject button1;
    public GameObject button2;

    public VideoPlayer videoPlayer;



    void Update()
    {
        if (videoPlayer.isPaused)
        {
            button1.SetActive(true);
            button2.SetActive(true);
        }
    }
}

