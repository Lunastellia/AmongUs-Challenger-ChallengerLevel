using System.Linq;
using HarmonyLib;
using UnityEngine;
using ChallengerMod;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;

namespace ChallengerLevel.Polus
{
    [HarmonyPatch(typeof(ShipStatus))]
    public static class ShipStatusPatch
    {
        // Positions
        //BETTERPOLUS v1
        public static readonly Vector3 DvdScreenNewPos = new Vector3(26.635f, -15.92f, 1f);
        public static readonly Vector3 VitalsNewPos = new Vector3(31.275f, -6.45f, 1f);
        public static readonly Vector3 WifiNewPos = new Vector3(15.975f, 0.084f, 1f);
        public static readonly Vector3 NavNewPos = new Vector3(11.07f, -15.298f, -0.015f);
        public static readonly Vector3 TempColdNewPos = new Vector3(7.772f, -17.103f, -0.017f);




        //BETTERPOLUS v2
        public static readonly Vector3 ElecFenceVentNewPos = new Vector3(7.2f, -14.6f, 2f);
        public static readonly Vector3 BathroomVentNewPos = new Vector3(33.7f, -10.6f, 2f);
        public static readonly Vector3 panelelectricalbathroomNewPos = new Vector3(21.63f, -13.35f, 2f);
        public static readonly Vector3 panelwaterwheelRightNewPos = new Vector3(33.7473f, -22.3701f, 2f);
        public static readonly Vector3 CardIDNewPos = new Vector3(31.1484f, -23.9629f, 1f);
        public static readonly Vector3 BoxNewPos = new Vector3(24.7611f, -16.3607f, 1f); // -11.6889 4.3923
        public static readonly Vector3 ScienceBuildingVentNewPos = new Vector3(30.412f, -17.182f, 2f);
        public static readonly Vector3 panelelectricalScienceHallNewPos = new Vector3(32.957f, -9.064f, 2f);
        public static readonly Vector3 ElectricBuildingVentNewPos  = new Vector3(33.956f, -25.6254f, 2f);


        //EVENT


        public const float DvdScreenNewScale = 0.75f;
    

        // Checks
        public static bool IsAdjustmentsDone;
        public static bool IsObjectsFetched;
        public static bool IsRoomsFetched;
        public static bool IsVentsFetched;

        // Tasks Tweak
        public static Console WifiConsole;
        public static Console NavConsole;
        public static Console panelelectricalbathroom;
        public static Console CardID;
        public static Console Box;
        public static Console panelwaterwheelRight;
        public static Console panelelectricalScienceHall;

        // Vitals Tweak
        public static SystemConsole Vitals;
        public static GameObject DvdScreenOffice;

       

        // Vents Tweak
        public static Vent ElectricBuildingVent;
        public static Vent ElectricalVent;
        public static Vent ScienceBuildingVent;
        public static Vent StorageVent;
        public static Vent BathroomVent;
        public static Vent ElecFenceVent;


        // TempCold Tweak
        public static Console TempCold;
        
