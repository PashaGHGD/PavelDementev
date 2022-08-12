using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {


    //  [SerializeField] private Text text;
    [SerializeField] private Button buttonMenu;
    [SerializeField] private Button buttonPlayGame;
    [SerializeField] private GameObject BackgroundMenu;
    [SerializeField] private GameObject NextLevel;
    private float StartTimeScale;
    private void Start() {
        StartTimeScale = Time.timeScale;
    }

    public void MenuActivate() {

        buttonMenu.gameObject.SetActive(true);
        buttonPlayGame.gameObject.SetActive(false);
        BackgroundMenu.SetActive(false);
        Time.timeScale = StartTimeScale;
        NextLevel.SetActive(false);
    }
    public void PlayGameActivate() {

        buttonPlayGame.gameObject.SetActive(true);
        buttonMenu.gameObject.SetActive(false);
        BackgroundMenu.SetActive(true);
        Time.timeScale = 0.1f;
        NextLevel.SetActive(true);
    }
    public void NextScene() {

        SceneManager.LoadScene("Leve2");
    }
}
