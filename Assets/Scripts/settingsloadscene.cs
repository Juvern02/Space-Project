// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class SettingsMenu : MonoBehaviour
// {

//     public GameObject settings;

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.P)){
//             if(Paused){
//                 Play();
//             }
//             else{
//                 Stop();
//                 Cursor.lockState = CursorLockMode.None;
//                 Cursor.visible = true;
//             }
//         }
//     }

//     void Stop(){
//         settings.SetActive(true);
//         Time.timeScale = 0f;
//         Paused = true;
//     }

//     public void Play(){
//         settings.SetActive(false);
//         Time.timeScale = 1f;
//         Paused = false;
//     }

//     public void MainMenuButton(){
//         SceneManager.LoadScene("MainMenu");
//     }

//     public void QuitGame(){
//         Application.Quit();
//     }
// }
