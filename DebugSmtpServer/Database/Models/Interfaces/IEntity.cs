﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugSmtpServer.Database.Models.Interfaces
{
    public interface IEntity
    {
        public long Id { get; set; }
        public void Save();
    }
}
