﻿namespace NinjaHive.Domain
{
    public interface IEntityEditHandler
    {
        void SaveEditInfo();
        void AddIdIfNotExist();
    }
}
