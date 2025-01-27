namespace PKHeX.Core;

public sealed class Musical5(SAV5 SAV, int offset) : SaveBlock<SAV5>(SAV, offset)
{
    private const int PropOffset = 0x258;

    public void UnlockAllMusicalProps()
    {
        // 100 props, which is 12.5 bytes of bitflags.
        var bitFieldOffset = Offset + PropOffset;
        for (int i = 0; i < 0xC; i++)
            Data[bitFieldOffset + i] = 0xFF;
        Data[bitFieldOffset + 0xC] = 0x0F; // top 4 bits unset, to complete multiple of 8 (100=>104 bits).
    }

    public bool GetHasProp(int prop)
    {
        var bitFieldOffset = Offset + PropOffset;
        var bitOffset = prop >> 3;
        return SAV.GetFlag(bitFieldOffset + bitOffset, prop & 7);
    }

    public void SetHasProp(int prop, bool value = true)
    {
        var bitFieldOffset = Offset + PropOffset;
        var bitOffset = prop >> 3;
        SAV.SetFlag(bitFieldOffset + bitOffset, prop & 7, value);
    }
}
