using MauryDev.KoGaMa.AvatarAPI.Enums;
using MauryDev.KoGaMa.AvatarAPI.MauryDev.KoGaMa.AvatarAPI.Models;
using MauryDev.KoGaMa.ModelAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MauryDev.KoGaMa.AvatarAPI
{
    public class AvatarInfo
    {
        public Dictionary<PartIndex, ModelInfo> Parts { get; set; } = new Dictionary<PartIndex, ModelInfo>();

        public ModelInfo this[PartIndex index]
        {
            get => Parts.ContainsKey(index) ? Parts[index] : null;
            set => Parts[index] = value;
        }

        public PartDefinition GetDefinition(PartIndex index)
            => AvatarPartRegistry.GetDefinition(index);

        public Vector3 GetBonePosition(PartIndex index)
            => AvatarPartRegistry.GetDefinition(index).BonePosition;

        public string GetPartName(PartIndex index)
            => AvatarPartRegistry.GetDefinition(index).Name;



        public void Equip(PartIndex index, ModelInfo model)
        {
            this[index] = model;
        }


        public void Unequip(PartIndex index)
        {
            if (Parts.ContainsKey(index))
            {
                Parts.Remove(index);
            }
        }

        public void ClearAllParts()
        {
            Parts.Clear();
        }

        public bool IsPartEquipped(PartIndex index)
        {
            return Parts.ContainsKey(index) && Parts[index] != null;
        }



        public bool IsModelValidForPart(PartIndex index, ModelInfo model)
        {
            if (model == null) return false;

            var definition = AvatarPartRegistry.GetDefinition(index);

            return true; 
        }



    
        public List<KeyValuePair<PartIndex, ModelInfo>> GetEquippedParts()
        {
            return Parts.ToList();
        }

       
        public bool IsFullyEquipped()
        {
            var requiredParts = new[] { PartIndex.Head, PartIndex.Torso };

            foreach (var part in requiredParts)
            {
                if (!IsPartEquipped(part)) return false;
            }
            return true;
        }

        public int EquippedCount => Parts.Count;

    }
}
