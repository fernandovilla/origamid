﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Data
{
    public class UnitOfWorkFactory
    {
        public static readonly UnitOfWorkFactory Default = new UnitOfWorkFactory();

        public UnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork();
        }
    }
}