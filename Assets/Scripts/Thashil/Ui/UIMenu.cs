using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{

    public Button btnPlay;
    public Button btnHtp;
    // Start is called before the first frame update
    void Start()
    {

        Button play = btnPlay.GetComponent<Button>();
        play.onClick.AddListener(Play);

        Button htp = btnHtp.GetComponent<Button>();
        htp.onClick.AddListener(Htp);

    }

    void Play()
    {
        SceneManager.LoadScene("test");
    }

    void Htp()
    {
        SceneManager.LoadScene("htp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
