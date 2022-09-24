using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static float timer = 0f;

    [SerializeField, Tooltip("Define os itens do jogo")]
    private List<GameObject> targets;

    [SerializeField, Tooltip("Informa o score na HUD")]
    private TMP_Text hudScore;
    [SerializeField, Tooltip("Informa o timer na HUD")]
    private TMP_Text hudTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHud();

        // diminui o tempo de jogo
        timer -= Time.deltaTime;
    }

    private void StartGame()
    {
        // tempo que o jogador poderá jogar
        GameManager.timer = 50;

        // inicia o Spawn dos itens
        StartCoroutine(SpawnTargets());

        // zera o score
        GameManager.score = 0;
    }

    private void UpdateHud()
    {
        if (hudScore != null)
        {
            hudScore.text = "SCORE: " + GameManager.score;
        }

        if (hudTimer != null)
        {
            hudTimer.text = GameManager.timer > 0 ? "TIMER: " + (int) GameManager.timer : "TIMER: " + 0;
        }
    }

    private IEnumerator SpawnTargets()
    {
        while (GameManager.timer > 0)
        {
            yield return new WaitForSeconds(1f);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
