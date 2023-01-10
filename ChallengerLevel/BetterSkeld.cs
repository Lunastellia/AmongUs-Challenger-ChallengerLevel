using System.Linq;
using HarmonyLib;
using UnityEngine;
using ChallengerMod;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;

namespace ChallengerLevel.Skeld
{
    [HarmonyPatch(typeof(ShipStatus))]
    public static class ShipStatusPatch
    {
        public static readonly Vector3 ReactorVentNewPos = new Vector3(-2.95f, -10.95f, 2f);
        public static readonly Vector3 ShieldsVentNewPos = new Vector3(2f, -15f, 2f);
        public static readonly Vector3 BigYVentNewPos = new Vector3(5.2f, -4.85f, 2f);
        public static readonly Vector3 NavVentNorthNewPos = new Vector3(-11.85f, -11.55f, 2f);
        public static readonly Vector3 CafeVentNewPos = new Vector3(-3.9f, 5.5f, 2f);

        public static bool IsAdjustmentsDone;
        public static bool IsObjectsFetched;
        public static bool IsVentsFetched;

        public static Vent NavVentSouth;
        public static Vent NavVentNorth;
        public static Vent ShieldsVent;
        public static Vent WeaponsVent;
        public static Vent REngineVent;
        public static Vent UpperReactorVent;
        public static Vent LEngineVent;
        public static Vent ReactorVent;
          public static Vent BigYVent;
          public static Vent CafeVent;
    
       
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Begin))]
        public static class ShipStatusBeginPatch
        {
            [HarmonyPrefix]
            [HarmonyPatch]       
            public static void Prefix(ShipStatus __instance)
            {
               // if ((ChallengerOS.Utils.Option.CustomOptionHolder.BetterMap.getSelection() == 1))
               // {
                    ApplyChanges(__instance);
               // }
            }
        }

        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Awake))]
        public static class ShipStatusAwakePatch
        {
            [HarmonyPrefix]
            [HarmonyPatch]
            public static void Prefix(ShipStatus __instance)
            {
               // if ((ChallengerOS.Utils.Option.CustomOptionHolder.BetterMap.getSelection() == 1))
              //  {
                    ApplyChanges(__instance);
              //  }
            }
        }

        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.FixedUpdate))]
        public static class ShipStatusFixedUpdatePatch
        {
            [HarmonyPrefix]
            [HarmonyPatch]
            public static void Prefix(ShipStatus __instance)
            {
                if (!IsAdjustmentsDone)
                {
                    ApplyChanges(__instance);
                }
            }
        }

        private static void ApplyChanges(ShipStatus instance)
        {
            if (instance.Type == ShipStatus.MapType.Ship)
            {
                FindSkeldObjects();
                AdjustSkeld();
            }
        }

        public static void FindSkeldObjects()
        {
            FindVents();
            FindObjects(); 
        }

        public static void AdjustSkeld()
        {
            if (IsObjectsFetched)
            {
               MoveReactorVent();
               MoveShieldsVent();
               MoveBigYVent();
               MoveNavVentNorth();
               MoveCafeVent();
                DestroyAf();
            }
            else
            {
            }
            
            AdjustVents();

            IsAdjustmentsDone = true;
        }
        
  
        public static void FindVents()
        {
            var ventsList = Object.FindObjectsOfType<Vent>().ToList();
            

            if (NavVentSouth == null)
            {
                NavVentSouth = ventsList.Find(vent => vent.gameObject.name == "NavVentSouth");
            }
            
            if (NavVentNorth == null)
            {
                NavVentNorth = ventsList.Find(vent => vent.gameObject.name == "NavVentNorth");
            }
            
            if (ShieldsVent == null)
            {
                ShieldsVent = ventsList.Find(vent => vent.gameObject.name == "ShieldsVent");
            }
            
            if (WeaponsVent == null)
            {
                WeaponsVent = ventsList.Find(vent => vent.gameObject.name == "WeaponsVent");
            }
            if (REngineVent == null)
            {
                REngineVent = ventsList.Find(vent => vent.gameObject.name == "REngineVent");
            }
            
            if (UpperReactorVent == null)
            {
                UpperReactorVent = ventsList.Find(vent => vent.gameObject.name == "UpperReactorVent");
            }
            
            if (LEngineVent == null)
            {
                LEngineVent = ventsList.Find(vent => vent.gameObject.name == "LEngineVent");
            }
            
            if (ReactorVent == null)
            {
                ReactorVent = ventsList.Find(vent => vent.gameObject.name == "ReactorVent");
            }

            IsVentsFetched = NavVentSouth != null && NavVentNorth != null && ShieldsVent != null &&
                              WeaponsVent != null && REngineVent != null && UpperReactorVent != null && LEngineVent != null && ReactorVent != null;
        }

       
       public static void FindObjects()
        {
            var ventsList = Object.FindObjectsOfType<Vent>().ToList();
            
            if (ReactorVent == null)
            {
                ReactorVent = ventsList.Find(vent => vent.gameObject.name == "ReactorVent");
            }
            if (ShieldsVent == null)
            {
                ShieldsVent = ventsList.Find(vent => vent.gameObject.name == "ShieldsVent");
            }
            if (BigYVent == null)
            {
                BigYVent = ventsList.Find(vent => vent.gameObject.name == "BigYVent");
            }
            if (NavVentNorth == null)
            {
                NavVentNorth = ventsList.Find(vent => vent.gameObject.name == "NavVentNorth");
            }
            if (CafeVent == null)
            {
                CafeVent = ventsList.Find(vent => vent.gameObject.name == "CafeVent");
            }

            IsObjectsFetched = ReactorVent != null && ShieldsVent != null && BigYVent != null &&
                              NavVentNorth != null && CafeVent != null;
        }



        public static void AdjustVents()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapSK.getSelection() == 1)// V1
            {
                if (IsVentsFetched)
                {
                    WeaponsVent.Right = NavVentNorth;
                    WeaponsVent.Left = NavVentSouth;
                    NavVentNorth.Right = ShieldsVent;
                    NavVentNorth.Left = WeaponsVent;
                    NavVentSouth.Right = ShieldsVent;
                    NavVentSouth.Left = WeaponsVent;
                    ShieldsVent.Right = NavVentNorth;
                    ShieldsVent.Left = NavVentSouth;

                    LEngineVent.Right = ReactorVent;
                    LEngineVent.Left = UpperReactorVent;
                    UpperReactorVent.Right = LEngineVent;
                    UpperReactorVent.Left = REngineVent;
                    ReactorVent.Right = LEngineVent;
                    ReactorVent.Left = REngineVent;
                    REngineVent.Right = ReactorVent;
                    REngineVent.Left = UpperReactorVent;
                }
                else
                {
                }
            }
            else
            {

            }
        }
        
      
      
      
      
      
      
        public static void MoveReactorVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapSK.getSelection() == 1)// V1
            {
                if (ReactorVent.transform.position != ReactorVentNewPos)
                {
                    Transform ReactorVentTransform = ReactorVent.transform;
                    ReactorVentTransform.position = ReactorVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void MoveShieldsVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapSK.getSelection() == 1)// V1
            {
                if (ShieldsVent.transform.position != ShieldsVentNewPos)
                {
                    Transform ShieldsVentTransform = ShieldsVent.transform;
                    ShieldsVentTransform.position = ShieldsVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void MoveBigYVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapSK.getSelection() == 1)// V1
            {
                if (BigYVent.transform.position != BigYVentNewPos)
                {
                    Transform BigYVentTransform = BigYVent.transform;
                    BigYVentTransform.position = BigYVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void MoveNavVentNorth()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapSK.getSelection() == 1)// V1
            {
                if (NavVentNorth.transform.position != NavVentNorthNewPos)
                {
                    Transform NavVentNorthTransform = NavVentNorth.transform;
                    NavVentNorthTransform.position = NavVentNorthNewPos;
                }
            }
            else
            {

            }
        }
        public static void MoveCafeVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapSK.getSelection() == 1)// V1
            {
                if (CafeVent.transform.position != CafeVentNewPos)
                {
                    Transform CafeVentTransform = CafeVent.transform;
                    CafeVentTransform.position = CafeVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void DestroyAf()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 1)// V2
            {



                if (GameObject.Find("LobbyLevel_GameObject"))
                {
                    var AfDestroy = GameObject.Find("LobbyLevel_GameObject");
                    AfDestroy.transform.localPosition = new Vector3(99f, 99f, 0);
                }

               


            }
            else
            {
                if (GameObject.Find("LobbyLevel_GameObject"))
                {
                    var AfDestroy = GameObject.Find("LobbyLevel_GameObject");
                    AfDestroy.transform.localPosition = new Vector3(99f, 99f, 0);
                }
            }
        }


    }
}