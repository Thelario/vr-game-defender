using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IConfigurable
    {
        public void ConfigureBullet(float damage, Transform target);
    }
}
