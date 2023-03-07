using System.Linq;
using HarmonyLib;
using UnityEngine;
using ChallengerMod;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using UnityEngine.AddressableAssets;

namespace ChallengerLevel.Mira
{
    [HarmonyPatch(typeof(ShipStatus))]
    public static class ShipStatusPatch
    {
        public static readonly Vector3 RoomDropShipNewPos = new Vector3(250f, 0f, 1f);
        public static readonly Vector3 ColliderDropShipNewPos = new Vector3(250f, 0f, 1f);
        public static readonly Vector3 RoomSkybridgeNewPos = new Vector3(0f, 0f, 30f);
        public static readonly Vector3 ColliderSkybridgeNewPos = new Vector3(250f, 0f, 1f);
        public static readonly Vector3 ColliderDecontamNewPos = new Vector3(250f, 0f, 1f);

        public static readonly Vector3 FixWiringConsole2NewPos = new Vector3(24.0514f, 15.5015f, 1f);
        public static readonly Vector3 launchGasNewPos = new Vector3(4.0343f, -1.6181f, 1f);
        public static readonly Vector3 divertElevStandNewPos = new Vector3(7.7835f, 2.5248f, 0f);
        public static readonly Vector3 launchpadrightNewPos = new Vector3(3.3f, 1.448f, 1f);
        public static readonly Vector3 EnterCodeConsoleNewPos = new Vector3(16.7972f, 4.4115f, -4f);
        public static readonly Vector3 admintablelowerNewPos = new Vector3(13.4159f, 15.4564f, 4f);
        public static readonly Vector3 SwitchConsoleNewPos = new Vector3(24.202f, 11.9755f, 2f);
        public static readonly Vector3 launchfrontNewPos = new Vector3(8.8201f, 10.2215f, 7.999f);
        public static readonly Vector3 SecurityLoggerNewPos = new Vector3(22.6845f, 13.189f, 19f); //-227.3155 13.189 18

        // launch-front
        public const float launchfrontNewScaleX = 1f;
        public const float launchfrontNewScaleY = 1f;
        public const float SecurityLoggerScaleX = 4.0779f;
        public const float SecurityLoggerScaleY = 3.22f;
        

        public const float SkybridgeNewScale = 100f;

        public static readonly Sprite NewTex1 = repairIco;

       





        public static readonly Vector3 YHallRightVentNewPos = new Vector3(23.6613f, 14.3152f, 1f);//-228.7387 14.2613
        public static readonly Vector3 LockerVentNewPos = new Vector3(9.1753f, 4.6213f, 1f); //(0.0953f, 2.6313f, 1f);
        public static readonly Vector3 DeconVentNewPos = new Vector3(2.1799f, 7.8f, 1f);//-247.8201 7.8
        public static readonly Vector3 LaunchVentNewPos = new Vector3(3.0767f, 0.4267f, 1f);//-246.9233 0.4267



        
        public static GameObject RoomDropShip;
        public static GameObject ColliderDropShip;
        public static GameObject RoomSkybridge;
        public static GameObject ColliderSkybridge;
        public static GameObject ColliderDecontam;


        public static bool IsAdjustmentsDone;
        public static bool IsObjectsFetched;
        public static bool IsVentsFetched;


        public static SecurityLogger SecurityLogger;

        public static Console FixWiringConsole2; //FixWiringConsole (2) //Yhall
        public static GameObject launchGas; //launch-gas 
        public static GameObject launchfront; //launch-pad-right
        public static GameObject admintablelower; //admin-tablelower
        public static Console divertElevStand;
        public static Console EnterCodeConsole;
        public static Console SwitchConsole;
        public static GameObject launchpadright; //launch-pad-right

        

       

