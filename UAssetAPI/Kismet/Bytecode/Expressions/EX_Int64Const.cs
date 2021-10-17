﻿namespace UAssetAPI.Kismet.Bytecode.Expressions
{
    /// <summary>
    /// A single Kismet bytecode instruction, corresponding to the <see cref="EExprToken.EX_Int64Const"/> instruction.
    /// </summary>
    public class EX_Int64Const : Expression<long>
    {
        /// <summary>
        /// The token of this expression.
        /// </summary>
        public override EExprToken Token { get { return EExprToken.EX_Int64Const; } }

        public EX_Int64Const()
        {

        }

        /// <summary>
        /// Reads out the expression from a BinaryReader.
        /// </summary>
        /// <param name="reader">The BinaryReader to read from.</param>
        public override void Read(AssetBinaryReader reader)
        {
            Value = reader.ReadInt64();
        }

        /// <summary>
        /// Writes the expression to a BinaryWriter.
        /// </summary>
        /// <param name="writer">The BinaryWriter to write from.</param>
        /// <returns>The length in bytes of the data that was written.</returns>
        public override int Write(AssetBinaryWriter writer)
        {
            writer.Write(Value);
            return 0;
        }
    }
}