﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Plat
{
    public interface IPlatDataAccessLayer
    {
        List<Entity.Plat> GetPlatByMenuID(int menuID);

        void AddPlat(Entity.Plat plat);
    }
}
