﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClassEntity : NinjaHive.Domain.IEntity
    {
        public ClassEntity()
        {
            this.EditInfo = new EditInfo();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public System.Guid Id { get; set; }
        public string Name { get; set; }
    
        public EditInfo EditInfo { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class EquipmentItemEntity : GameItemEntity, NinjaHive.Domain.IEntity
    {
        public EquipmentItemEntity()
        {
            this.Tiers = new HashSet<TierEntity>();
            this.Races = new HashSet<RaceEntity>();
            this.Classes = new HashSet<ClassEntity>();
            this.Enhancers = new HashSet<OtherItemEntity>();
            this.Slot = new ItemSlot();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public int Durability { get; set; }
    
        public ItemSlot Slot { get; set; }
    
        public virtual ICollection<TierEntity> Tiers { get; set; }
        public virtual ICollection<RaceEntity> Races { get; set; }
        public virtual ICollection<ClassEntity> Classes { get; set; }
        public virtual ICollection<OtherItemEntity> Enhancers { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class GameItemEntity : NinjaHive.Domain.IEntity
    {
        public GameItemEntity()
        {
            this.EditInfo = new EditInfo();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool Craftable { get; set; }
        public bool IsUpgrader { get; set; }
        public bool IsCrafter { get; set; }
        public bool IsQuestItem { get; set; }
        public int Value { get; set; }
    
        public EditInfo EditInfo { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class LevelEntity : NinjaHive.Domain.IEntity
    {
        public LevelEntity()
        {
            this.EditInfo = new EditInfo();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public System.Guid Id { get; set; }
        public int Level { get; set; }
        public int Threshold { get; set; }
    
        public EditInfo EditInfo { get; set; }
    
        public virtual TierEntity Tier { get; set; }
        public virtual StatInfoEntity StatInfo { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class MiscItemEntity : GameItemEntity, NinjaHive.Domain.IEntity
    {
    
        public virtual SkillEntity Skill { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class OtherItemEntity : GameItemEntity, NinjaHive.Domain.IEntity
    {
        public OtherItemEntity()
        {
            this.CraftingIngredients = new HashSet<GameItemEntity>();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public bool IsEnhancer { get; set; }
    
        public virtual StatInfoEntity StatInfo { get; set; }
        public virtual ICollection<GameItemEntity> CraftingIngredients { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class RaceEntity : NinjaHive.Domain.IEntity
    {
        public RaceEntity()
        {
            this.EditInfo = new EditInfo();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public System.Guid Id { get; set; }
        public string Name { get; set; }
    
        public EditInfo EditInfo { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class SkillEntity : NinjaHive.Domain.IEntity
    {
        public SkillEntity()
        {
            this.Range = 0;
            this.Radius = 0;
            this.Targets = 1;
            this.Specials = new HashSet<SpecialEntity>();
            this.EditInfo = new EditInfo();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public int Range { get; set; }
        public int Radius { get; set; }
        public int Targets { get; set; }
        public NinjaHive.Domain.Enums.Target Target { get; set; }
        public bool Friendly { get; set; }
    
        public EditInfo EditInfo { get; set; }
    
        public virtual ICollection<SpecialEntity> Specials { get; set; }
        public virtual StatInfoEntity StatInfo { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpecialEntity : NinjaHive.Domain.IEntity
    {
        public SpecialEntity()
        {
            this.EditInfo = new EditInfo();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public System.Guid Id { get; set; }
        public string Name { get; set; }
    
        public EditInfo EditInfo { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class StatInfoEntity : NinjaHive.Domain.IEntity
    {
        public StatInfoEntity()
        {
            this.Health = 0;
            this.Magic = 0;
            this.Attack = 0;
            this.Defense = 0;
            this.Stamina = 0;
            this.Hunger = 0;
            this.Agility = 0;
            this.Intelligence = 0;
            this.Resistance = 0D;
            this.EditInfo = new EditInfo();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public System.Guid Id { get; set; }
        public int Health { get; set; }
        public int Magic { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Stamina { get; set; }
        public int Hunger { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public double Resistance { get; set; }
    
        public EditInfo EditInfo { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class TierEntity : NinjaHive.Domain.IEntity
    {
        public TierEntity()
        {
            this.Levels = new HashSet<LevelEntity>();
            this.Skills = new HashSet<SkillEntity>();
            this.UpgradeIngredients = new HashSet<GameItemEntity>();
            this.CraftingIngredients = new HashSet<GameItemEntity>();
            this.EditInfo = new EditInfo();
            this.OnCreated();
        }
    
        partial void OnCreated();
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }
    
        public EditInfo EditInfo { get; set; }
    
        public virtual EquipmentItemEntity EquipmentItem { get; set; }
        public virtual ICollection<LevelEntity> Levels { get; set; }
        public virtual ICollection<SkillEntity> Skills { get; set; }
        public virtual ICollection<GameItemEntity> UpgradeIngredients { get; set; }
        public virtual ICollection<GameItemEntity> CraftingIngredients { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    
    public partial class EditInfo
    {
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime EditedOn { get; set; }
        public string EditedBy { get; set; }
    }
}
namespace NinjaHive.Domain
{
    using System;
    
    public partial class ItemSlot
    {
        public int NumberOfSlots { get; set; }
        public NinjaHive.Domain.Enums.BodySlot BodySlot { get; set; }
    }
}
