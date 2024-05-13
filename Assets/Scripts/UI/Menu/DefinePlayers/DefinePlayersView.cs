using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DefinePlayers {

    public class DefinePlayersView : MonoBehaviour {

        [SerializeField] private GameObject[] players;
        [SerializeField] private GameObject addPlayer;
        [SerializeField] private GameObject removePlayer;
        private int playersNumber = 2;

        [Inject]
        private GameService gameService;

        private void Awake() {
            DefinePlayers.PlayButton.Click += OnPlayButton;
        }

        private void Start() {
            var i = 0;
            players.ToList().ForEach(p => p.SetActive(i++ < playersNumber));
            removePlayer.SetActive(false);
        }

        public void OnPlayButton() {
            AddPlayers();
            ChangeSceneButton.OnClick("Game");
        }

        private void AddPlayers() {
            for (int i = 0; i < playersNumber; i++) {
                if (players[i].activeInHierarchy) {
                    string playerName = players[i].GetComponentInChildren<TMP_InputField>().text;
                    gameService.AddPlayer(playerName.Equals("") ? $"Player {i+1}" : playerName);
                }
            }
        }

        public void AddPlayerInput() {
            if (playersNumber < gameService.MAX_Players) {
                playersNumber += 1;
                foreach (var player in players) {
                    if (player.activeInHierarchy == false) {
                        player.SetActive(true);
                        break;
                    }
                }
                if (playersNumber == gameService.MAX_Players) {
                    addPlayer.SetActive(false);
                    removePlayer.SetActive(true);
                }
            }

        }

        public void DeletePlayerInput() {
            if (playersNumber > gameService.MIN_Players) {
                playersNumber -= 1;
                foreach (var player in players.Reverse()) {
                    if (player.activeInHierarchy == true) {
                        player.SetActive(false);
                        break;
                    }
                }
                if (playersNumber == gameService.MIN_Players) {
                    removePlayer.SetActive(false);
                    addPlayer.SetActive(true);
                }
            }
        }

        private void OnDestroy() {
            DefinePlayers.PlayButton.Click -= OnPlayButton;
        }
    }
}