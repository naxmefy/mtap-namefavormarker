using HarmonyLib;
using JetBrains.Annotations;
using Pathea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityModManagerNet;

namespace MTAP_NameFavorMarker
{
#if DEBUG
    [EnableReloading]
#endif
    public class Main
    {
        public static KeyBinding key = new KeyBinding() { keyCode = KeyCode.F1 };
        
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = new Harmony(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            modEntry.OnUnload = Unload;
            modEntry.OnUpdate = OnUpdate;

            return true;
        }

        private static bool Unload(UnityModManager.ModEntry modEntry)
        {
            var harmony = new Harmony(modEntry.Info.Id);
            harmony.UnpatchAll(modEntry.Info.Id);

            // If you have created any dependent objects, they also need to be deleted.

            return true;
        }

        private static void OnUpdate(UnityModManager.ModEntry modEntry, float dt)
        {
            if (key.Down())
            {
                modEntry.Logger.Log("Hello World!");
            }
        }
    }
}
