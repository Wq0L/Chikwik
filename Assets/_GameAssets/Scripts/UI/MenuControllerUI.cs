using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControllerUI : MonoBehaviour
{

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;



    void Awake()
    {
        _playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(Consts.SceneNames.GAME_SCENE);
        });
        _quitButton.onClick.AddListener(() =>
        {
            Debug.Log("Quit button clicked");
            Application.Quit();
        });
    }
}
