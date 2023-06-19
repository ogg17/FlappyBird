using EventSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdScript : MonoBehaviour
{
    [SerializeField] private float riseStrength;
    [SerializeField] private GameData gameData;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.simulated = false;
        _startPosition = transform.position;

        EventsInstance.Events.EnableGame += OnEnableGame;
        EventsInstance.Events.StartGame += OnStartGame;
        EventsInstance.Events.OnTap += Rise;
        EventsInstance.Events.GameOver += OnGameOver;
    }

    private void OnEnableGame()
    {
        _rigidbody2D.position = Vector2.zero;
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = _startPosition;
    }

    private void OnStartGame() => _rigidbody2D.simulated = true;

    private void OnGameOver() => _rigidbody2D.simulated = false;

    private void Rise() => _rigidbody2D.AddForce(riseStrength * Vector2.up);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameData.isGame == false) return;
        switch (other.gameObject.tag)
        {
            case GameConstants.LoseTriggerTag:
                EventsInstance.Events.GameOver.Invoke();
                break;
            case GameConstants.EnterTriggerTag:
                gameData.Score++;
                break;
        }
    }
}