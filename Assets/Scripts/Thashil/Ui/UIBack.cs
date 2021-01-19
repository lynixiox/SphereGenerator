using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIBack : MonoBehaviour
{

    public Button btnBack;
    // Start is called before the first frame update
    void Start()
    {
        Button back = btnBack.GetComponent<Button>();
        back.onClick.AddListener(Back);
    }

    void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
