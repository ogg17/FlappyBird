using System;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TubeGenerator : MonoBehaviour
{
    [SerializeField] private List<LevelData> levels;
    [SerializeField] private GameObject tube;
    [SerializeField] private int tubePoolSize = 3;
    [SerializeField] private float baseSpeed = 0.1f;
    [SerializeField] private float border;
    [SerializeField] private GameData gameData;

    private int _currentLevel;
    private Vector3 _speed;
    private Vector3 _startPosition;
    private Transform _transform;
    private Vector3 _randomHeight = Vector3.zero;
    private float _levelStartTime;

    private readonly List<GameObject> _tubePool = new();
    private Vector3 _nextPosition;
    private Transform _lastTransform;
    private Vector3 _lastPosition;

    private void Start()
    {
        SetSpeed();
        _startPosition = new Vector3(-border, 0, 0);
        _transform = transform;
        
        EventsInstance.Events.EnableGame += OnEnableGame;

        // Create Tube Pool
        for (var i = 0; i < tubePoolSize; i++)
        {
            var tubeCopy = Instantiate(tube, _startPosition, _transform.rotation, _transform);
            _tubePool.Add(tubeCopy);
            //tubeCopy.SetActive(false);
        }

        _currentLevel = gameData.difficulty;
        //SetTubePosition();
    }

    private void OnEnableGame()
    {
        _currentLevel = gameData.difficulty;
        _levelStartTime = Time.time;
        SetTubePosition();
    }
    private void OnStartGame()
    {
        
    }
    
    private void SetTubePosition()
    {
        _nextPosition = new Vector3(levels[_currentLevel].tubeSpace, 0, 0);
        var i = 0;
        foreach (var tubeObject in _tubePool)
        {
            _randomHeight.y = Random.Range(-5, 6);
            tubeObject.transform.localPosition = _startPosition;
            tubeObject.transform.Translate(_nextPosition * (i + 1));
            tubeObject.transform.Translate(_randomHeight);
            _lastTransform = tubeObject.transform;
            i++;
        }
    }

    private void SetSpeed()
    {
        _speed = Vector3.left * (baseSpeed * levels[_currentLevel].speed);
    }

    private void Update()
    {
        if (gameData.isGame == false) return;
        
        foreach (var tubeObject in _tubePool)
        {
            tubeObject.transform.Translate(_speed * Time.deltaTime);
            if (tubeObject.transform.localPosition.x > border) continue;
            _randomHeight.y = Random.Range(-5, 6);
            _lastPosition.x = _lastTransform.position.x;
            tubeObject.transform.localPosition =  _lastPosition + _nextPosition;
            _lastTransform = tubeObject.transform;
            tubeObject.transform.Translate(_randomHeight);
        }

        var currentTime = Time.time - _levelStartTime;
        if (_currentLevel >= levels.Count - 1 ||  currentTime <= levels[_currentLevel].duration) return;
        _levelStartTime = Time.time;
        _currentLevel++;
        _nextPosition = new Vector3(levels[_currentLevel].tubeSpace, 0, 0);
        print(_currentLevel);
        SetSpeed();
    }
}