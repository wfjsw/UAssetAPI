﻿using System;
using UAssetAPI.UnrealTypes;
using UAssetAPI.ExportTypes;

namespace UAssetAPI.PropertyTypes.Objects
{
    /// <summary>
    /// Describes a boolean (<see cref="bool"/>).
    /// </summary>
    public class BoolPropertyData : PropertyData<bool>
    {
        public BoolPropertyData(FName name) : base(name)
        {

        }

        public BoolPropertyData()
        {

        }

        private static readonly FString CurrentPropertyType = new FString("BoolProperty");
        public override FString PropertyType { get { return CurrentPropertyType; } }
        public override object DefaultValue { get { return false; } }

        public override void Read(AssetBinaryReader reader, bool includeHeader, long leng1, long leng2 = 0, PropertySerializationContext serializationContext = PropertySerializationContext.Normal)
        {
            Value = reader.ReadBoolean();
            if (includeHeader)
            {
                PropertyGuid = reader.ReadPropertyGuid();
            }
        }

        public override int Write(AssetBinaryWriter writer, bool includeHeader, PropertySerializationContext serializationContext = PropertySerializationContext.Normal)
        {
            writer.Write(Value);
            if (includeHeader)
            {
                writer.WritePropertyGuid(PropertyGuid);
            }
            return 0;
        }

        public override string ToString()
        {
            return Convert.ToString(Value);
        }

        public override void FromString(string[] d, UAsset asset)
        {
            Value = d[0].Equals("1") || d[0].ToLowerInvariant().Equals("true");
        }
    }
}