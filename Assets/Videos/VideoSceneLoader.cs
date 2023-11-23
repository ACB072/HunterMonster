using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public string sceneName;

    void Update()
    {
        if (videoPlayer.isPaused)
        {
            LoadScene();
        }
    }

    // Update is called once per frame
    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
