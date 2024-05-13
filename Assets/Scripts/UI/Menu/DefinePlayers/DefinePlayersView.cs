using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DefinePlayers
{

    public class DefinePlayersView : MonoBehaviour
    {
        [SerializeField] private GameObject[] players;
        private int playersNumber = 2;

        [Inject]
        private GameService gameService;

        private void Awake()
        {
            PlayButton.Click += OnPlayButton;
        }

        private void Start()
        {
            var i = 0;
            players.ToList().ForEach(p => p.SetActive(i++ < playersNumber));
        }

        public void OnPlayButton()
        {
            AddPlayers();
            SceneManager.LoadScene("Game");
        }

        private void AddPlayers()
        {
            foreach (var player in players)
            {
                if (player.activeInHierarchy)
                {
                    gameService.AddPlayer(player.GetComponentInChildren<TMP_InputField>().text);
                }
            }
        }


        public void AddPlayerInput()
        {
            if (playersNumber < gameService.MAX_Players)
            {
                playersNumber += 1;
                foreach (var player in players)
                {
                    if (player.activeInHierarchy == false)
                    {
                        player.SetActive(true);
                        break;
                    }
                }
            }
        }

        public void DeletePlayerInput()
        {
            if (playersNumber > gameService.MIN_Players)
            {
                playersNumber -= 1;
                foreach (var player in players.Reverse())
                {
                    if (player.activeInHierarchy == true)
                    {
                        player.SetActive(false);
                        break;
                    }
                }
            }
        }

        private void OnDestroy()
        {
            PlayButton.Click -= OnPlayButton;
        }
    }
}