        public static Vent BalconyVent;
        public static Vent MedVent;
        public static Vent LockerVent;
        public static Vent LabVent;
        public static Vent ReactorVent;
        public static Vent YHallRightVent;
        public static Vent DeconVent;
        public static Vent LaunchVent;
        public static Vent OfficeVent;
        public static Vent AdminVent;
        public static Vent AgriVent;

        




        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Begin))]
        public static class ShipStatusBeginPatch
        {
            [HarmonyPrefix]
            [HarmonyPatch]
            public static void Prefix(ShipStatus __instance)
            {
                ApplyChanges(__instance);
                
            }
        }

        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Awake))]
        public static class ShipStatusAwakePatch
        {
            [HarmonyPrefix]
            [HarmonyPatch]
            public static void Prefix(ShipStatus __instance)
            {
       
                ApplyChanges(__instance);
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
            if (instance.Type == ShipStatus.MapType.Hq)
            {
                FindMiraObjects();
                AdjustMira();
            }
            
        }

        public static void FindMiraObjects()
        {
            FindVents();
            FindObjects();
        }

        public static void AdjustMira()
        {
            if (IsObjectsFetched)
            {
                MooveRoomDropShip();
                MooveRoomSkybridge();
                MooveColliderDropShip();
                MooveColliderSkybridge();
                MooveColliderDecontam();
                MooveFixWiringConsole2();
                MoovelaunchGas();
                MoovedivertElevStand();
                Moovelaunchpadright();
                MooveDeconVent();
                MooveYHallRightVent();
                MooveLockerVent();
                MooveLaunchVent();
                MooveEnterCodeConsole();
                Mooveadmintablelower();
                MooveSwitchConsole();
                Moovelaunchfront();
                MooveSecurityLogger();


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

            if (BalconyVent == null)
            {
                BalconyVent = ventsList.Find(vent => vent.gameObject.name == "BalconyVent");
            }
            if (MedVent == null)
            {
                MedVent = ventsList.Find(vent => vent.gameObject.name == "MedVent");
            }
            if (LockerVent == null)
            {
                LockerVent = ventsList.Find(vent => vent.gameObject.name == "LockerVent");
            }
            if (LabVent == null)
            {
                LabVent = ventsList.Find(vent => vent.gameObject.name == "LabVent");
            }
            if (ReactorVent == null)
            {
                ReactorVent = ventsList.Find(vent => vent.gameObject.name == "ReactorVent");
            }
            if (YHallRightVent == null)
            {
                YHallRightVent = ventsList.Find(vent => vent.gameObject.name == "YHallRightVent");
            }
            if (DeconVent == null)
            {
                DeconVent = ventsList.Find(vent => vent.gameObject.name == "DeconVent");
            }
            if (LaunchVent == null)
            {
                LaunchVent = ventsList.Find(vent => vent.gameObject.name == "LaunchVent");
            }
            if (OfficeVent == null)
            {
                OfficeVent = ventsList.Find(vent => vent.gameObject.name == "OfficeVent");
            }
            if (AdminVent == null)
            {
                AdminVent = ventsList.Find(vent => vent.gameObject.name == "AdminVent");
            }
            if (AgriVent == null)
            {
                AgriVent = ventsList.Find(vent => vent.gameObject.name == "AgriVent");
            }
            




           IsVentsFetched = BalconyVent != null && MedVent != null && LockerVent != null && LabVent != null &&
                ReactorVent != null && YHallRightVent != null && DeconVent != null && LaunchVent != null &&
                 OfficeVent != null && AdminVent != null && AgriVent != null;
        }
        
        public static void FindObjects()
        {


            
            if (SecurityLogger == null)
            {
                SecurityLogger = Object.FindObjectsOfType<SecurityLogger>().ToList()
                    .Find(SecurityLogger => SecurityLogger.name == "SecurityLogger");
            }

            if (FixWiringConsole2 == null)
            {
                FixWiringConsole2 = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "FixWiringConsole (2)");
            }
            if (EnterCodeConsole == null)
            {
                EnterCodeConsole = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "EnterCodeConsole");
            }
            if (SwitchConsole == null)
            {
                SwitchConsole = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "SwitchConsole");
            }
            
            if (launchfront == null)
            {
                launchfront = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(gameObject => gameObject.name == "launch-front");
            }
            if (launchGas == null)
            {
                launchGas = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(gameObject => gameObject.name == "launch-gas");
            }
            if (admintablelower == null)
            {
                admintablelower = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(gameObject => gameObject.name == "admin-tablelower");
            }
            if (divertElevStand == null)
            {

                divertElevStand = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "DivertPowerConsole (10)");
            }
            if (launchpadright == null)
            {
                launchpadright = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(gameObject => gameObject.name == "launch-pad-right");
            }

            if (RoomDropShip == null)
            {
                RoomDropShip = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(gameObject => gameObject.name == "launchPadWalls");
            }
            
            if (RoomSkybridge == null)
            {
                RoomSkybridge = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(gameObject => gameObject.name == "skyBridgeWalls");
            }
            if (ColliderDropShip == null)
            {
                ColliderDropShip = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(gameObject => gameObject.name == "LaunchPad");
            }
            if (ColliderSkybridge == null)
            {
                ColliderSkybridge = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(gameObject => gameObject.name == "SkyBridge");
            }
            if (ColliderDecontam == null)
            {
                ColliderDecontam = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(gameObject => gameObject.name == "Decontam");
            }
            var ventsList = Object.FindObjectsOfType<Vent>().ToList();


            




            IsObjectsFetched = SecurityLogger != null && RoomDropShip != null && RoomSkybridge != null && ColliderDropShip != null && ColliderSkybridge != null && ColliderDecontam != null
                && FixWiringConsole2 != null && launchGas != null && divertElevStand != null && launchpadright != null && EnterCodeConsole != null && SwitchConsole != null && admintablelower != null && launchfront != null;
                
        }



        public static void AdjustVents()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)// V1
            {
                if (IsVentsFetched)
                {
                    AgriVent.Left = LaunchVent;
                    AgriVent.Center = null;
                    AgriVent.Right = null;

                    LaunchVent.Left = AgriVent;
                    LaunchVent.Center = null;
                    LaunchVent.Right = null;





                    ReactorVent.Left = DeconVent;
                    ReactorVent.Center = LockerVent;
                    ReactorVent.Right = null;

                    DeconVent.Left = LockerVent;
                    DeconVent.Center = ReactorVent;
                    DeconVent.Right = null;

                    LockerVent.Left = DeconVent;
                    LockerVent.Center = ReactorVent;
                    LockerVent.Right = null;



                    YHallRightVent.Left = BalconyVent;
                    YHallRightVent.Center = null;
                    YHallRightVent.Right = MedVent;

                    BalconyVent.Left = YHallRightVent;
                    BalconyVent.Center = null;
                    BalconyVent.Right = MedVent;

                    MedVent.Left = YHallRightVent;
                    MedVent.Center = null;
                    MedVent.Right = BalconyVent;



                    LabVent.Left = OfficeVent;
                    LabVent.Center = AdminVent;
                    LabVent.Right = null;

                    OfficeVent.Left = LabVent;
                    OfficeVent.Center = AdminVent;
                    OfficeVent.Right = null;

                    AdminVent.Left = LabVent;
                    AdminVent.Center = OfficeVent;
                    AdminVent.Right = null;

                }
            }
        }




        

        public static void MooveYHallRightVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (YHallRightVent.transform.position != YHallRightVentNewPos)
                {
                    Transform YHallRightVentTransform = YHallRightVent.transform;
                    YHallRightVentTransform.position = YHallRightVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void MooveSecurityLogger()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (SecurityLogger.transform.position != SecurityLoggerNewPos)
                {
                    Transform SecurityLoggerTransform = SecurityLogger.transform;
                    SecurityLoggerTransform.position = SecurityLoggerNewPos;

                    var localScale = SecurityLoggerTransform.localScale;
                    localScale =
                        new Vector3(SecurityLoggerScaleX, SecurityLoggerScaleY, localScale.z
                          );
                    SecurityLoggerTransform.localScale = localScale;
                }
            }
            else
            {

            }
        }

        public static void Mooveadmintablelower()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (admintablelower.transform.position != admintablelowerNewPos)
                {
                    Transform admintablelowerTransform = admintablelower.transform;
                    admintablelowerTransform.position = admintablelowerNewPos;
                }
            }
            else
            {

            }
        }
        public static void MooveSwitchConsole()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (SwitchConsole.transform.position != SwitchConsoleNewPos)
                {
                    Transform SwitchConsoleTransform = SwitchConsole.transform;
                    SwitchConsoleTransform.position = SwitchConsoleNewPos;
                }
            }
            else
            {

            }
        }
        public static void MooveDeconVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (DeconVent.transform.position != DeconVentNewPos)
                {
                    Transform DeconVentTransform = DeconVent.transform;
                    DeconVentTransform.position = DeconVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void MooveLockerVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (LockerVent.transform.position != LockerVentNewPos)
                {
                    Transform LockerVentTransform = LockerVent.transform;
                    LockerVentTransform.position = LockerVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void MooveLaunchVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (LaunchVent.transform.position != LaunchVentNewPos)
                {
                    Transform LaunchVentTransform = LaunchVent.transform;
                    LaunchVentTransform.position = LaunchVentNewPos;
                }
            }
            else
            {

            }
        }

        public static void MooveRoomDropShip()
         {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (RoomDropShip.transform.position != RoomDropShipNewPos)
                {
                    Transform RoomDropShipTransform = RoomDropShip.transform;
                    RoomDropShipTransform.position = RoomDropShipNewPos;
                }
            }
            else
            {

            }
            

         }
         public static void MooveRoomSkybridge()
         {

            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (RoomSkybridge.transform.position != RoomSkybridgeNewPos)
                {
                    Transform RoomSkybridgeTransform = RoomSkybridge.transform;
                    RoomSkybridgeTransform.position = RoomSkybridgeNewPos;

                    var localScale = RoomSkybridgeTransform.localScale;
                    localScale =
                        new Vector3(SkybridgeNewScale, SkybridgeNewScale, SkybridgeNewScale
                          );
                    RoomSkybridgeTransform.localScale = localScale;
                }
            }
            else
            {

            }

            
        }
        public static void MooveColliderDropShip()
        {

            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (ColliderDropShip.transform.position != ColliderDropShipNewPos)
                {
                    Transform ColliderDropShipTransform = ColliderDropShip.transform;
                    ColliderDropShipTransform.position = ColliderDropShipNewPos;
                }
            }
            else
            {

            }
            
        }
        public static void MooveColliderSkybridge()
        {

            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (ColliderSkybridge.transform.position != ColliderSkybridgeNewPos)
                {
                    Transform ColliderSkybridgeTransform = ColliderSkybridge.transform;
                    ColliderSkybridgeTransform.position = ColliderSkybridgeNewPos;

                    


                }
            }
            else
            {

            }
            
        }
        public static void MooveColliderDecontam()
        {

            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (ColliderDecontam.transform.position != ColliderDecontamNewPos)
                {
                    Transform ColliderDecontamTransform = ColliderDecontam.transform;
                    ColliderDecontamTransform.position = ColliderDecontamNewPos;
                }
            }
            else
            {

            }
            
        }
        public static void MooveFixWiringConsole2()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (FixWiringConsole2.transform.position != FixWiringConsole2NewPos)
                {
                    Transform FixWiringConsole2Transform = FixWiringConsole2.transform;
                    FixWiringConsole2Transform.position = FixWiringConsole2NewPos;
                }
            }
            else
            {

            }
        }
        public static void MoovelaunchGas()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (launchGas.transform.position != launchGasNewPos)
                {
                    Transform launchGasTransform = launchGas.transform;
                    launchGasTransform.position = launchGasNewPos;
                }
            }
            else
            {

            }
        }
        public static void Moovelaunchfront()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (launchfront.transform.position != launchfrontNewPos)
                {

                    Transform launchfrontTransform = launchfront.transform;
                    launchfrontTransform.position = launchfrontNewPos;

                    var localScale = launchfrontTransform.localScale;
                    localScale =
                        new Vector3(launchfrontNewScaleX, launchfrontNewScaleY, localScale.z
                          );
                    launchfrontTransform.localScale = localScale;

                    
                }
                
            }
            else
            {

            }
        }
        public static void MoovedivertElevStand()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (divertElevStand.transform.position != divertElevStandNewPos)
                {
                    Transform divertElevStandTransform = divertElevStand.transform;
                    divertElevStandTransform.position = divertElevStandNewPos;
                }
            }
            else
            {

            }
        }

        public static void MooveEnterCodeConsole()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (EnterCodeConsole.transform.position != EnterCodeConsoleNewPos)
                {
                    Transform EnterCodeConsoleTransform = EnterCodeConsole.transform;
                    EnterCodeConsoleTransform.position = EnterCodeConsoleNewPos;
                }
            }
            else
            {

            }
        }
        public static void Moovelaunchpadright()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() ==1)
            {
                if (launchpadright.transform.position != launchpadrightNewPos)
                {
                    Transform launchpadrightTransform = launchpadright.transform;
                    launchpadrightTransform.position = launchpadrightNewPos;
                }
            }
            else
            {

            }
        }
        
    }
}