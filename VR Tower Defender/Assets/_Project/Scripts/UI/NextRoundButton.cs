using Game;
using UnityEngine;

public class NextRoundButton : MonoBehaviour
{
    [SerializeField] private GameObject brickBlockBehind;
    
    public void StartRound()
    {
        if (Time.timeScale == 0f)
            return;
        
        Spawner.Instance.StartSpawning();
        gameObject.SetActive(false);
        brickBlockBehind.SetActive(false);
    }
}
