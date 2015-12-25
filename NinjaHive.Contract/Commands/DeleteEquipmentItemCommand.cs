﻿using System.ComponentModel.DataAnnotations;
using NinjaHive.Contract.DTOs;
using NinjaHive.Core.Validations;

namespace NinjaHive.Contract.Commands
{
    public class DeleteEquipmentItemCommand
    {
        [Required]
        [ValidateObject]
        public GameItem EquipmentItem { get; set; }
    }
}
