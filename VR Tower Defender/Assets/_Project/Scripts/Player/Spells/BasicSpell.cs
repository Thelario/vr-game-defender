using UnityEngine;

namespace Game
{
    public class BasicSpell : Spell
    {
        [SerializeField] private float damage;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform shootPoint;
        
        protected override void CreateSpellRay(int currentPlayerMana)
        {
            GameObject bullet = Instantiate(bulletPrefab, cameraTransform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetupBullet(damage, shootPoint);
        }
    }
}