using System.Collections;
using UnityEngine;

namespace BigRookGames.Weapons
{
    public class GunfireController : MonoBehaviour
    {
        // --- Audio ---
        public AudioClip GunShotClip;
        public AudioClip ReloadClip;
        public AudioSource source;
        public AudioSource reloadSource;
        public Vector2 audioPitch = new Vector2(.9f, 1.1f);

        // --- Muzzle ---
        public GameObject muzzlePrefab;
        public GameObject muzzlePosition;

        // --- Config ---
        public bool autoFire;
        public float shotDelay = .5f;
        public bool rotate = true;
        public float rotationSpeed = .25f;

        // --- Options ---
        public GameObject scope;
        public bool scopeActive = true;
        private bool lastScopeState;

        // --- Projectile ---
        [Tooltip("The projectile gameobject to instantiate each time the weapon is fired.")]
        public GameObject projectilePrefab;
        [Tooltip("Sometimes a mesh will want to be disabled on fire. For example: when a rocket is fired, we instantiate a new rocket, and disable" +
            " the visible rocket attached to the rocket launcher")]
        public GameObject projectileToDisableOnFire;

        // --- Timing ---
        [SerializeField] private float timeLastFired;
        [SerializeField] private GameObject normalCrossHair;
        [SerializeField] private GameObject rocketCrossHair;
        AudioSource playerAudioSource;
        WeaponChoice chosenWeaponScript;
        WeaponResources weaponResources;
        GunUseAnimation gunGrabAnimation;
        GunLeaveAnimation gunLeaveAnimation;
        private void Awake() 
        {
            playerAudioSource = GetComponentInParent<AudioSource>();
            gunGrabAnimation = GetComponent<GunUseAnimation>();
            gunLeaveAnimation = GetComponent<GunLeaveAnimation>();
            chosenWeaponScript = GetComponentInParent<WeaponChoice>();
            weaponResources = GetComponentInParent<WeaponResources>();
        }
        private void OnEnable() 
        {
            normalCrossHair.SetActive(false);
            rocketCrossHair.SetActive(true);
            StartCoroutine(GrabOrLeaveGun());
        }
        private void OnDisable() 
        {
            rocketCrossHair.SetActive(false);
            normalCrossHair.SetActive(true);
            if(weaponResources.WeaponsResources[WeaponType.RocketLauncher] == 0)
                GetComponentInParent<AudioSource>().PlayOneShot(GunShotClip);
            
            gunLeaveAnimation.AnimationPlay();
        }
        IEnumerator GrabOrLeaveGun()
        {
            yield return new WaitForSeconds(0.1f);
            gunGrabAnimation.AnimationPlay();
        }
        private void Start()
        {
            if(source != null) source.clip = GunShotClip;
            timeLastFired = 0;
            lastScopeState = scopeActive;
        }

        private void Update()
        {
            // --- If rotate is set to true, rotate the weapon in scene ---
            if (rotate)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y 
                                                                        + rotationSpeed, transform.localEulerAngles.z);
            }

            // --- Fires the weapon if the delay time period has passed since the last shot ---
            if ((autoFire && ((timeLastFired + shotDelay) <= Time.time)) || Input.GetMouseButtonDown(0))
            {
                if(weaponResources.WeaponsResources[chosenWeaponScript.ChosenType] > 0)
                {
                    FireWeapon();
                    Events.OnUsingWeapon?.Invoke(chosenWeaponScript.ChosenType);
                    Events.OnWeaponResourcesEnded?.Invoke(chosenWeaponScript.ChosenType);
                }
            }

            // --- Toggle scope based on public variable value ---
            if(scope && lastScopeState != scopeActive)
            {
                lastScopeState = scopeActive;
                scope.SetActive(scopeActive);
            }
        }

        /// <summary>
        /// Creates an instance of the muzzle flash.
        /// Also creates an instance of the audioSource so that multiple shots are not overlapped on the same audio source.
        /// Insert projectile code in this function.
        /// </summary>
        public void FireWeapon()
        {
            playerAudioSource.PlayOneShot(GunShotClip);

            // --- Keep track of when the weapon is being fired ---
            timeLastFired = Time.time;

            // --- Spawn muzzle flash ---
            var flash = Instantiate(muzzlePrefab);

            // --- Shoot Projectile Object ---
            if (projectilePrefab != null)
            {
                GameObject newProjectile = Instantiate(projectilePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
            }

            // --- Insert custom code here to shoot projectile or hitscan from weapon ---

        }

        private void ReEnableDisabledProjectile()
        {
            reloadSource.Play();
            projectileToDisableOnFire.SetActive(true);
        }
    }
}