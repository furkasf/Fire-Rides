using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {   //allof these works can sum under text controller
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text startText;
        [SerializeField] private GameObject RegularScore;
        [SerializeField] private TMP_Text ComboScoreTextNumber;
        [SerializeField] private TMP_Text ComboScoreTextWorld;
        [SerializeField] private RectTransform ingameText;

        private bool _isGameStart;
        private int _comboScore = 0;
        private string _comboScoreString;
        private Timer _timer;

        //temp

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            UISignals.onGameStart += OnGameStart;
            UISignals.onGameRestart += OnGameRestart;
            UISignals.onActivateComboScore += OnActivateComboScore;
            UISignals.onDisActivateUI += OnDisActivateUI;
            UISignals.OnActivateRegularScore += OnActivateRegularScore;
        }

        private void UnSubscribe()
        {
            UISignals.onGameStart -= OnGameStart;
            UISignals.onGameRestart -= OnGameRestart;
            UISignals.onActivateComboScore -= OnActivateComboScore;
            UISignals.onDisActivateUI -= OnDisActivateUI;
            UISignals.OnActivateRegularScore = OnActivateRegularScore;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void Update()
        {
            if (!_isGameStart) return;

            _timer.StartTimer();
        }

        private void OnDisActivateUI()
        {
            gameObject.SetActive(false);
            Invoke("DiasbleInGameText", 2.5f);
        }

        private void OnGameStart()
        {
            _isGameStart = true;
            startText.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(true);
        }

        private void OnGameRestart()
        {
            _isGameStart = false;
            scoreText.text = "";
            _timer.ResetTimer();
            startText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
        }

        private void Init()
        {
            _timer = new Timer(scoreText);
            scoreText.gameObject.SetActive(false);
            startText.gameObject.SetActive(true);
            _isGameStart = false;
        }

        public void OnActivateRegularScore()
        {
            RegularScore.SetActive(true);
            _timer.UpdateScore(1);
            Invoke("DiasbleInGameText", 1f);
        }

        public void OnActivateComboScore()
        {
            _comboScore++;
            ingameText.gameObject.SetActive(true);
            SetWorld(_comboScore);
            _timer.UpdateScore(_comboScore);
            ComboScoreTextNumber.text = _comboScore.ToString();
            ComboScoreTextWorld.text = _comboScoreString;
            Invoke("DiasbleInGameText", 1f);
        }

        public void DiasbleInGameText()
        {
            if (!gameObject.active)
            {
                gameObject.SetActive(true);
                OnGameRestart();
            }
            ingameText.gameObject.SetActive(false);
            RegularScore.SetActive(false);
        }

        private void SetWorld(int score)
        {
            switch (score)
            {
                case 2: _comboScoreString = ScoreWorlds.CooL.ToString(); break;
                case 3: _comboScoreString = ScoreWorlds.CooL.ToString(); break;
                case 4: _comboScoreString = ScoreWorlds.AwesomE.ToString(); break;
                case 5: _comboScoreString = ScoreWorlds.MindBolwing.ToString(); break;
            }
        }
    }

    public enum ScoreWorlds
    {
        WoW = 2,
        CooL = 3,
        AwesomE = 4,
        MindBolwing = 5,
    }

    public static class UISignals
    {
        public static Action onGameStart;
        public static Action onGameRestart;
        public static Action onDisActivateUI;
        public static Action onActivateComboScore;
        public static Action OnActivateRegularScore;
    }
}