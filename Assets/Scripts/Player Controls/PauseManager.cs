using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    private MainGame game;
    private KeyHandler kh;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        game = Camera.main.GetComponent<MainGame>();
        kh = Camera.main.GetComponent<KeyHandler>();
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(kh.getKey("pause")))
        {
            GameAPI.api.callEvent(new OnMenuOpenEvent(Menus.PauseMenu));
            game.isPaused = !game.isPaused;
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
