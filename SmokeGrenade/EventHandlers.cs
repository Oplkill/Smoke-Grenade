// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Map;
using MEC;
using System.Collections.Generic;

namespace SmokeGrenade
{
    internal class EventHandlers
    {
        public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            /*Log.Debug($"grenade on: {ev.Position}");

            if (ev.Projectile.Type != ItemType.GrenadeFlash)
                return;

            ev.IsAllowed = false;
            ev.TargetsToAffect.Clear();

            Scp244Pickup pickup = (Scp244Pickup)Pickup.CreateAndSpawn(ItemType.SCP244a, ev.Position, new Quaternion());
            pickup.State = Scp244State.Active;
            pickup.Health = 999999;
            pickup.Scale /= 50f;
            pickup.IsLocked = true;

            Timing.RunCoroutine(DestroyAfterDelay(pickup, 30f));*/
        }

        public IEnumerator<float> DestroyAfterDelay(Scp244Pickup pickup, float delay)
        {
            yield return Timing.WaitForSeconds(delay);

            if (pickup != null)
                pickup.Destroy();
        }
    }
}
