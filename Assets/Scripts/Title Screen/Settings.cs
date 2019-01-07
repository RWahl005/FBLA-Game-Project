using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public GameObject screenPanel;
    public GameObject uiPanel;
    public Button controls;
    public Button game;
    public GameObject controlsPanel;
    public GameObject gamePanel;

    // Start is called before the first frame update
    void Start()
    {
        controlsPanel.SetActive(true);
        gamePanel.SetActive(false);
        uiPanel.SetActive(true);
        screenPanel.SetActive(false);

        ColorBlock cb = controls.colors;
        cb.normalColor = Color.gray;
        controls.colors = cb;
    }

    public void OnControls()
    {
        controlsPanel.SetActive(true);
        gamePanel.SetActive(false);
        ColorBlock cb = controls.colors;
        cb.normalColor = Color.gray;
        cb.highlightedColor = Color.gray;
        controls.colors = cb;
        ColorBlock cbs = game.colors;
        cbs.normalColor = Color.white;
        game.colors = cbs;
    }

    public void OnGame()
    {
        controlsPanel.SetActive(false);
        gamePanel.SetActive(true);
        ColorBlock cb = game.colors;
        cb.normalColor = Color.gray;
        cb.highlightedColor = Color.gray;
        game.colors = cb;
        ColorBlock cbs = controls.colors;
        cbs.normalColor = Color.white;
        controls.colors = cbs;
    }

    public void OnBack()
    {
        screenPanel.SetActive(false);
        uiPanel.SetActive(true);
    }

    public void OnSettings()
    {
        screenPanel.SetActive(true);
        uiPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
