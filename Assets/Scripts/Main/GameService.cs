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
    [SerializeField]
    private UIService uIService;
    public UIService UIService => uIService;

    public WaveService WaveService { get; private set; }
    public MapService MapService {  get; private set; }

   
    public PlayerScriptableObject playerScriptableObject;
    [SerializeField]
    private SoundScriptableObject soundScriptableObject;
    [SerializeField]
    private MapScriptableObject mapScriptableObject;
    [SerializeField]
    private AudioSource audioEffects;
    [SerializeField]
    private AudioSource backgroundMusic;
    [SerializeField]
    private WaveScriptableObject waveScriptableObject;
   


    void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        WaveService = new WaveService(waveScriptableObject);
        MapService = new MapService(mapScriptableObject);
    }

  
    void Update()
    {
        playerService.Update();

    }
}
