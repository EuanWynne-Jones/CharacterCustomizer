using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterCustomizer.Core
{
    public class BodyPartChanger : MonoBehaviour
    {
        public Slider raceSlider = null;
        public Slider genderSlider = null;
        public Slider faceSlider = null;
        public Slider hairstyleSlider = null;
        public Slider facialHairSlider = null;
        public Slider eyebrowsSlider = null;
        public Slider paintColorSlider = null;
        public Slider hairColorSlider = null;

        private DefaultBodyPartSetup setup;

        private void Awake()
        {
            setup = FindObjectOfType<DefaultBodyPartSetup>();
        }

        private void Start()
        {
            PaintSliderEnabled();
        }

       

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
            if(genderSlider.value == 0)
            {
                setup.EnableDefaultMale();
                facialHairSlider.gameObject.SetActive(true);
                ChangeHairstyle();
                ChangeFace();
                ChangeEars();
                eyebrowsSlider.maxValue = 9f;
            }
            else
            {
                facialHairSlider.gameObject.SetActive(false);
                setup.EnableDefaultFemale();
                ChangeHairstyle();
                ChangeFace();
                ChangeEars();
                eyebrowsSlider.maxValue = 6f;

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
            setup.hairstyles[((int)hairstyleSlider.value)].gameObject.SetActive(true);
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
            setup.maleFacialHair[((int)facialHairSlider.value)].gameObject.SetActive(true);
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
                setup.maleHeads[((int)faceSlider.value)].gameObject.SetActive(true);
            }
            else
            {
                setup.femaleHeads[((int)faceSlider.value)].gameObject.SetActive(true);
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

                setup.maleBrows[((int)eyebrowsSlider.value)].gameObject.SetActive(true);
            }
            else
            {
                setup.femaleBrows[((int)eyebrowsSlider.value)].gameObject.SetActive(true);
            }
            setup.UpdateActivePieces(setup.transform, true);
        }
        public void SetSliderMaxValues()
        {
            raceSlider.maxValue = setup.raceSkinColours.Count - 1;
            faceSlider.maxValue = setup.maleHeads.Count - 1;
            hairstyleSlider.maxValue = setup.hairstyles.Count - 1;
            facialHairSlider.maxValue = setup.maleFacialHair.Count - 1;
            if (setup.isMale)
            {
                eyebrowsSlider.maxValue = setup.maleBrows.Count - 1;

            }
            else
            {
                eyebrowsSlider.maxValue = setup.femaleBrows.Count - 1;
            }
            paintColorSlider.maxValue = setup.paintColours.Count - 1;
            hairColorSlider.maxValue = setup.hairColours.Count - 1;
        }
        public void PaintSliderEnabled()
        {
            if (faceSlider.value < 8)
            {
                paintColorSlider.gameObject.SetActive(false);
            }
            else
            {
                paintColorSlider.gameObject.SetActive(true);
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
                    int colorIndex = (int)raceSlider.value;   
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
                    int colorIndex = (int)paintColorSlider.value;
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
                    int colorIndex = (int)hairColorSlider.value;
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
            setup.ears[((int)raceSlider.value)].gameObject.SetActive(true);
            setup.UpdateActivePieces(setup.transform, true);
        }
       
    }
}
