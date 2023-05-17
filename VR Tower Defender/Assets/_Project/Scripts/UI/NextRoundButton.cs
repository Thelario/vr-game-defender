using Game;
using UnityEngine;

public class NextRoundButton : MonoBehaviour
{
    [SerializeField] private GameObject brickBlockBehind;
    
    public void StartRound()
    {
        Spawner.Instance.StartSpawning();
        gameObject.SetActive(false);
        brickBlockBehind.SetActive(false);
    }
}
