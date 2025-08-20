using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService:GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    private UIService uIService;public UIService UIService => uIService;
    
    public WaveService WaveService { get; private set; }
    public MapService MapService {  get; private set; }

    [SerializeField]
    public PlayerScriptableObject playerScriptableObject;
    [SerializeField]
    private SoundScriptableObject soundScriptableObject;
    [SerializeField]
    private AudioSource audioEffects;
    [SerializeField]
    private AudioSource backgroundMusic;
    [SerializeField]
    private WaveScriptableObject waveScriptableObject;
    private MapScriptableObject mapScriptableObject;


    void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        MapService = new MapService(mapScriptableObject);
        WaveService = new WaveService(waveScriptableObject);
        MapService = new MapService(mapScriptableObject);
    }

  
    void Update()
    {
        playerService.Update();

    }
}
