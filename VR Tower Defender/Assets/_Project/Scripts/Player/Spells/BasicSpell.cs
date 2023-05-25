using UnityEngine;

namespace Game
{
    public class BasicSpell : Spell
    {
        [SerializeField] private float damage;
        [SerializeField] private float minUpgradeSpell;
        [SerializeField] private float maxUpgradeSpell;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform wandTransform;
        [SerializeField] private Transform shootPoint;

        private float _currentDamage;
        
        protected override void Start()
        {
            base.Start();
            _currentDamage = damage;
        }

        public override void UpgradeSpell()
        {
            print("Upgrading spell");
            _currentDamage += Random.Range(minUpgradeSpell, maxUpgradeSpell);
        }

        protected override void CreateSpellRay(int currentPlayerMana)
        {
            GameObject bullet = Instantiate(bulletPrefab, wandTransform.position, Quaternion.identity);
            bullet.GetComponent<IConfigurable>().ConfigureBullet(_currentDamage, shootPoint);
        }
    }
}