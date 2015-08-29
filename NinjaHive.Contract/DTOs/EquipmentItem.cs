﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NinjaHive.Contract.DTOs
{
    public class EquipmentItem
    {
        public Guid Id                                      { get; set; }

        public string Name                                  { get; set; }
        [Required]
        public string Description                           { get; set; }
        [Required]
        public string Category                              { get; set; }
        [Required]  
        public bool Craftable                               { get; set; }
        [Required]
        public bool UpgradeElement                          { get; set; }
        [Required]
        public bool CraftingElement                         { get; set; }
        [Required]
        public bool QuestItem                               { get; set; }

        [Required]
        public int Durability                               { get; set; }
        [Required]
        public int Value                                    { get; set; }
    }
}