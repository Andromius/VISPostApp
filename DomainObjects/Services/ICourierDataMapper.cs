﻿using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Services
{
    public interface ICourierDataMapper
    {
        public Courier FindByUserID(int id, string firstName, string lastName, DateOnly dateHired, string login, string password, bool atWork);
    }
}
