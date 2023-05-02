using UnityEngine;

namespace Game
{
    public class BasicSpell : Spell
    {
        [SerializeField] private float damage;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform wandTransform;
        [SerializeField] private Transform shootPoint;
        
        protected override void CreateSpellRay(int currentPlayerMana)
        {
            GameObject bullet = Instantiate(bulletPrefab, wandTransform.position, Quaternion.identity);
            bullet.GetComponent<IConfigurable>().ConfigureBullet(damage, shootPoint);
        }
    }
}