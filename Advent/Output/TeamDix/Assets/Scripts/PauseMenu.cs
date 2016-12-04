using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public Text PlaytimeText;

    private bool _paused;

    private readonly Stopwatch _timer = new Stopwatch();

    private void Start()
    {
        PausePanel.SetActive(false);
        _timer.Start();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            _paused = !_paused;

            PlaytimeText.text = "Playtime: " + Util.FormatTimeDifference(_timer.Elapsed);
        }

        if (_paused)
        {
            PausePanel.SetActive(true);

            Time.timeScale = 0;
            _timer.Stop();
        }
        else
        {
            PausePanel.SetActive(false);

            Time.timeScale = 1;
            _timer.Start();
        }
    }

    public void Resume()
    {
        _paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
        _timer.Reset();
    }

    public void Quit()
    {
        Application.Quit();
    }
}