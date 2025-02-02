using System;

namespace PKHeX.Core;

public sealed class BattleAgency7(SAV7USUM sav, int offset) : SaveBlock<SAV7USUM>(sav, offset)
{
    public int GetSlotOffset(int slot) => Offset + slot switch
    {
        0 => 0,
        1 => PokeCrypto.SIZE_6STORED,
        2 => 0x220,
        _ => throw new ArgumentOutOfRangeException(nameof(slot)),
    };
}
