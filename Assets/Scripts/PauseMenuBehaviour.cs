using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehaviour : MainMenuBehaviour
{
	public static bool isPaused;
	public GameObject pauseMenu;
	public GameObject optionsMenu;

    // Start is called before the first frame update
    private void Start()
    {
        this.ContinueGame();

        UpdateQualityLabel();
        UpdateVolumeLabel();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp("escape")) {
        	if (!this.optionsMenu.activeInHierarchy) {
	        	PauseMenuBehaviour.isPaused = !PauseMenuBehaviour.isPaused;
	        	Time.timeScale = PauseMenuBehaviour.isPaused ? 0 : 1;

	        	this.pauseMenu.SetActive(PauseMenuBehaviour.isPaused);
	        } else {
	        	this.OpenPauseMenu();
	        }
        }
    }

    public void ContinueGame()
    {
    	PauseMenuBehaviour.isPaused = false;
    	this.pauseMenu.SetActive(false);
    	Time.timeScale = 1;
    }

    public void RestartGame()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseQuality()
    {
    	QualitySettings.IncreaseLevel();
    	this.UpdateQualityLabel();
    }

    public void DecreaseQuality()
    {
    	QualitySettings.DecreaseLevel();
    	this.UpdateQualityLabel();
    }

    public void SetVolume(float value)
    {
    	AudioListener.volume = value;
    	this.UpdateVolumeLabel();
    }

    private void UpdateQualityLabel()
    {
    	int currentQuality = QualitySettings.GetQualityLevel();
    	string qualityName = QualitySettings.names[currentQuality];

    	this.optionsMenu.transform.FindChild("QualityLabel").GetComponent<UnityEngine.UI.Text>().text = "Calidad del juego: " + qualityName;
    }

    private void UpdateVolumeLabel()
    {
    	float audioVolume = AudioListener.volume * 100;

    	this.optionsMenu.transform.FindChild("VolumeLabel").GetComponent<UnityEngine.UI.Text>().text = "Volumen: " + audioVolume.ToString("f0") + "%";
    }

    public void OpenOptionsMenu()
    {
    	this.pauseMenu.SetActive(false);
    	this.optionsMenu.SetActive(true);
    }

    public void OpenPauseMenu()
    {
    	this.optionsMenu.SetActive(false);
    	this.pauseMenu.SetActive(true);
    }
}
