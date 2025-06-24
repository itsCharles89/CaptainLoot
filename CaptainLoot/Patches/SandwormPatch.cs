using GameNetcodeStuff;
using HarmonyLib;
using System;
using UnityEngine;

namespace CaptainLoot
{
    [HarmonyPatch(typeof(SandWormAI))]
    internal class SandwormPatch
    {
        [HarmonyPatch(nameof(SandWormAI.Start))]
        [HarmonyPostfix]
        public static void SandWormAudioPatch(ref AudioClip[] ___roarSFX)
        {
            AudioClip[] newRoarSFX = CaptainLootMod.newRoarSFX;
            ___roarSFX = newRoarSFX;
        }
    }
}

