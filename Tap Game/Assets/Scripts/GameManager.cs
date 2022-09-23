using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("Define os itens do jogo")]
    private List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    // Update is called once per frame
    void Update()
    {
        
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
