using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using UnityEngine;


namespace CaptainLoot
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class CaptainLootMod : BaseUnityPlugin
    {
        private const string modGUID = "CaptainLoot.WhoopieMod";
        private const string modName = "Whoopie Loot Mod";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static CaptainLootMod Instance;

        internal ManualLogSource mls;

        internal static AudioClip[] newFartSFX;
        internal static AudioClip[] newRoarSFX;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo($"{modGUID} is loading.");

            string dllPath = Instance.Info.Location;
            string dllName = "CaptainLog.dll";
            string pluginPath = dllPath.TrimEnd(dllName.ToCharArray());
            string assetPath = pluginPath + "captainlootaudio";
            string assetPathWorm = pluginPath + "captainlootworm";

            //Whoopie Patch
            AssetBundle valFarts = AssetBundle.LoadFromFile(assetPath);
            if (valFarts == null)
            {
                mls.LogError("Failed to load audio assets!");
                return;
            }
            newFartSFX = valFarts.LoadAllAssets<AudioClip>();     
           


            //Sandworm Patch
            AssetBundle valRoar = AssetBundle.LoadFromFile(assetPathWorm);
            if (valRoar == null)
            {
                mls.LogError("Failed to load audio assets!");
                return;
            }
            newRoarSFX = valRoar.LoadAssetWithSubAssets<AudioClip>("assets/imjerrod.wav");


            harmony.PatchAll(typeof(WhoopieItemPatch));
            harmony.PatchAll(typeof(SandwormPatch));
            //harmony.PatchAll();



            mls.LogInfo($"{modGUID} is loaded. Loot Away!!!");
        }


    }  

    

}