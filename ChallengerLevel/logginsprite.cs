using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using HarmonyLib;
using Hazel;
using UnityEngine.UI;
using UnityEngine.Events;
using Il2CppSystem.Collections;
using static ChallengerMod.HarmonyMain;
using System.IO;
using ChallengerMod.Utility.Utils;
using Twitch;
using System.Threading.Tasks;
using InnerNet;
using TMPro;
using System.Threading;

namespace ChallengerLevel
{

    public static class SpritePatches2
    {
        private static Dictionary<string, Sprite> SpriteUI;
        private static Dictionary<string, Vector4> PositionUI;
        
        
        public static void Patch()
        {
            SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)ChallengerUI);
        }


        private static void ChallengerUI(Scene scene, LoadSceneMode loadSceneMode)
        {
            
            if (GameObject.Find("MakePublicButton"))
            {
                //SMenue
                var MakePublicButton = GameObject.Find("MakePublicButton");
                MakePublicButton.transform.localPosition = new Vector3(55f, 55f, 0);
                var PlayerCounter_TMP = GameObject.Find("PlayerCounter_TMP");
                PlayerCounter_TMP.transform.localPosition = new Vector3(0.25f, 4.14f, 0);
                var GameRoomName_TMP = GameObject.Find("GameRoomName_TMP");
                GameRoomName_TMP.transform.localPosition = new Vector3(20f, 20f, 0);

                GameObject ChallengerPolusShip = new GameObject("ChallengerPolusShip");
                GameObject ChallengerMiraShip = new GameObject("ChallengerMiraShip");
                //ChallengerMiraShip.gameObject.SetActive(false);
                //ChallengerMiraShip.transform.localPosition = new Vector3(99f, 0f, 1f);

                GameObject newOiledPlayer = new GameObject("UI_Oiled");
                SpriteRenderer newOiledPlayerSprite = newOiledPlayer.AddComponent<SpriteRenderer>();
                newOiledPlayerSprite.sprite = CanBurn; // Load sprite with asset bundle
                newOiledPlayer.transform.localPosition = new Vector3(99f, 99f, 1f);
                newOiledPlayer.layer = 5;


                GameObject newTargetPlayer = new GameObject("UI_Target");
                SpriteRenderer newTargetPlayerSprite = newTargetPlayer.AddComponent<SpriteRenderer>();
                newTargetPlayerSprite.sprite = war0; // Load sprite with asset bundle
                newTargetPlayer.transform.localPosition = new Vector3(99f, 99f, 1f);
                newTargetPlayer.layer = 5;


                //MIRA

                GameObject HBlock1 = new GameObject("HQ_ColliderDSL");
                HBlock1.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock1 = HBlock1.AddComponent<SpriteRenderer>();
                rendHBlock1.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock1.transform.localPosition = new Vector3(-6.9227f, 2.44f, 1f);
                HBlock1.transform.localScale = new Vector3(0.16f, 4.5212f, 1f);
                HBlock1.SetActive(true);
                HBlock1.layer = 9;
                BoxCollider2D collider2DHBlock1 = HBlock1.AddComponent<BoxCollider2D>();
                collider2DHBlock1.enabled = true;
                collider2DHBlock1.isTrigger = false;

                GameObject HBlock2 = new GameObject("HQ_ColliderDship");
                HBlock2.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock2 = HBlock2.AddComponent<SpriteRenderer>();
                rendHBlock2.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock2.transform.localPosition = new Vector3(-3.4588f, 6.58f, 1f);
                HBlock2.transform.localScale = new Vector3(8.3533f, 4.36f, 1f);
                HBlock2.SetActive(true);
                HBlock2.layer = 9;
                BoxCollider2D collider2DHBlock2 = HBlock2.AddComponent<BoxCollider2D>();
                collider2DHBlock2.enabled = true;
                collider2DHBlock2.isTrigger = false;

                GameObject HBlock3 = new GameObject("HQ_ColliderDSB");
                HBlock3.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock3 = HBlock3.AddComponent<SpriteRenderer>();
                rendHBlock3.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock3.transform.localPosition = new Vector3(-1.6253f, -0.12f, 1f);
                HBlock3.transform.localScale = new Vector3(9.48f, 0.18f, 1f);
                HBlock3.SetActive(true);
                HBlock3.layer = 9;
                BoxCollider2D collider2DHBlock3 = HBlock3.AddComponent<BoxCollider2D>();
                collider2DHBlock3.enabled = true;
                collider2DHBlock3.isTrigger = false;

                GameObject HBlock4 = new GameObject("HQ_ColliderDSR");
                HBlock4.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock4 = HBlock4.AddComponent<SpriteRenderer>();
                rendHBlock4.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock4.transform.localPosition = new Vector3(3.72f, -0.22f, 1f);
                HBlock4.transform.localScale = new Vector3(0.1f, 5.9f, 1f);
                HBlock4.SetActive(true);
                HBlock4.layer = 9;
                BoxCollider2D collider2DHBlock4 = HBlock4.AddComponent<BoxCollider2D>();
                collider2DHBlock4.enabled = true;
                collider2DHBlock4.isTrigger = false;

                GameObject HBlock5 = new GameObject("HQ_ColliderlockerL1");
                HBlock5.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock5 = HBlock5.AddComponent<SpriteRenderer>();
                rendHBlock5.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock5.transform.localPosition = new Vector3(4.3f, 2.72f, 1f);
                HBlock5.transform.localScale = new Vector3(1.1f, 0.56f, 1f);
                HBlock5.SetActive(true);
                HBlock5.layer = 9;
                BoxCollider2D collider2DHBlock5 = HBlock5.AddComponent<BoxCollider2D>();
                collider2DHBlock5.enabled = true;
                collider2DHBlock5.isTrigger = false;

                GameObject HBlock6 = new GameObject("HQ_ColliderLockerL2");
                HBlock6.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock6 = HBlock6.AddComponent<SpriteRenderer>();
                rendHBlock6.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock6.transform.localPosition = new Vector3(7.832f, 2.74f, 1f);
                HBlock6.transform.localScale = new Vector3(1.0107f, 0.58f, 1f);
                HBlock6.SetActive(true);
                HBlock6.layer = 9;
                BoxCollider2D collider2DHBlock6 = HBlock6.AddComponent<BoxCollider2D>();
                collider2DHBlock6.enabled = true;
                collider2DHBlock6.isTrigger = false;

                GameObject HBlock7 = new GameObject("HQ_ColliderLockerTL");
                HBlock7.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock7 = HBlock7.AddComponent<SpriteRenderer>();
                rendHBlock7.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock7.transform.localPosition = new Vector3(8.24f, 4.4933f, 1f);
                HBlock7.transform.localScale = new Vector3(0.14f, 3.32f, 1f);
                HBlock7.SetActive(true);
                HBlock7.layer = 9;
                BoxCollider2D collider2DHBlock7 = HBlock7.AddComponent<BoxCollider2D>();
                collider2DHBlock7.enabled = true;
                collider2DHBlock7.isTrigger = false;

                GameObject HBlock8 = new GameObject("HQ_ColliderLockerTR");
                HBlock8.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock8 = HBlock8.AddComponent<SpriteRenderer>();
                rendHBlock8.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock8.transform.localPosition = new Vector3(9.72f, 5.868f, 1f);
                HBlock8.transform.localScale = new Vector3(2.6973f, 1.08f, 1f);
                HBlock8.SetActive(true);
                HBlock8.layer = 9;
                BoxCollider2D collider2DHBlock8 = HBlock8.AddComponent<BoxCollider2D>();
                collider2DHBlock8.enabled = true;
                collider2DHBlock8.isTrigger = false;

                GameObject HBlock9 = new GameObject("HQ_ColliderOfficecafe");
                HBlock9.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock9 = HBlock9.AddComponent<SpriteRenderer>();
                rendHBlock9.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock9.transform.localPosition = new Vector3(17.82f, 5.988f, 1f);
                HBlock9.transform.localScale = new Vector3(7.44f, 1f, 1f);
                HBlock9.SetActive(true);
                HBlock9.layer = 9;
                BoxCollider2D collider2DHBlock9 = HBlock9.AddComponent<BoxCollider2D>();
                collider2DHBlock9.enabled = true;
                collider2DHBlock9.isTrigger = false;

                GameObject HBlock10 = new GameObject("HQ_ColliderBorderRight");
                HBlock10.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock10 = HBlock10.AddComponent<SpriteRenderer>();
                rendHBlock10.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock10.transform.localPosition = new Vector3(24.896f, 11.056f, 1f);
                HBlock10.transform.localScale = new Vector3(-0.8667f, 10.02f, 1f);
                HBlock10.SetActive(true);
                HBlock10.layer = 9;
                BoxCollider2D collider2DHBlock10 = HBlock10.AddComponent<BoxCollider2D>();
                collider2DHBlock10.enabled = true;
                collider2DHBlock10.isTrigger = false;

                GameObject HBlock11 = new GameObject("HQ_ColliderBorderTop1");
                HBlock11.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock11 = HBlock11.AddComponent<SpriteRenderer>();
                rendHBlock11.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock11.transform.localPosition = new Vector3(22.3f, 16.24f, 1f);
                HBlock11.transform.localScale = new Vector3(5.868f, 0.96f, 1f);
                HBlock11.SetActive(true);
                HBlock11.layer = 9;
                BoxCollider2D collider2DHBlock11 = HBlock11.AddComponent<BoxCollider2D>();
                collider2DHBlock11.enabled = true;
                collider2DHBlock11.isTrigger = false;

                GameObject HBlock12 = new GameObject("HQ_ColliderBorderTop2");
                HBlock12.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock12 = HBlock12.AddComponent<SpriteRenderer>();
                rendHBlock12.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock12.transform.localPosition = new Vector3(14.34f, 16.2507f, 1f);
                HBlock12.transform.localScale = new Vector3(4.16f, 1f, 1f);
                HBlock12.SetActive(true);
                HBlock12.layer = 9;
                BoxCollider2D collider2DHBlock12 = HBlock12.AddComponent<BoxCollider2D>();
                collider2DHBlock12.enabled = true;
                collider2DHBlock12.isTrigger = false;

                GameObject HBlock13 = new GameObject("HQ_ColliderLabR");
                HBlock13.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock13 = HBlock13.AddComponent<SpriteRenderer>();
                rendHBlock13.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock13.transform.localPosition = new Vector3(12.22f, 12.32f, 1f);
                HBlock13.transform.localScale = new Vector3(0.18f, 6.48f, 1f);
                HBlock13.SetActive(true);
                HBlock13.layer = 9;
                BoxCollider2D collider2DHBlock13 = HBlock13.AddComponent<BoxCollider2D>();
                collider2DHBlock13.enabled = true;
                collider2DHBlock13.isTrigger = false;

                GameObject HBlock14 = new GameObject("HQ_ColliderTexShadowReactorBot");
                HBlock14.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock14 = HBlock14.AddComponent<SpriteRenderer>();
                rendHBlock14.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock14.transform.localPosition = new Vector3(2.468f, 9.24f, 1f);
                HBlock14.transform.localScale = new Vector3(4.3f, 0.66f, 1f);
                HBlock14.SetActive(true);
                HBlock14.layer = 11;
                BoxCollider2D collider2DHBlock14 = HBlock14.AddComponent<BoxCollider2D>();
                collider2DHBlock14.enabled = true;
                collider2DHBlock14.isTrigger = false;

                GameObject HBlock15 = new GameObject("HQ_ColliderTexShadowRightreactor");
                HBlock15.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock15 = HBlock15.AddComponent<SpriteRenderer>();
                rendHBlock15.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock15.transform.localPosition = new Vector3(0.0176f, 13.26f, 1f);
                HBlock15.transform.localScale = new Vector3(0.06f, 6.52f, 1f);
                HBlock15.SetActive(true);
                HBlock15.layer = 11;
                BoxCollider2D collider2DHBlock15 = HBlock15.AddComponent<BoxCollider2D>();
                collider2DHBlock15.enabled = true;
                collider2DHBlock15.isTrigger = false;

                GameObject HBlock16 = new GameObject("HQ_ColliderLockright");
                HBlock16.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock16 = HBlock16.AddComponent<SpriteRenderer>();
                rendHBlock16.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock16.transform.localPosition = new Vector3(11.18f, 4.664f, 1f);
                HBlock16.transform.localScale = new Vector3(0.14f, 2.58f, 1f);
                HBlock16.SetActive(true);
                HBlock16.layer = 9;
                BoxCollider2D collider2DHBlock16 = HBlock16.AddComponent<BoxCollider2D>();
                collider2DHBlock16.enabled = true;
                collider2DHBlock16.isTrigger = false;

                GameObject HBlock17 = new GameObject("HQ_ColliderLockershadow");
                HBlock17.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock17 = HBlock17.AddComponent<SpriteRenderer>();
                rendHBlock17.sprite = Colliderblack; // Load sprite with asset bundle
                HBlock17.transform.localPosition = new Vector3(11.1853f, 3.2146f, 1f);
                HBlock17.transform.localScale = new Vector3(0.1f, 5.5728f, 1f);
                HBlock17.SetActive(true);
                HBlock17.layer = 11;
                BoxCollider2D collider2DHBlock17 = HBlock17.AddComponent<BoxCollider2D>();
                collider2DHBlock17.enabled = true;
                collider2DHBlock17.isTrigger = false;

                GameObject HBlock18 = new GameObject("HQ_ColliderLabShadow");
                HBlock18.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock18 = HBlock18.AddComponent<SpriteRenderer>();
                rendHBlock18.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock18.transform.localPosition = new Vector3(7.254f, 11.18f, 1f);
                HBlock18.transform.localScale = new Vector3(0.04f, 3.846f, 1f);
                HBlock18.SetActive(true);
                HBlock18.layer = 11;
                BoxCollider2D collider2DHBlock18 = HBlock18.AddComponent<BoxCollider2D>();
                collider2DHBlock18.enabled = true;
                collider2DHBlock18.isTrigger = false;

                GameObject HBlock19 = new GameObject("HQ_Colliderreactorshadow");
                HBlock19.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock19 = HBlock19.AddComponent<SpriteRenderer>();
                rendHBlock19.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock19.transform.localPosition = new Vector3(4.94f, 14.0859f, 1f);
                HBlock19.transform.localScale = new Vector3(0.04f, 4.54f, 1f);
                HBlock19.SetActive(true);
                HBlock19.layer = 11;
                BoxCollider2D collider2DHBlock19 = HBlock19.AddComponent<BoxCollider2D>();
                collider2DHBlock19.enabled = true;
                collider2DHBlock19.isTrigger = false;

                GameObject HBlock20 = new GameObject("HQ_ColliderTexShadowLocker");
                HBlock20.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock20 = HBlock20.AddComponent<SpriteRenderer>();
                rendHBlock20.sprite = Colliderblack; // Load sprite with asset bundle
                HBlock20.transform.localPosition = new Vector3(9.7759f, 6.492f, -10f);
                HBlock20.transform.localScale = new Vector3(2.5339f, 0.62f, 1f);
                HBlock20.SetActive(true);
                HBlock20.layer = 11;
                BoxCollider2D collider2DHBlock20 = HBlock20.AddComponent<BoxCollider2D>();
                collider2DHBlock20.enabled = true;
                collider2DHBlock20.isTrigger = false;



                GameObject HBlock21 = new GameObject("HQ_ColliderTexShadowOfficeCafe");
                HBlock21.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock21 = HBlock21.AddComponent<SpriteRenderer>();
                rendHBlock21.sprite = Colliderblack; // Load sprite with asset bundle
                HBlock21.transform.localPosition = new Vector3(17.84f, 6.492f, -10f);
                HBlock21.transform.localScale = new Vector3(7.38f, 0.62f, 1f);
                HBlock21.SetActive(true);
                HBlock21.layer = 11;
                BoxCollider2D collider2DHBlock21 = HBlock21.AddComponent<BoxCollider2D>();
                collider2DHBlock21.enabled = true;
                collider2DHBlock21.isTrigger = false;

                GameObject HBlock22 = new GameObject("HQ_ColliderTexShadowlockerVertLeft");
                HBlock22.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock22 = HBlock22.AddComponent<SpriteRenderer>();
                rendHBlock22.sprite = Colliderblack; // Load sprite with asset bundle
                HBlock22.transform.localPosition = new Vector3(7.75f, 4.904f, -10f);
                HBlock22.transform.localScale = new Vector3(1f, 3.446f, 1f);
                HBlock22.SetActive(true);
                HBlock22.layer = 11;
                BoxCollider2D collider2DHBlock22 = HBlock22.AddComponent<BoxCollider2D>();
                collider2DHBlock22.enabled = true;
                collider2DHBlock22.isTrigger = false;

                GameObject HBlock23 = new GameObject("HQ_ColliderTexShadowLockerLeft");
                HBlock23.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock23 = HBlock23.AddComponent<SpriteRenderer>();
                rendHBlock23.sprite = Colliderblack; // Load sprite with asset bundle
                HBlock23.transform.localPosition = new Vector3(4.326f, 3.26f, -10f);
                HBlock23.transform.localScale = new Vector3(1.1f, 0.6f, 1f);
                HBlock23.SetActive(true);
                HBlock23.layer = 11;
                BoxCollider2D collider2DHBlock23 = HBlock23.AddComponent<BoxCollider2D>();
                collider2DHBlock23.enabled = true;
                collider2DHBlock23.isTrigger = false;

                GameObject HBlock24 = new GameObject("HQ_ColliderTexShadowShadowElecBot");
                HBlock24.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock24 = HBlock24.AddComponent<SpriteRenderer>();
                rendHBlock24.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock24.transform.localPosition = new Vector3(22.4679f, 9.63f, 1f);
                HBlock24.transform.localScale = new Vector3(3.528f, 0.1f, 1f);
                HBlock24.SetActive(true);
                HBlock24.layer = 11;
                BoxCollider2D collider2DHBlock24 = HBlock24.AddComponent<BoxCollider2D>();
                collider2DHBlock24.enabled = true;
                collider2DHBlock24.isTrigger = false;

                GameObject HBlock25 = new GameObject("HQ_ColliderElecBot");
                HBlock25.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock25 = HBlock25.AddComponent<SpriteRenderer>();
                rendHBlock25.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock25.transform.localPosition = new Vector3(22.436f, 9.2779f, 1f);
                HBlock25.transform.localScale = new Vector3(3.464f, 0.66f, 1f);
                HBlock25.SetActive(true);
                HBlock25.layer = 9;
                BoxCollider2D collider2DHBlock25 = HBlock25.AddComponent<BoxCollider2D>();
                collider2DHBlock25.enabled = true;
                collider2DHBlock25.isTrigger = false;

                GameObject HBlock26 = new GameObject("HQ_ColliderTexShadowShadowElecLeft");
                HBlock26.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock26 = HBlock26.AddComponent<SpriteRenderer>();
                rendHBlock26.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock26.transform.localPosition = new Vector3(20.4978f, 13.118f, -10f);
                HBlock26.transform.localScale = new Vector3(0.08f, 2.7019f, 1f);
                HBlock26.SetActive(true);
                HBlock26.layer = 11;
                BoxCollider2D collider2DHBlock26 = HBlock26.AddComponent<BoxCollider2D>();
                collider2DHBlock26.enabled = true;
                collider2DHBlock26.isTrigger = false;

                GameObject HBlock27 = new GameObject("HQ_ColliderShadowTexLabo");
                HBlock27.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock27 = HBlock27.AddComponent<SpriteRenderer>();
                rendHBlock27.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock27.transform.localPosition = new Vector3(9.74f, 9.2238f, 1f);
                HBlock27.transform.localScale = new Vector3(4.35f, 0.6984f, 1f);
                HBlock27.SetActive(true);
                HBlock27.layer = 11;
                BoxCollider2D collider2DHBlock27 = HBlock27.AddComponent<BoxCollider2D>();
                collider2DHBlock27.enabled = true;
                collider2DHBlock27.isTrigger = false;

                GameObject HBlock28 = new GameObject("HQ_ColliderMidCenter");
                HBlock28.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock28 = HBlock28.AddComponent<SpriteRenderer>();
                rendHBlock28.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock28.transform.localPosition = new Vector3(17.2588f, 9.3414f, 1f);
                HBlock28.transform.localScale = new Vector3(1.46f, 1.4575f, 1f);
                HBlock28.SetActive(true);
                HBlock28.layer = 9;
                BoxCollider2D collider2DHBlock28 = HBlock28.AddComponent<BoxCollider2D>();
                collider2DHBlock28.enabled = true;
                collider2DHBlock28.isTrigger = false;

                GameObject HBlock29 = new GameObject("HQ_ColliderMidBot");
                HBlock29.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock29 = HBlock29.AddComponent<SpriteRenderer>();
                rendHBlock29.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock29.transform.localPosition = new Vector3(16.8438f, 8.1414f, 1f);
                HBlock29.transform.localScale = new Vector3(2.18f, 1.0175f, 1f);
                HBlock29.SetActive(true);
                BoxCollider2D collider2DHBlock29 = HBlock29.AddComponent<BoxCollider2D>();
                collider2DHBlock29.enabled = true;
                collider2DHBlock29.isTrigger = false;

                GameObject HBlock30 = new GameObject("HQ_ColliderMidRTop");
                HBlock30.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock30 = HBlock30.AddComponent<SpriteRenderer>();
                rendHBlock30.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock30.transform.localPosition = new Vector3(15.71f, 9.8863f, 1f);
                HBlock30.transform.localScale = new Vector3(1.26f, 0.235f, 1f);
                HBlock30.SetActive(true);
                BoxCollider2D collider2DHBlock30 = HBlock30.AddComponent<BoxCollider2D>();
                collider2DHBlock30.enabled = true;
                collider2DHBlock30.isTrigger = false;

                GameObject HBlock31 = new GameObject("HQ_ColliderMidRBot");
                HBlock31.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock31 = HBlock31.AddComponent<SpriteRenderer>();
                rendHBlock31.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock31.transform.localPosition = new Vector3(15.71f, 8.74f, 1f);
                HBlock31.transform.localScale = new Vector3(1.26f, 0.235f, 1f);
                HBlock31.SetActive(true);
                BoxCollider2D collider2DHBlock31 = HBlock31.AddComponent<BoxCollider2D>();
                collider2DHBlock31.enabled = true;
                collider2DHBlock31.isTrigger = false;

                GameObject HBlock32 = new GameObject("HQ_ColliderSH1");
                HBlock32.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock32 = HBlock32.AddComponent<SpriteRenderer>();
                rendHBlock32.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock32.transform.localPosition = new Vector3(16.4838f, 13.9063f, 1f);
                HBlock32.transform.localScale = new Vector3(0.46f, 0.36f, 1f);
                HBlock32.SetActive(true);
                HBlock32.layer = 9;
                BoxCollider2D collider2DHBlock32 = HBlock32.AddComponent<BoxCollider2D>();
                collider2DHBlock32.enabled = true;
                collider2DHBlock32.isTrigger = false;

                GameObject HBlock33 = new GameObject("HQ_ColliderSH2");
                HBlock33.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock33 = HBlock33.AddComponent<SpriteRenderer>();
                rendHBlock33.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock33.transform.localPosition = new Vector3(14.2463f, 14.04f, 1f);
                HBlock33.transform.localScale = new Vector3(3.3239f, 0.6f, 1f);
                HBlock33.SetActive(true);
                BoxCollider2D collider2DHBlock33 = HBlock33.AddComponent<BoxCollider2D>();
                collider2DHBlock33.enabled = true;
                collider2DHBlock33.isTrigger = false;

                GameObject HBlock34 = new GameObject("HQ_ColliderElecGen");
                HBlock34.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock34 = HBlock34.AddComponent<SpriteRenderer>();
                rendHBlock34.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock34.transform.localPosition = new Vector3(23.12f, 12.74f, 1f);
                HBlock34.transform.localScale = new Vector3(2.2f, 1.78f, 1f);
                HBlock34.SetActive(true);
                HBlock34.layer = 9;
                BoxCollider2D collider2DHBlock34 = HBlock34.AddComponent<BoxCollider2D>();
                collider2DHBlock34.enabled = true;
                collider2DHBlock34.isTrigger = false;

                GameObject HBlock35 = new GameObject("HQ_ColliderElecTab");
                HBlock35.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock35 = HBlock35.AddComponent<SpriteRenderer>();
                rendHBlock35.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock35.transform.localPosition = new Vector3(23.8163f, 15.3488f, 1f);
                HBlock35.transform.localScale = new Vector3(1.32f, 0.74f, 1f);
                HBlock35.SetActive(true);
                HBlock35.layer = 9;
                BoxCollider2D collider2DHBlock35 = HBlock35.AddComponent<BoxCollider2D>();
                collider2DHBlock35.enabled = true;
                collider2DHBlock35.isTrigger = false;

                GameObject HBlock36 = new GameObject("HQ_ColliderTexShadowShadowElecLeftDoor");
                HBlock36.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock36 = HBlock36.AddComponent<SpriteRenderer>();
                rendHBlock36.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock36.transform.localPosition = new Vector3(20.4978f, 12.798f, 1f);
                HBlock36.transform.localScale = new Vector3(0.08f, 3.2319f, 1f);
                HBlock36.SetActive(true);
                HBlock36.layer = 9;
                BoxCollider2D collider2DHBlock36 = HBlock36.AddComponent<BoxCollider2D>();
                collider2DHBlock36.enabled = true;
                collider2DHBlock36.isTrigger = false;

                GameObject HBlock37 = new GameObject("HQ_ColliderMidTop");
                HBlock37.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock37 = HBlock37.AddComponent<SpriteRenderer>();
                rendHBlock37.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock37.transform.localPosition = new Vector3(16.8438f, 10.3074f, 1f);
                HBlock37.transform.localScale = new Vector3(2.18f, 1.0175f, 1f);
                HBlock37.SetActive(true);
                BoxCollider2D collider2DHBlock37 = HBlock37.AddComponent<BoxCollider2D>();
                collider2DHBlock37.enabled = true;
                collider2DHBlock37.isTrigger = false;

                GameObject HBlock38 = new GameObject("HQ_ColliderTexShadowlowReactor");
                HBlock38.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock38 = HBlock38.AddComponent<SpriteRenderer>();
                rendHBlock38.sprite = Colliderblack; // Load sprite with asset bundle
                HBlock38.transform.localPosition = new Vector3(2.4737f, 8.9859f, 0.98f);
                HBlock38.transform.localScale = new Vector3(4.34f, 1.02f, 1f);
                HBlock38.SetActive(true);
                HBlock38.layer = 12;
                BoxCollider2D collider2DHBlock38 = HBlock38.AddComponent<BoxCollider2D>();
                collider2DHBlock38.enabled = true;
                collider2DHBlock38.isTrigger = false;

                GameObject HBlock39 = new GameObject("HQ_ColliderTexShadowlowLab");
                HBlock39.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock39 = HBlock39.AddComponent<SpriteRenderer>();
                rendHBlock39.sprite = Colliderblack; // Load sprite with asset bundle
                HBlock39.transform.localPosition = new Vector3(9.7371f, 8.9859f, 0.98f);
                HBlock39.transform.localScale = new Vector3(4.34f, 1.02f, 1f);
                HBlock39.SetActive(true);
                HBlock39.layer = 12;
                BoxCollider2D collider2DHBlock39 = HBlock39.AddComponent<BoxCollider2D>();
                collider2DHBlock39.enabled = true;
                collider2DHBlock39.isTrigger = false;

                GameObject HBlock40 = new GameObject("HQ_ColliderTexShadowupOfficeCafe");
                HBlock40.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock40 = HBlock40.AddComponent<SpriteRenderer>();
                rendHBlock40.sprite = Colliderblack; // Load sprite with asset bundle
                HBlock40.transform.localPosition = new Vector3(16.8677f, 7.1369f, -10f);
                HBlock40.transform.localScale = new Vector3(2.7715f, 0.58f, 1f);
                HBlock40.SetActive(true);
                HBlock40.layer = 11;
                BoxCollider2D collider2DHBlock40 = HBlock40.AddComponent<BoxCollider2D>();
                collider2DHBlock40.enabled = true;
                collider2DHBlock40.isTrigger = false;

                GameObject HBlock41 = new GameObject("HQ_ColliderTexShadowupbotO2panel");
                HBlock41.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock41 = HBlock41.AddComponent<SpriteRenderer>();
                rendHBlock41.sprite = Colliderblack; // Load sprite with asset bundle
                HBlock41.transform.localPosition = new Vector3(3.75f, 0.1187f, -9.52f);
                HBlock41.transform.localScale = new Vector3(0.1f, 5.6439f, 1f);
                HBlock41.SetActive(true);
                HBlock41.layer = 11;
                BoxCollider2D collider2DHBlock41 = HBlock41.AddComponent<BoxCollider2D>();
                collider2DHBlock41.enabled = true;
                collider2DHBlock41.isTrigger = false;

                GameObject HBlock42 = new GameObject("HQ_ColliderDSClotL");
                HBlock42.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock42 = HBlock42.AddComponent<SpriteRenderer>();
                rendHBlock42.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock42.transform.localPosition = new Vector3(2.06f, 5.3926f, 1f);
                HBlock42.transform.localScale = new Vector3(1.4f, 0.52f, 1f);
                HBlock42.SetActive(true);
                HBlock42.layer = 12;
                BoxCollider2D collider2DHBlock42 = HBlock42.AddComponent<BoxCollider2D>();
                collider2DHBlock42.enabled = true;
                collider2DHBlock42.isTrigger = false;

                GameObject HBlock43 = new GameObject("HQ_ColliderDSClotR");
                HBlock43.transform.parent = ChallengerMiraShip.transform;
                SpriteRenderer rendHBlock43 = HBlock43.AddComponent<SpriteRenderer>();
                rendHBlock43.sprite = Colliderbox; // Load sprite with asset bundle
                HBlock43.transform.localPosition = new Vector3(6.08f, 5.3926f, 1f);
                HBlock43.transform.localScale = new Vector3(2.54f, 0.52f, 1f);
                HBlock43.SetActive(true);
                HBlock43.layer = 12;
                BoxCollider2D collider2DHBlock43 = HBlock43.AddComponent<BoxCollider2D>();
                collider2DHBlock43.enabled = true;
                collider2DHBlock43.isTrigger = false;


                //POLUS


                /*GameObject LightAff = new GameObject("LobbyLevel_L");
                LightAff.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendli = LightAff.AddComponent<SpriteRenderer>();
                rendli.sprite = EA1; // Load sprite with asset bundle
                BoxCollider2D collider2DLight = LightAff.AddComponent<BoxCollider2D>();
                collider2DLight.enabled = true;
                collider2DLight.isTrigger = true;
                LightAffector rendlight = LightAff.AddComponent<LightAffector>();
                rendlight.Multiplier = 0.2f;
                rendlight.Hitbox = collider2DLight;
                LightAff.transform.localPosition = new Vector3(1f, -20f, 0f);
                LightAff.transform.localScale = new Vector3(5f, 5f, 1f);
                LightAff.SetActive(true);
                LightAff.layer = 9;*/

                GameObject EE1 = new GameObject("LobbyLevel_EE1");
                EE1.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendEE1 = EE1.AddComponent<SpriteRenderer>();
                rendEE1.sprite = EA1; // Load sprite with asset bundle
                EE1.transform.localPosition = new Vector3(0.6219f, -23.2167f, 0f);
                EE1.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                EE1.SetActive(true);
                EE1.layer = 12;

                GameObject EE2 = new GameObject("LobbyLevel_EE2");
                EE2.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendEE2 = EE2.AddComponent<SpriteRenderer>();
                rendEE2.sprite = EA2; // Load sprite with asset bundle
                EE2.transform.localPosition = new Vector3(34.9896f, -8.8956f, 0f);
                EE2.transform.localScale = new Vector3(0.4f, 0.35f, 1f);
                EE2.SetActive(true);
                EE2.layer = 12;

                GameObject EE3 = new GameObject("LobbyLevel_EE3");
                EE3.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendEE3 = EE3.AddComponent<SpriteRenderer>();
                rendEE3.sprite = EA3; // Load sprite with asset bundle
                EE3.transform.localPosition = new Vector3(22.5967f, -16.1365f, 0f);
                EE3.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
                EE3.SetActive(true);
                EE3.layer = 12;

                GameObject EE4 = new GameObject("LobbyLevel_EE4");
                EE4.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendEE4 = EE4.AddComponent<SpriteRenderer>();
                rendEE4.sprite = EA4; // Load sprite with asset bundle
                EE4.transform.localPosition = new Vector3(7.9169f, -16.4194f, 0f);
                EE4.SetActive(true);
                EE4.layer = 0;

                GameObject EE5 = new GameObject("LobbyLevel_EE5");
                EE5.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendEE5 = EE5.AddComponent<SpriteRenderer>();
                rendEE5.sprite = EA5; // Load sprite with asset bundle
                EE5.transform.localPosition = new Vector3(22.4549f, -20.2269f, 0f);
                EE5.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
                EE5.SetActive(true);
                EE5.layer = 12;

                GameObject EE6 = new GameObject("LobbyLevel_EE6");
                EE6.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendEE6 = EE6.AddComponent<SpriteRenderer>();
                rendEE6.sprite = EA6; // Load sprite with asset bundle
                EE6.transform.localPosition = new Vector3(33.5496f, -14.4765f, 0f);
                EE6.SetActive(true);
                EE6.layer = 0;






                GameObject NewTexture = new GameObject("LobbyLevel_NewTexture");
                NewTexture.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendNewTexture = NewTexture.AddComponent<SpriteRenderer>();
                rendNewTexture.sprite = LobbyLevel_room_tunnel1; // Load sprite with asset bundle
                NewTexture.transform.localPosition = new Vector3(29.5245f, -22.9338f, 2.4468f);
                NewTexture.SetActive(true);
                NewTexture.layer = 12;


                GameObject Texture1 = new GameObject("LobbyLevel_Texture1");
                Texture1.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendTexture1 = Texture1.AddComponent<SpriteRenderer>();
                rendTexture1.sprite = Level_Tex1; // Load sprite with asset bundle
                rendTexture1.renderingLayerMask = 1;
                Texture1.transform.localPosition = new Vector3(31.595f, -28.5f, 1f);
                Texture1.layer = 12;
                BoxCollider2D collider2DTexture1 = Texture1.AddComponent<BoxCollider2D>();
                collider2DTexture1.enabled = true;
                collider2DTexture1.isTrigger = false;


                GameObject Texture2 = new GameObject("LobbyLevel_Texture2");
                Texture2.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendTexture2 = Texture2.AddComponent<SpriteRenderer>();
                rendTexture2.sprite = Level_Tex2; // Load sprite with asset bundle
                Texture2.transform.localPosition = new Vector3(35.0425f, -24.6738f, 2.4468f);
                Texture2.SetActive(true);
                Texture2.layer = 12;
                BoxCollider2D collider2DTexture2 = Texture2.AddComponent<BoxCollider2D>();
                collider2DTexture2.enabled = true;
                collider2DTexture2.isTrigger = false;

                GameObject Texture3 = new GameObject("LobbyLevel_Texture3");
                Texture3.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendTexture3 = Texture3.AddComponent<SpriteRenderer>();
                rendTexture3.sprite = Level_Tex3; // Load sprite with asset bundle
                Texture3.transform.localPosition = new Vector3(34.3625f, -22.7338f, 2.4468f);
                Texture3.transform.localScale = new Vector3(1f, 1f, 1f);
                Texture3.SetActive(true);
                Texture3.layer = 12;
                BoxCollider2D collider2DTexture3 = Texture3.AddComponent<BoxCollider2D>();
                collider2DTexture3.enabled = true;
                collider2DTexture3.isTrigger = false;

                GameObject Texture4 = new GameObject("LobbyLevel_Texture4");
                Texture4.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendTexture4 = Texture4.AddComponent<SpriteRenderer>();
                rendTexture4.sprite = Level_Tex4; // Load sprite with asset bundle
                Texture4.transform.localPosition = new Vector3(31.2171f, -23.3938f, 2.4468f);
                Texture4.transform.localScale = new Vector3(0.62f, 0.5f, 1f);
                Texture4.SetActive(true);
                Texture4.layer = 12;
                BoxCollider2D collider2DTexture4 = Texture4.AddComponent<BoxCollider2D>();
                collider2DTexture4.enabled = true;
                collider2DTexture4.isTrigger = false;

                GameObject block1 = new GameObject("LobbyLevel_Collider1");
                block1.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendblock1 = block1.AddComponent<SpriteRenderer>();
                rendblock1.sprite = Level_collider1; // Load sprite with asset bundle
                block1.transform.localPosition = new Vector3(29.7785f, -19.8898f, 2.4468f);
                block1.SetActive(true);
                block1.layer = 9;
                BoxCollider2D collider2Dblock1 = block1.AddComponent<BoxCollider2D>();
                collider2Dblock1.enabled = true;
                collider2Dblock1.isTrigger = false;

                GameObject block2 = new GameObject("LobbyLevel_Collider2");
                block2.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendblock2 = block2.AddComponent<SpriteRenderer>();
                rendblock2.sprite = Level_collider2; // Load sprite with asset bundle
                block2.transform.localPosition = new Vector3(29.1612f, -21.6778f, 2.4468f);
                block2.transform.localScale = new Vector3(1f, 0.7894f, 1f);
                block2.SetActive(true);
                block2.layer = 9;
                BoxCollider2D collider2Dblock2 = block2.AddComponent<BoxCollider2D>();
                collider2Dblock2.enabled = true;
                collider2Dblock2.isTrigger = false;

                GameObject block3 = new GameObject("LobbyLevel_Collider3");
                block3.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendblock3 = block3.AddComponent<SpriteRenderer>();
                rendblock3.sprite = Level_collider3; // Load sprite with asset bundle
                block3.transform.localPosition = new Vector3(28.6479f, -24.2124f, 2.4468f);
                block3.transform.localScale = new Vector3(0.52f, 1f, 1f);
                block3.SetActive(true);
                block3.layer = 9;
                BoxCollider2D collider2Dblock3 = block3.AddComponent<BoxCollider2D>();
                collider2Dblock3.enabled = true;
                collider2Dblock3.isTrigger = false;

                GameObject block4 = new GameObject("LobbyLevel_Collider4");
                block4.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendblock4 = block4.AddComponent<SpriteRenderer>();
                rendblock4.sprite = Level_collider4; // Load sprite with asset bundle
                block4.transform.localPosition = new Vector3(32.2973f, -21.7111f, 2.4468f);
                block4.SetActive(true);
                block4.layer = 9;
                BoxCollider2D collider2Dblock4 = block4.AddComponent<BoxCollider2D>();
                collider2Dblock4.enabled = true;
                collider2Dblock4.isTrigger = false;

                GameObject block5 = new GameObject("LobbyLevel_Collider5");
                block5.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendblock5 = block5.AddComponent<SpriteRenderer>();
                rendblock5.sprite = Level_collider5; // Load sprite with asset bundle
                block5.transform.localPosition = new Vector3(27.0625f, -25.7338f, 2.4468f);
                block5.transform.localScale = new Vector3(0.4f, 1f, 1f);
                block5.SetActive(true);
                block5.layer = 9;
                BoxCollider2D collider2Dblock5 = block5.AddComponent<BoxCollider2D>();
                collider2Dblock5.enabled = true;
                collider2Dblock5.isTrigger = false;

                GameObject block6 = new GameObject("LobbyLevel_Collider6");
                block6.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendblock6 = block6.AddComponent<SpriteRenderer>();
                rendblock6.sprite = Level_collider6; // Load sprite with asset bundle
                block6.transform.localPosition = new Vector3(26.2025f, -21.9738f, 2.4468f);
                block6.SetActive(true);
                block6.layer = 9;
                BoxCollider2D collider2Dblock6 = block6.AddComponent<BoxCollider2D>();
                collider2Dblock6.enabled = true;
                collider2Dblock6.isTrigger = false;

                GameObject block7 = new GameObject("LobbyLevel_Collider7");
                block7.transform.parent = ChallengerPolusShip.transform;
                SpriteRenderer rendblock7 = block7.AddComponent<SpriteRenderer>();
                rendblock7.sprite = Level_collider7; // Load sprite with asset bundle
                block7.transform.localPosition = new Vector3(33.9225f, -22.0365f, 2.4468f);
                block7.transform.localScale = new Vector3(-0.47f, -0.1613f, 1f);
                block7.SetActive(true);
                block7.layer = 9;
                BoxCollider2D collider2Dblock7 = block7.AddComponent<BoxCollider2D>();
                collider2Dblock7.enabled = true;
                collider2Dblock7.isTrigger = false;




                GameObject gameObject2 = new GameObject("LobbyLevel_GameObject2");
                SpriteRenderer rend2 = gameObject2.AddComponent<SpriteRenderer>();
                rend2.sprite = Affich2; // Load sprite with asset bundle
                gameObject2.transform.localPosition = new Vector3(99f, 4.5f, 1f);

                GameObject gameObject = new GameObject("LobbyLevel_GameObject");
                SpriteRenderer rend = gameObject.AddComponent<SpriteRenderer>();
                rend.sprite = Affich; // Load sprite with asset bundle
                gameObject.transform.localPosition = new Vector3(0f, 4.5f, 1f);
















                //Room edit







            }


            foreach (var (StringName, SpriteChange) in SpriteUI)
            {
                var original = GameObject.Find(StringName);

                

                

                

               



                    
                if (PositionUI.TryGetValue(StringName, out var translation))
                {
                    original.transform.Translate(translation);
                }
                continue;
            }
              
        }

        private static void StartCoroutine(IEnumerator enumerator)
        {
            throw new NotImplementedException();
        }
    }
}