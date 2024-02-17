namespace SmokeGrenade
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.API.Features.Attributes;
    using Exiled.API.Features.Pickups;
    using Exiled.API.Features.Spawn;
    using Exiled.CustomItems.API.Features;
    using Exiled.Events.EventArgs.Map;
    using InventorySystem.Items.Usables.Scp244;
    using MEC;
    using System.Collections.Generic;
    using UnityEngine;

    /// <inheritdoc />
    [CustomItem(ItemType.GrenadeFlash)]
    internal class SmokeGrenadeItem : CustomGrenade
    {
        public override ItemType Type { get; set; } = ItemType.GrenadeFlash;
        public override bool ExplodeOnCollision { get; set; } = true;
        public override float FuseTime { get; set; } = 1.5f;
        public override uint Id { get; set; } = 6786758;
        public override string Name { get; set; } = "SmokeGrenade";
        public override string Description { get; set; } = "Creating smoke when explodes for 30 seconds";
        public override float Weight { get; set; } = 0.65f;
        public override SpawnProperties SpawnProperties
        {
            get
            {
                return new SpawnProperties()
                {
                    Limit = 50,
                    DynamicSpawnPoints = new List<DynamicSpawnPoint>
                    {
                        new DynamicSpawnPoint()
                        {
                            Chance = 100,
                            Location = SpawnLocationType.InsideLocker,
                        },
                        new DynamicSpawnPoint()
                        {
                            Chance = 100,
                            Location = SpawnLocationType.InsideHczArmory,
                        },
                    }
                };
            }
            set
            {
                // Add your set logic here if needed
            }
        }

        protected override void OnExploding(ExplodingGrenadeEventArgs ev)
        {
            Log.Debug($"grenade on: {ev.Position}");

            if (ev.Projectile.Type != ItemType.GrenadeFlash)
                return;

            ev.IsAllowed = false;
            ev.TargetsToAffect.Clear();

            Scp244Pickup pickup = (Scp244Pickup)Pickup.CreateAndSpawn(ItemType.SCP244a, ev.Position, new Quaternion());
            pickup.State = Scp244State.Active;
            pickup.Health = 999999;
            pickup.Scale /= 50f;
            pickup.IsLocked = true;

            Timing.RunCoroutine(DestroyAfterDelay(pickup, 30f));
        }

        private IEnumerator<float> DestroyAfterDelay(Scp244Pickup pickup, float delay)
        {
            yield return Timing.WaitForSeconds(delay);

            if (pickup != null)
                pickup.Destroy();
        }
    }
}
