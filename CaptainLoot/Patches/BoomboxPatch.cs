using GameNetcodeStuff;
using HarmonyLib;
using System;
using UnityEngine;

namespace CaptainLoot
{
    [HarmonyPatch(typeof(BoomboxItem))]
    internal class BoomboxPatch
    {
        [HarmonyPatch(nameof(BoomboxItem.Start))]
        [HarmonyPostfix]
        public static void BoomboxAudioPatch(ref AudioClip[] ___musicAudios)
        {
            AudioClip[] newMusicAudios = CaptainLootMod.newMusicAudios;
            ___musicAudios = newMusicAudios;
        }
    }
}

