﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class PhysicComponent
{
    protected Entity entity;

    public void setEntity(Entity e)
    {
        this.entity = e;
    }

    public abstract void update(GameTime gameTime, InGame ingame);
}
