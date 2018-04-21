using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff {

    public string type;

    public Buff(string type)
    {
        this.type = type;
    }

    public virtual void Effect()
    {

    }
   
}
