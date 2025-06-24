using GameNetcodeStuff;
using HarmonyLib;
using System;
using UnityEngine;

namespace CaptainLoot
{
    [HarmonyPatch(typeof(WhoopieCushionItem))]
    internal class WhoopieItemPatch
    {
        [HarmonyPatch(nameof(WhoopieCushionItem.Fart))]
        [HarmonyPostfix]
        public static void WhoopieAudioPatch(ref AudioClip[] ___fartAudios)
        {
            AudioClip[] newfartAudios = CaptainLootMod.newFartSFX;
            ___fartAudios = newfartAudios;
        }
    }
}

