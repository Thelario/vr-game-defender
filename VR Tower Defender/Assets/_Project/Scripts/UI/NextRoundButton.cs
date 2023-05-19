using Game;
using UnityEngine;

public class NextRoundButton : MonoBehaviour
{
    [SerializeField] private GameObject brickBlockBehind;
    [SerializeField] private Player player;
    
    public void StartRound()
    {
        if (Time.timeScale == 0f)
            return;
        
        player.EnablePlayerShoot(true);
        Spawner.Instance.StartSpawning();
        gameObject.SetActive(false);
        brickBlockBehind.SetActive(false);
    }
}
