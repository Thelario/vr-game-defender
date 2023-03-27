using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;

namespace Game
{
    public class BasicSpell : Spell
    {
        [SerializeField] private float damage;

        [SerializeField] private GameObject controllerRight;

        private SteamVR_TrackedObject trackedObject;
        //private SteamVR_Controller.Device device;
        //private SteamVR_TrackedController controller;

        protected override void Start()
        {
            
        }
        
        protected override void CreateSpellRay(int currentPlayerMana)
        {
            // Get the camera transform
            Transform cameraTransform = Camera.main.transform;

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