using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game.Items
{
    public interface Inventory : ICollection<Item>
    {
        void AddItem(Item item);

        void RemoveItem(Item item);

        void RemoveItem(int index);

        void DropAll();

        void ShiftLeft();

        void ShiftRight();
    }
}
