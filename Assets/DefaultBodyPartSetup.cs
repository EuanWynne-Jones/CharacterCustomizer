using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCustomizer.Core
{
    public class DefaultBodyPartSetup : MonoBehaviour
    {

        [Header("Races")]
        public List<Color> raceSkinColours = new List<Color>();
        public List<Color> secondaryRaceSkinColours = new List<Color>();

        [Header("Male")]
        public List<GameObject> maleHeads = new List<GameObject>();
        public List<GameObject> maleBrows = new List<GameObject>();
        public List<GameObject> maleFacialHair = new List<GameObject>();
        public List<GameObject> maleTorsos = new List<GameObject>();
        public List<GameObject> maleArmsUpperRight = new List<GameObject>();
        public List<GameObject> maleArmsLowerRight = new List<GameObject>();
        public List<GameObject> maleArmsUpperLeft = new List<GameObject>();
        public List<GameObject> maleArmsLowerLeft = new List<GameObject>();
        public List<GameObject> maleHandsRight = new List<GameObject>();
        public List<GameObject> maleHandsLeft = new List<GameObject>();
        public List<GameObject> maleHips = new List<GameObject>();
        public List<GameObject> maleLegRight = new List<GameObject>();
        public List<GameObject> maleLegLeft = new List<GameObject>();

       


        [Header("Female")]
        public List<GameObject> femaleHeads = new List<GameObject>();
        public List<GameObject> femaleBrows = new List<GameObject>();
        public List<GameObject> femaleTorso = new List<GameObject>();
        public List<GameObject> femaleArmsUpperRight = new List<GameObject>();
        public List<GameObject> femaleArmsLowerRight = new List<GameObject>();
        public List<GameObject> femaleArmsUpperLeft = new List<GameObject>();
        public List<GameObject> femaleArmsLowerLeft = new List<GameObject>();
        public List<GameObject> femaleHandsRight = new List<GameObject>();
        public List<GameObject> femaleHandsLeft = new List<GameObject>();
        public List<GameObject> femaleHips = new List<GameObject>();
        public List<GameObject> femaleLegRight = new List<GameObject>();
        public List<GameObject> femaleLegLeft = new List<GameObject>();

        [Header("Hair")]
        public List<GameObject> hairstyles = new List<GameObject>();

        [Header("Ears")]
        public List<GameObject> ears = new List<GameObject>();

        [Header("ActivePieces")]
        public List<GameObject> currentlyActivePeices = new List<GameObject>();

        [Header("MaterialOverrite")]
        public Material reffenceMaterial = null;

        [HideInInspector] public bool isMale;
        private void Start()
        {
            GetAllBodyParts();
            UpdateCustomMaterial(transform);
            EnableDefaultMale();


            BodyPartChanger bodyPartChanger = FindObjectOfType<BodyPartChanger>();

        }

        private void GetAllBodyParts()
        {
            GetHeads(transform);
            GetEyebrows(transform);
            GetFacialHair(transform);
            GetTorsos(transform);
            GetArmsUpperRight(transform);
            GetArmsLowerRight(transform);
            GetArmsUpperLeft(transform);
            GetArmsLowerLeft(transform);
            GetRightHands(transform);
            GetLeftHands(transform);
            GetHips(transform);
            GetRightLegs(transform);
            GetLeftLegs(transform);
            GetHairstyles(transform);
            GetEars(transform);
        }
        // Non-Gender specific functions for getting all body parts that meet the enum requirments, adding each of these to respective lists above
        private void GetHeads(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Head &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleHeads.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Head &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleHeads.Add(child.gameObject);
                }

                GetHeads(child);
            }
        }
        private void GetEyebrows(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Eyebrows &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleBrows.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Eyebrows &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleBrows.Add(child.gameObject);
                }

                GetEyebrows(child);
            }
        }
        private void GetFacialHair(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.FacialHair &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleFacialHair.Add(child.gameObject);
                }


                GetFacialHair(child);
            }
        }
        private void GetTorsos(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Torso &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleTorsos.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Torso &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleTorso.Add(child.gameObject);
                }

                GetTorsos(child);
            }
        }
        private void GetArmsUpperRight(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmUpperRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleArmsUpperRight.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmUpperRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleArmsUpperRight.Add(child.gameObject);
                }

                GetArmsUpperRight(child);
            }
        }
        private void GetArmsLowerRight(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmLowerRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleArmsLowerRight.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmLowerRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleArmsLowerRight.Add(child.gameObject);
                }

                GetArmsLowerRight(child);
            }
        }
        private void GetArmsUpperLeft(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmUpperLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleArmsUpperLeft.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmUpperLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleArmsUpperLeft.Add(child.gameObject);
                }

                GetArmsUpperLeft(child);
            }
        }
        private void GetArmsLowerLeft(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmLowerLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleArmsLowerLeft.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.ArmLowerLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleArmsLowerLeft.Add(child.gameObject);
                }

                GetArmsLowerLeft(child);
            }
        }
        private void GetRightHands(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.HandRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleHandsRight.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.HandRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleHandsRight.Add(child.gameObject);
                }

                GetRightHands(child);
            }
        }
        private void GetLeftHands(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.HandLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleHandsLeft.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.HandLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleHandsLeft.Add(child.gameObject);
                }

                GetLeftHands(child);
            }
        }
        private void GetHips(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Hips &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleHips.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Hips &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleHips.Add(child.gameObject);
                }

                GetHips(child);
            }
        }
        private void GetRightLegs(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.LegRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleLegRight.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.LegRight &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleLegRight.Add(child.gameObject);
                }

                GetRightLegs(child);
            }
        }
        private void GetLeftLegs(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.LegLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Male)
                {
                    maleLegLeft.Add(child.gameObject);
                }
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.LegLeft &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Female)
                {
                    femaleLegLeft.Add(child.gameObject);
                }

                GetLeftLegs(child);
            }
        }
        private void GetHairstyles(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Hairstyle &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Both)
                {
                    hairstyles.Add(child.gameObject);
                }

                GetHairstyles(child);
            }
        }
        private void GetEars(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null &&
                    child.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Ears &&
                    child.GetComponent<BodyPartCollection>().gender == BodyPartCollection.CharacterGender.Both)
                {
                    ears.Add(child.gameObject);
                }

                GetEars(child);
            }
        }





        [ContextMenu("EnableDefaultMale")]
        public void EnableDefaultMale()
        {
            isMale = true;
            DisableBodyParts(transform);
            EnableMaleBodyParts();
            UpdateActivePieces(transform,true);

        }

        [ContextMenu("EnableDefaultFemale")]
        public void EnableDefaultFemale()
        {
            isMale = false;
            DisableBodyParts(transform);
            EnableFemaleBodyParts();
            UpdateActivePieces(transform,true);
        }

        private void EnableMaleBodyParts()
        {
            maleHeads[0].gameObject.SetActive(true);
            maleBrows[0].gameObject.SetActive(true);
            maleFacialHair[0].gameObject.SetActive(true);
            maleTorsos[0].gameObject.SetActive(true);
            maleArmsUpperRight[0].gameObject.SetActive(true);
            maleArmsLowerRight[0].gameObject.SetActive(true);
            maleArmsUpperLeft[0].gameObject.SetActive(true);
            maleArmsLowerLeft[0].gameObject.SetActive(true);
            maleHandsRight[0].gameObject.SetActive(true);
            maleHandsLeft[0].gameObject.SetActive(true);
            maleHips[0].gameObject.SetActive(true);
            maleLegLeft[0].gameObject.SetActive(true);
            maleLegRight[0].gameObject.SetActive(true);
            hairstyles[2].gameObject.SetActive(true);
        }

        private void EnableFemaleBodyParts()
        {
            femaleHeads[0].gameObject.SetActive(true);
            femaleBrows[0].gameObject.SetActive(true);
            femaleTorso[0].gameObject.SetActive(true);
            femaleArmsUpperRight[0].gameObject.SetActive(true);
            femaleArmsLowerRight[0].gameObject.SetActive(true);
            femaleArmsUpperLeft[0].gameObject.SetActive(true);
            femaleArmsLowerLeft[0].gameObject.SetActive(true);
            femaleHandsRight[0].gameObject.SetActive(true);
            femaleHandsLeft[0].gameObject.SetActive(true);
            femaleHips[0].gameObject.SetActive(true);
            femaleLegRight[0].gameObject.SetActive(true);
            femaleLegLeft[0].gameObject.SetActive(true);
            hairstyles[0].gameObject.SetActive(true);
            
        }

        private void DisableBodyParts(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.GetComponent<BodyPartCollection>() != null && child.gameObject.activeInHierarchy)
                {
                    child.gameObject.SetActive(false);
                }

                // Recursively call the method for each child
                DisableBodyParts(child);
            }
        }


        public void UpdateActivePieces(Transform parent, bool firstCall)
        {
            if (firstCall) currentlyActivePeices.Clear();
            foreach (Transform child in parent)
            {
                if (child.TryGetComponent<BodyPartCollection>(out BodyPartCollection bodyParts) && child.gameObject.activeInHierarchy)
                {
                    currentlyActivePeices.Add(child.gameObject);
                }

                // Recursively call the method for each child
                UpdateActivePieces(child,false);
            }
        }

        public void UpdateCustomMaterial(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.TryGetComponent<BodyPartCollection>(out BodyPartCollection bodyParts))
                {
                    Material instanceMaterial = Instantiate(reffenceMaterial);
                    child.gameObject.GetComponent<Renderer>().material = instanceMaterial;
                }

                // Recursively call the method for each child
                UpdateCustomMaterial(child);
            }
        }

    }

}