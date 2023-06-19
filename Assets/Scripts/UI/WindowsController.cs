using EventSystem;
using UnityEngine;

namespace UI
{
    public class WindowsController : MonoBehaviour
    {
        [SerializeField] private GameObject gameWindow;
        [SerializeField] private GameObject gameOverWindow;

        private void Start()
        {
            EventsInstance.Events.StartGame += OnStartGame;
            EventsInstance.Events.EnableGame += OnEnableGame;
            EventsInstance.Events.GameOver += OnGameOver;
        }

        private void OnStartGame() => gameWindow.SetActive(false);
        private void OnEnableGame()
        {
            gameWindow.SetActive(true);
            gameOverWindow.SetActive(false);
        }

        private void OnGameOver() => gameOverWindow.SetActive(true);

    }
}