        // Rooms
        public static GameObject Comms;
        public static GameObject DropShip;
        public static GameObject Outside;
        public static GameObject Science;
        public static GameObject RightPod;
        public static GameObject Office;
        public static GameObject Polusroom;
        

        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Begin))]
        public static class ShipStatusBeginPatch
        {
            [HarmonyPrefix]
            [HarmonyPatch]       
            public static void Prefix(ShipStatus __instance)
            {
              //  if ((ChallengerOS.Utils.Option.CustomOptionHolder.BetterMap.getSelection() == 1))
              //  {
                    ApplyChanges(__instance);
              //  }
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
               // {
                    ApplyChanges(__instance);
               // }
            }
        }

        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.FixedUpdate))]
        public static class ShipStatusFixedUpdatePatch
        {
            [HarmonyPrefix]
            [HarmonyPatch]
            public static void Prefix(ShipStatus __instance)
            {
                if (!IsObjectsFetched || !IsAdjustmentsDone)
                {
                    ApplyChanges(__instance);
                }
            }
        }

        private static void ApplyChanges(ShipStatus instance)
        {
            if (instance.Type == ShipStatus.MapType.Pb)
            {
                FindPolusObjects();
                AdjustPolus();
            }
        }

        public static void FindPolusObjects()
        {
            FindVents();
            FindRooms();
            FindObjects();
        }

        public static void AdjustPolus()
        {
            if (IsObjectsFetched && IsRoomsFetched)
            {
                MoveVitals();
                SwitchNavWifi();
                MoveTempCold();
                MoveElectricBuildingVent(); //7.2 -14.6 2
                MoveScienceBuildingVent(); //7.2 -14.6 2
                MoveElecFenceVent(); //7.2 -14.6 2
                Movepolus(); 

                MoveBathroomVent(); // 33.7 -10.6 2
                Movepanelelectricalbathroom(); // 32.3 -8.94 2
                MovepanelwaterwheelRight();
                MovepanelelectricalScienceHall();
                MoveCardID();
                
            }
            else
            {
            }

            AdjustVents();

            IsAdjustmentsDone = true;
        }
        
        // --------------------
        // - Objects Fetching -
        // --------------------

        public static void FindVents()
        {
            var ventsList = Object.FindObjectsOfType<Vent>().ToList();
            
            if (ElectricBuildingVent == null)
            {
                ElectricBuildingVent = ventsList.Find(vent => vent.gameObject.name == "ElectricBuildingVent");
            }
            
            if (ElectricalVent == null)
            {
                ElectricalVent = ventsList.Find(vent => vent.gameObject.name == "ElectricalVent");
            }
            
            if (ScienceBuildingVent == null)
            {
                ScienceBuildingVent = ventsList.Find(vent => vent.gameObject.name == "ScienceBuildingVent");
            }
            
            if (StorageVent == null)
            {
                StorageVent = ventsList.Find(vent => vent.gameObject.name == "StorageVent");
            }


            IsVentsFetched = ElectricBuildingVent != null && ElectricalVent != null && ScienceBuildingVent != null && StorageVent != null;
                              
        }

        public static void FindRooms()
        {
            if (Comms == null)
            {
                Comms = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Comms");
            }
            
            if (DropShip == null)
            {
                DropShip = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Dropship");
            }

            if (Outside == null)
            {
                Outside = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Outside");
            }
            
            if (Science == null)
            {
                Science = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Science");
            }
            if (RightPod == null)
            {
                RightPod = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "RightPod");
            }
            if (Office == null)
            {
                Office = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Office");
            }
            


            IsRoomsFetched = Comms != null && DropShip != null && Outside != null && Science != null && RightPod != null && Office != null;
        }

        public static void FindObjects()
        {
            if (WifiConsole == null)
            {
                WifiConsole = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "panel_wifi");
            }

            if (NavConsole == null)
            {
                NavConsole = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "panel_nav");
            }
            if (panelelectricalbathroom == null)
            {
                panelelectricalbathroom = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "panel_electrical_bathroom");
            }
            if (panelwaterwheelRight == null)
            {
                panelwaterwheelRight = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "panel_waterwheelRight");
            }
            if (Box == null)
            {
                Box = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "panel_cooler1");
            }

            

            if (CardID == null)
            {
                CardID = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "panel_scanID");
            }
            if (panelelectricalScienceHall == null)
            {
                panelelectricalScienceHall = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "panel_electrical_sciencehall");
            }

            if (Vitals == null)
            {
                Vitals = Object.FindObjectsOfType<SystemConsole>().ToList()
                    .Find(console => console.name == "panel_vitals");
                
            }
                
            if (DvdScreenOffice == null)
            {
                GameObject DvdScreenAdmin = Object.FindObjectsOfType<GameObject>().ToList()
                    .Find(o => o.name == "dvdscreen");

                if (DvdScreenAdmin != null)
                {
                    DvdScreenOffice = Object.Instantiate(DvdScreenAdmin);
                    
                }
            }
            

            if (TempCold == null)
            {
                TempCold = Object.FindObjectsOfType<Console>().ToList()
                    .Find(console => console.name == "panel_tempcold");
            }
            var ventsList = Object.FindObjectsOfType<Vent>().ToList();


            if (BathroomVent == null)
            {
                BathroomVent = ventsList.Find(vent => vent.gameObject.name == "BathroomVent");
            }
            if (ElecFenceVent == null)
            {
                ElecFenceVent = ventsList.Find(vent => vent.gameObject.name == "ElecFenceVent");
            }


            IsObjectsFetched = WifiConsole != null && NavConsole != null && Vitals != null && panelelectricalScienceHall != null &&
                               DvdScreenOffice != null && TempCold != null  && BathroomVent != null && ElecFenceVent != null && 
                               panelelectricalbathroom != null && CardID != null && panelwaterwheelRight != null && Box != null
                               /* &&
                               LobbyLevel_NewTexture != null && LobbyLevel_Texture1 != null && LobbyLevel_Texture2 != null
                               && LobbyLevel_Texture3 != null && LobbyLevel_Texture4 != null && LobbyLevel_Collider1 != null
                               && LobbyLevel_Collider2 != null && LobbyLevel_Collider3 != null && LobbyLevel_Collider4 != null
                               && LobbyLevel_Collider5 != null && LobbyLevel_Collider6 != null && LobbyLevel_Collider7 != null && PolusSpeciment != null
                               */
                               ;
        } 

        // -------------------
        // - Map Adjustments -
        // -------------------
        
        public static void AdjustVents()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 1) // V1
            {
                if (IsVentsFetched)
                {
                    ElectricBuildingVent.Left = ElectricalVent;
                    ElectricalVent.Center = ElectricBuildingVent;

                    ScienceBuildingVent.Left = StorageVent;
                    StorageVent.Center = ScienceBuildingVent;
                }
                else
                {
                }
            }
            else
            {

            }
        }
        
        public static void MoveTempCold()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() != 0)// V1+2
            {
                if (TempCold.transform.position != TempColdNewPos)
                {
                    Transform tempColdTransform = TempCold.transform;
                    tempColdTransform.parent = Outside.transform;
                    tempColdTransform.position = TempColdNewPos;

                    // Fixes collider being too high
                    BoxCollider2D collider = TempCold.GetComponent<BoxCollider2D>();
                    collider.isTrigger = false;
                    collider.size += new Vector2(0f, -0.3f);
                }
            }
            else
            {

            }
        }
        
        public static void SwitchNavWifi()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() != 0)// V1+2
            {
                if (WifiConsole.transform.position != WifiNewPos)
                {
                    Transform wifiTransform = WifiConsole.transform;
                    wifiTransform.parent = DropShip.transform;
                    wifiTransform.position = WifiNewPos;
                }

                if (NavConsole.transform.position != NavNewPos)
                {
                    Transform navTransform = NavConsole.transform;
                    navTransform.parent = Comms.transform;
                    navTransform.position = NavNewPos;

                    // Prevents crewmate being able to do the task from outside
                    NavConsole.checkWalls = true;
                }
            }
            else
            {

            }
        }
       public static void Movepanelelectricalbathroom()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {
                if (panelelectricalbathroom.transform.position != panelelectricalbathroomNewPos)
                {
                    Transform panelelectricalbathroomTransform = panelelectricalbathroom.transform;
                    panelelectricalbathroomTransform.parent = Science.transform;
                    panelelectricalbathroomTransform.position = panelelectricalbathroomNewPos;

                }
            }
            else
            {

            }

           
        }
        public static void MovepanelelectricalScienceHall()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {
                if (panelelectricalScienceHall.transform.position != panelelectricalScienceHallNewPos)
                {
                    Transform MovepanelelectricalScienceHallTransform = panelelectricalScienceHall.transform;
                    MovepanelelectricalScienceHallTransform.position = panelelectricalScienceHallNewPos;

                }
            }
            else
            {

            }


        }
        public static void MovepanelwaterwheelRight()
        {

            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {

                if (panelwaterwheelRight.transform.position != panelwaterwheelRightNewPos)
                {
                    Transform panelwaterwheelRightTransform = panelwaterwheelRight.transform;
                    panelwaterwheelRightTransform.parent = RightPod.transform;
                    panelwaterwheelRightTransform.position = panelwaterwheelRightNewPos;

                }
                
            }
            else
            {
                
            }


        }
        public static void Movepolus()
        {

            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {

                if (GameObject.Find("PolusShip(Clone)").transform.FindChild("RightTube").transform.FindChild("Walls"))
                {
                    GameObject.Find("PolusShip(Clone)").transform.FindChild("RightTube").transform.FindChild("Walls").gameObject.SetActive(false);
                }

            }
            else
            {

            }


        }
        public static void MoveCardID()
        {

            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {

                if (CardID.transform.position != CardIDNewPos)
                {
                    Transform CardIDTransform = CardID.transform;
                    CardIDTransform.parent = RightPod.transform;
                    CardIDTransform.position = CardIDNewPos;

                }

            }
            else
            {

            }


        }
        public static void MoveBox()
        {

            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {

                if (Box.transform.position != BoxNewPos)
                {
                    Transform BoxTransform = Box.transform;
                    //BoxTransform.parent = Office.transform;
                    BoxTransform.position = BoxNewPos;

                }

            }
            else
            {

            }


        }
        public static void MoveVitals()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() != 0)// V1+2
            {
                if (Vitals.transform.position != VitalsNewPos)
                {
                    // Vitals
                    Transform vitalsTransform = Vitals.gameObject.transform;
                    vitalsTransform.parent = Science.transform;
                    vitalsTransform.position = VitalsNewPos;
                }

                if (DvdScreenOffice.transform.position != DvdScreenNewPos)
                {
                    // DvdScreen
                    Transform dvdScreenTransform = DvdScreenOffice.transform;
                    dvdScreenTransform.position = DvdScreenNewPos;


                    //var DvdScreenOffices = GameObject.Find("dvdscreen");
                    //menuHostBanner.transform.localPosition = new Vector3(0.85f, -11.235f, -1);
                    //DvdScreenOffices.transform.localPosition = new Vector3(1.1f, -12.5f, 3.12f);


                    var localScale = dvdScreenTransform.localScale;
                    localScale =
                        new Vector3(DvdScreenNewScale, localScale.y,
                            localScale.z);
                    dvdScreenTransform.localScale = localScale;
                }
            }
            else
            {

            }
        }
        public static void MoveElecFenceVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {
                if (ElecFenceVent.transform.position != ElecFenceVentNewPos)
                {
                    Transform ElecFenceVentTransform = ElecFenceVent.transform;
                    ElecFenceVentTransform.position = ElecFenceVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void MoveElectricBuildingVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {
                if (ElectricBuildingVent.transform.position != ElectricBuildingVentNewPos)
                {
                    Transform ElectricBuildingVentTransform = ElectricBuildingVent.transform;
                    ElectricBuildingVentTransform.position = ElectricBuildingVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void MoveScienceBuildingVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {
                if (ScienceBuildingVent.transform.position != ScienceBuildingVentNewPos)
                {
                    Transform ScienceBuildingVentTransform = ScienceBuildingVent.transform;
                    ScienceBuildingVentTransform.position = ScienceBuildingVentNewPos;
                }
            }
            else
            {

            }
        }
        public static void MoveBathroomVent()
        {
            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
            {
                if (BathroomVent.transform.position != BathroomVentNewPos)
                {
                    Transform BathroomVentTransform = BathroomVent.transform;
                    BathroomVentTransform.position = BathroomVentNewPos;
                }
            }
            else
            {

            }
        }

        

        




    }
}