using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterCustomizer.Core
{
    public class BodyPartChanger : MonoBehaviour
    {

        [Header("Sliders")]
        public Slider race = null;
        public Slider gender = null;
        public Slider face = null;
        public Slider hairstyle = null;
        public Slider facialHair = null;
        public Slider eyebrows = null;
        public Slider bodyPaintColor = null;
        public Slider hairColor = null;

        private DefaultBodyPartSetup setup;
        private void Awake()
        {
            setup = FindObjectOfType<DefaultBodyPartSetup>();
        }
        private void Start()
        {
            PaintSliderEnabled();
        }

        //Changer functions that use slider values in reffrence to lists created in setup
        public void ChangeRace()
        {
            ChangeSkinColour(setup.transform);
            ChangeEars();
        }
        public void ChangePaint()
        {
            ChangeBodyPaintColor(setup.transform);
        }
        public void ChangeHair()
        {
            ChangeHairColour(setup.transform);
        }
        public void ChangeGender()
        {
            if(gender.value == 0)
            {
                setup.EnableDefaultMale();
                facialHair.gameObject.SetActive(true);
                ChangeHairstyle();
                ChangeFace();
                ChangeEars();
                SetSliderMaxValues();
            }
            else
            {
                facialHair.gameObject.SetActive(false);
                setup.EnableDefaultFemale();
                ChangeHairstyle();
                ChangeFace();
                ChangeEars();
                SetSliderMaxValues();
            }
        }
        public void ChangeHairstyle()
        {
            foreach (GameObject activePiece in setup.currentlyActivePeices)
            {
                if(activePiece.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Hairstyle)
                {
                    activePiece.SetActive(false);
                }
            }
            setup.hairstyles[((int)hairstyle.value)].gameObject.SetActive(true);
            setup.UpdateActivePieces(setup.transform,true);
        }
        public void ChangeFacialHair()
        {
            foreach (GameObject activePiece in setup.currentlyActivePeices)
            {
                if (activePiece.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.FacialHair)
                {
                    activePiece.SetActive(false);
                }
            }
            setup.maleFacialHair[((int)facialHair.value)].gameObject.SetActive(true);
            setup.UpdateActivePieces(setup.transform, true);
        }
        public void ChangeFace()
        {
            foreach (GameObject activePiece in setup.currentlyActivePeices)
            {
                if (activePiece.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Head)
                {
                    activePiece.SetActive(false);
                }
            }
            if (setup.isMale == true)
            {
                setup.maleHeads[((int)face.value)].gameObject.SetActive(true);
            }
            else
            {
                setup.femaleHeads[((int)face.value)].gameObject.SetActive(true);
            }
            setup.UpdateActivePieces(setup.transform, true);

        }
        public void ChangeEyebrows()
        {
            foreach (GameObject activePiece in setup.currentlyActivePeices)
            {
                if (activePiece.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Eyebrows)
                {
                    activePiece.SetActive(false);
                }
            }
            if (setup.isMale == true)
            {

                setup.maleBrows[((int)eyebrows.value)].gameObject.SetActive(true);
            }
            else
            {
                setup.femaleBrows[((int)eyebrows.value)].gameObject.SetActive(true);
            }
            setup.UpdateActivePieces(setup.transform, true);
        }
        public void SetSliderMaxValues()
        {
            race.maxValue = setup.raceSkinColours.Count - 1;
            face.maxValue = setup.maleHeads.Count - 1;
            hairstyle.maxValue = setup.hairstyles.Count - 1;
            facialHair.maxValue = setup.maleFacialHair.Count - 1;
            bodyPaintColor.maxValue = setup.paintColours.Count - 1;
            hairColor.maxValue = setup.hairColours.Count - 1;
            if (setup.isMale)
            {
                eyebrows.maxValue = setup.maleBrows.Count - 1;

            }
            else
            {
                eyebrows.maxValue = setup.femaleBrows.Count - 1;
            }
        }
        public void PaintSliderEnabled()
        {
            if (face.value < 8)
            {
                bodyPaintColor.gameObject.SetActive(false);
            }
            else
            {
                bodyPaintColor.gameObject.SetActive(true);
            }
        }

        //Private functions that need parameters, public usable versions at top of script 
        private void ChangeSkinColour(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.TryGetComponent<BodyPartCollection>(out BodyPartCollection bodyParts))
                {
                    Material childInstancedMaterial = child.GetComponent<Renderer>().material;
                    int colorIndex = (int)race.value;   
                    Color raceBaseColor = setup.raceSkinColours[colorIndex];
                    Color raceSecondaryColor = setup.secondaryRaceSkinColours[colorIndex];
                    Color raceTertiaryColor = setup.tertiaryRaceSkinColours[colorIndex];
                    childInstancedMaterial.SetColor("_Color_Skin", raceBaseColor);
                    childInstancedMaterial.SetColor("_Color_Stubble", raceSecondaryColor);
                    childInstancedMaterial.SetColor("_Color_Scar", raceTertiaryColor);
                    
                }
                ChangeSkinColour(child);
            }
            
        }
        private void ChangeBodyPaintColor(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.TryGetComponent<BodyPartCollection>(out BodyPartCollection bodyParts))
                {
                    Material childInstancedMaterial = child.GetComponent<Renderer>().material;
                    int colorIndex = (int)bodyPaintColor.value;
                    Color paintColor = setup.paintColours[colorIndex];
                    childInstancedMaterial.SetColor("_Color_BodyArt", paintColor);
                }
                ChangeBodyPaintColor(child);
            }
        }
        private void ChangeHairColour(Transform parent)
        {
            foreach (Transform child in parent)
            {
                if (child.TryGetComponent<BodyPartCollection>(out BodyPartCollection bodyParts))
                {
                    Material childInstancedMaterial = child.GetComponent<Renderer>().material;
                    int colorIndex = (int)hairColor.value;
                    Color hairColour = setup.hairColours[colorIndex];
                    childInstancedMaterial.SetColor("_Color_Hair", hairColour);
                }
                ChangeHairColour(child);
            }
        }
        private void ChangeEars()
        {
            foreach (GameObject activePiece in setup.currentlyActivePeices)
            {
                if (activePiece.GetComponent<BodyPartCollection>().bodyPieceType == BodyPartCollection.BodyPieceType.Ears)
                {
                    activePiece.SetActive(false);
                }
            }
            setup.ears[((int)race.value)].gameObject.SetActive(true);
            setup.UpdateActivePieces(setup.transform, true);
        }
       
    }
}
