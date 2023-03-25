using UnityEngine;

namespace Game
{
    public class BasicSpell : Spell
    {
        [SerializeField] private float damage;
        
        protected override void CreateSpellRay(int currentPlayerMana)
        {
            // Get the camera transform
            Transform cameraTransform = CameraRotation.Instance.GetCameraTransform();

            // Throw a ray and check if it hit something
            if (!Physics.Raycast(cameraTransform.position, cameraTransform.forward, out var hit))
                return;

            // If it hit something, then check if it has an IDamageable component
            if (!hit.transform.TryGetComponent(out IDamageable damageable))
                return;
            
            // If it does, it is an enemy, so damage the enemy.
            damageable.TakeDamage(damage);
        }
    }
}