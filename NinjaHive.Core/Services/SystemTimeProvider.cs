﻿using System;

namespace NinjaHive.Core.Services
{
    public class SystemTimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}