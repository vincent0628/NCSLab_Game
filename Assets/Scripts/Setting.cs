using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    
 public GUISkin myskin;
 private Rect windowRect;
 private bool paused = false, waited = false;
 private bool options;
 private float hSliderValue = 0.5f;
 private void Start()
 {
 	Cursor.visible = true;
 	Cursor.lockState = CursorLockMode.None;
    windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 3 - 100, 600, 400);
    Button btn = this.GetComponent<Button>();
    btn.onClick.AddListener(TaskOnClick);
 }
 public void waiting()
 {
     waited = true;
 }
 void TaskOnClick()
 {
    if (paused)
        paused = false;
    else
        paused = true;
    waited = false;
    Invoke("waiting", 0.3f);
}
 public void Update()
 {
		
     if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
     {
         if (paused)
             paused = false;
         else
             paused = true;
         waited = false;
         Invoke("waiting", 0.3f);
     }
     if (paused)
     {
         Time.timeScale = 0;
         AudioListener.pause = true;
     }
     else
     {
         Time.timeScale = 1;
         AudioListener.pause = false;
     }
 }
 public void OnGUI()
 {
     if (paused)
     {
         windowRect = GUI.Window(0, windowRect, windowFunc, "Game Paused");
     }
     GUI.skin.button.fontSize= 50;
 }
 public void windowFunc(int id)
 {
     if (GUILayout.Button("Resume"))
     {
         paused = false;
         options = false;
         AudioListener.volume = hSliderValue;
     }
     if (!options)
     {
         if (GUILayout.Button("Volume"))
         {
             options = true;
         }
     }
     else
     {
         hSliderValue = GUILayout.HorizontalSlider(hSliderValue, 0.0f, 1.0f);
     }
     if (GUILayout.Button("Return to Main Menu"))
     {
         Application.LoadLevel(0);
     }
 }
    
}
