﻿namespace Undersoft.SDK.Uniques
{
    public interface IUnique : IIdentifiable, IEquatable<IUnique>, IComparable<IUnique>
    {
        byte[] GetBytes();

        byte[] GetIdBytes();
    }
}
