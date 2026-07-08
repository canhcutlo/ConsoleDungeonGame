using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDungeonGame
{
    abstract class WeaponDecorator : IWeapon
    {
        protected IWeapon _weapon;

        public WeaponDecorator(IWeapon weapon)
        {
            this._weapon = weapon;
        }

        // Ủy thác hành vi lại cho vũ khí bên trong nó
        public virtual string GetDescription()
        {
            return _weapon.GetDescription();
        }

        public virtual int GetBonusDamage()
        {
            return _weapon.GetBonusDamage();
        }
    }

    // FireAspect
    class FireElement : WeaponDecorator
    {
        public FireElement(IWeapon weapon) : base(weapon) { }

        public override string GetDescription()
        {
            return base.GetDescription() + " FireAspect";
        }

        public override int GetBonusDamage()
        {
            return base.GetBonusDamage() + 10;
        }
    }

    // FrozenAspect
    class IceElement : WeaponDecorator
    {
        public IceElement(IWeapon weapon) : base(weapon) { }

        public override string GetDescription()
        {
            return base.GetDescription() + " FrozenAspect";
        }

        public override int GetBonusDamage()
        {
            return base.GetBonusDamage() + 6;
        }
    }
}
