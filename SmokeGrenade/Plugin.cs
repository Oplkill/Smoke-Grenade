// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Exiled.API.Features;
using Exiled.CustomItems.API;
using System;
using Map = Exiled.Events.Handlers.Map;

namespace SmokeGrenade
{
    public class SmokeGrenade : Plugin<Config, Translations>
    {
        public static SmokeGrenade Instance;
        public override Version Version => new Version(0, 0, 1);
        public override string Author => "Oplkill";
        public override string Name => "Smoke grenade";
        public override string Prefix => "SmokeGrenade";

        private EventHandlers _eventHandler;

        private SmokeGrenadeItem _smokeGrenadeItem = new SmokeGrenadeItem();

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            Log.Debug("Registering items..");
            //CustomItem.RegisterItems(overrideClass: Config.ItemConfigs);
            //CustomItem.RegisterItems(overrideClass: );
            Extensions.Register(_smokeGrenadeItem);

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
            Instance = null;
            Extensions.Unregister(_smokeGrenadeItem);

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _eventHandler = new EventHandlers();
            Map.ExplodingGrenade += _eventHandler.OnExplodingGrenade;
        }

        private void UnRegisterEvents()
        {
            Map.ExplodingGrenade -= _eventHandler.OnExplodingGrenade;
            _eventHandler = null;
        }
    }
}
