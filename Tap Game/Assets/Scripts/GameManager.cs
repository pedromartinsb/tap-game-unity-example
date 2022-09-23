using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score = 0;

    [SerializeField, Tooltip("Define os itens do jogo")]
    private List<GameObject> targets;

    [SerializeField, Tooltip("Informe o score na HUD")]
    private TMP_Text hudScore;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHud();
    }

    private void StartGame()
    {
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
    }

    private IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
