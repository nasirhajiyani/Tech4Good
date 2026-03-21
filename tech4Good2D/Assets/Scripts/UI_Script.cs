using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class UI_Script : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject winCanvas;
    public GameObject startButtoms;
    public GameObject pauseButtoms;
    public GameObject checkList;
   
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startCanvas.SetActive(true);
        startButtoms.SetActive(true);
        pauseMenuCanvas.SetActive(false);
        winCanvas.SetActive(false);
        pauseButtoms.SetActive(false);
        checkList.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
