using UnityEngine;

namespace Game
{
    public class TeleportSpell : Spell
    {
        [SerializeField] private float rayDistance;
        [SerializeField] private Transform wandTransform;
        [SerializeField] private Transform shootPoint;

        Ray _ray;

        private void Start()
        {
            _ray = new Ray();
        }

        protected override void Update()
        {
            base.Update();

            _ray.origin = wandTransform.position;
            _ray.direction = wandTransform.forward * rayDistance;

            Debug.DrawRay(_ray.origin, _ray.direction * rayDistance);
        }

        protected override void CreateSpellRay(int currentPlayerMana)
        {
            
        }
    }
}